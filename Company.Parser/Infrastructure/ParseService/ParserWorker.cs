using Company.Base.Infractructure.Repository;
using Company.Parser.Data;
using Company.Parser.Entities;
using Company.Parser.Entities.Base;
using Company.Parser.Extensions;
using Company.Parser.Extensions.HtmlLoader;
using Company.Parser.Infrastructure.ParseService.Interfaces;
using Company.Parser.Infrastructure.Providers.Interfaces;
using Company.Parser.Models.ParserBackgroundModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Company.Parser.Infrastructure.ParseService;

public class ParserWorker<TDbContext> : IParserWorker
    where TDbContext : ParserDbContext
{
    #region Constructor

    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<ParserWorker<TDbContext>> _logger;

    public ParserWorker(
        IServiceProvider serviceProvider,
        ILogger<ParserWorker<TDbContext>> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    #endregion

    #region Property - SleepTime

    /// <summary>
    /// Время ожидания между get запросами
    /// </summary>
    private int sleepMillisecondsTime = 2000;

    /// <summary>
    /// Максимальное время ожидания между get запросами
    /// </summary>
    public int SleepMillisecondsTime
    {
        get => sleepMillisecondsTime;
        set
        {
            if (value < 0) throw new AggregateException($"The minimum value of the {nameof(sleepMillisecondsTime)} is 2000.");
            else sleepMillisecondsTime = value;
        }
    }

    #endregion

    /// <summary>
    /// Парсинг веб-страниц
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    /// <param name="parser">Данные для парсинга.</param>
    /// <param name="token">CancellationToken.</param>
    public async Task RunParseAsync<TEntity>(InfoParser parser, CancellationToken token)
        where TEntity : ParserAuditable
    {
        CheckParser(parser);

        using (var scope = _serviceProvider.CreateScope())
        {
            var _infoURLProvider = scope.ServiceProvider.GetRequiredService<IURLBackgroundTaskProvider>();
            var links = parser.Configurations.DistinctBy(x => x.URL).Select(x => x.URL);
            links = await _infoURLProvider.GetLinksNotStoredByDBAsync(parser.Id, links);

            if (links.Any())
            {
                var repository = scope.ServiceProvider.GetRequiredService<IBaseRepository<TDbContext, InfoURL>>();
                await repository.CreateAsync(
                    links.Select(x => new InfoURL()
                    {
                        ParserId = parser.Id,
                        Url = x
                    }));
            }
        }

        await ScanLinksAsync<TEntity>(parser, token);
    }

    /// <summary>
    /// Обновить значение результатов парсинга.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    /// <param name="parser">Данные для парсинга.</param>
    /// <param name="token">CancellationToken.</param>
    public async Task RunUpdateParseAsync<TEntity>(InfoParser parser, CancellationToken token)
        where TEntity : ParserAuditable
    {
        CheckParser(parser);

        using (var scope = _serviceProvider.CreateScope())
        {
            var _infoURLProvider = scope.ServiceProvider.GetRequiredService<IURLBackgroundTaskProvider>();
            var urls = await _infoURLProvider.GetLinksByParserIdAsync(parser.Id);
            if (!urls.Any()) throw new Exception("Links to update data not found.");

            foreach (var url in urls)
            {
                url.IsSuccess = false;
                url.HasBeenProcessed = false;
                url.ElapsedMilliseconds = 0;
                url.ExceptionMessage = null;
            }

            var repository = scope.ServiceProvider.GetRequiredService<IBaseRepository<TDbContext, InfoURL>>();
            await repository.UpdateAsync(urls);
        }

        await ScanLinksAsync<TEntity>(parser, token);
    }

    /// <summary>
    /// Сканировать ссылки.
    /// </summary>
    /// <typeparam name="TEntity">Тип создаваемой/обновляемой сущности.</typeparam>
    /// <param name="parser">Данные для парсинга.</param>
    /// <param name="token">CancellationToken.</param>
    /// <returns>Task.</returns>
    public async Task ScanLinksAsync<TEntity>(InfoParser parser, CancellationToken token)
        where TEntity : ParserAuditable
    {
        using var scope = _serviceProvider.CreateScope();
        var _parseResultsHandler = scope.ServiceProvider.GetRequiredService<IParseResultsHandler>();
        var _infoURLProvider = scope.ServiceProvider.GetRequiredService<IURLBackgroundTaskProvider>();

        Stopwatch watch = new();

        var infoURL = await _infoURLProvider.GetFollowLinkAsync(parser.Id);
        while (infoURL != null && !token.IsCancellationRequested)
        {
            try
            {
                (var parsingResult, var links) = await GetDataFromWebResourceAsync(parser, infoURL);

                await AddNewLinksAsync(links);

                if (parsingResult.IsParameters)
                    await _parseResultsHandler.CreateOrUpdateEntityAsync<TDbContext, TEntity>(infoURL, parsingResult);

                infoURL.IsSuccess = true;
            }
            catch (Exception ex)
            {
                infoURL.IsSuccess = false;
                infoURL.ExceptionMessage = DescriptionOfErrors.GetExeption(ex);
            }
            finally
            {
                await UpdateLinkAfterProcessCompletedAsync(infoURL, (int)watch.ElapsedMilliseconds);
                infoURL = await _infoURLProvider.GetFollowLinkAsync(parser.Id);

                watch.Stop();
                SleepThread(watch);
                watch.Reset();
            }
        }
    }

    /// <summary>
    /// Получить данные с веб-страницы.
    /// </summary>
    /// <param name="parser">Данные для парсинга.</param>
    /// <param name="infoURL">Данные о url-адресе.</param>
    /// <returns></returns>
    /// <exception cref="Exception">Ошибка при получении данных с веб-страницы.</exception>
    private async Task<(Value parsingResult, IEnumerable<InfoURL> links)> GetDataFromWebResourceAsync(InfoParser parser, InfoURL infoURL)
    {
        using var scope = _serviceProvider.CreateScope();
        var _htmlLoader = scope.ServiceProvider.GetRequiredService<IHtmlLoader>();
        var _parserPage = scope.ServiceProvider.GetRequiredService<IParserPage>();

        var source = await _htmlLoader.GetSourceByPageAsync(infoURL.Url);
        if (string.IsNullOrWhiteSpace(source)) throw new Exception($"No data was received from the web page. {nameof(source)} = null.");

        // Парсинг веб-страницы
        (Value parsingResult, IEnumerable<InfoURL>? links) = await _parserPage.ParseAsync(parser, source);
        parsingResult.InfoURLId = infoURL.Id;

        return (parsingResult, links);
    }

    /// <summary>
    /// Добавить новые ссылки в базу данных
    /// </summary>
    /// <param name="links">Список ссылок на добавление</param>
    /// <returns></returns>
    private async Task AddNewLinksAsync(IEnumerable<InfoURL> links)
    {
        if (links.Any())
        {
            using var scope = _serviceProvider.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<IBaseRepository<TDbContext, InfoURL>>();
            await repository.CreateAsync(links);
        }
    }

    /// <summary>
    /// Обновить значение ссылки по завершению обработки.
    /// </summary>
    /// <param name="infoURL">Информация о ссылки.</param>
    /// <param name="elapsedMilliseconds">Время обработки.</param>
    /// <returns></returns>
    private async Task UpdateLinkAfterProcessCompletedAsync(InfoURL infoURL, int elapsedMilliseconds)
    {
        using var scope = _serviceProvider.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<IBaseRepository<TDbContext, InfoURL>>();
        infoURL.HasBeenProcessed = true;
        infoURL.ElapsedMilliseconds = elapsedMilliseconds;
        await repository.UpdateAsync(infoURL);
    }

    /// <summary>
    /// Проверить на корректность значение.
    /// </summary>
    /// <param name="parser">Данные для парсинга.</param>
    private void CheckParser(InfoParser parser)
    {
        if (!parser.Configurations.Any()) throw new Exception($"The list of parser configurations is empty. The number of elements in the {nameof(parser.Configurations)} is zero.");
        foreach (var config in parser.Configurations)
        {
            if (!config.Fields.Any()) throw new Exception($"In this configuration ({config.Id}), there is no description of the fields for parsing.");
        }
    }

    /// <summary>
    /// Отправить поток в спячку
    /// </summary>
    /// <param name="watch">Stopwatch.</param>
    private void SleepThread(Stopwatch watch)
    {
        int sleep = SleepMillisecondsTime - (int)watch.ElapsedMilliseconds;
        if (sleep > 0) Thread.Sleep(sleep);
    }
}