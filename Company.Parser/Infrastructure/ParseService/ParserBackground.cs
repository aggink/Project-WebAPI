using Company.Base.Infractructure.Repository;
using Company.Parser.Data;
using Company.Parser.Entities;
using Company.Parser.Extensions;
using Company.Parser.Infrastructure.ParseService.Interfaces;
using Company.Parser.Infrastructure.Providers.Interfaces;
using Company.Parser.Models.ParserBackgroundModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Company.Parser.Infrastructure.ParseService;

/// <summary>
/// Фоновая задача парсера веб-сайтов
/// </summary>
public abstract class ParserBackground<TDbContext> : BackgroundService
    where TDbContext : ParserDbContext
{
    protected readonly ILogger<ParserBackground<TDbContext>> _logger;
    protected readonly IServiceProvider _serviceProvider;

    public ParserBackground(IServiceProvider serviceProvider, ILogger<ParserBackground<TDbContext>> logger)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Время ожидания между запросами к базе данных.
    /// </summary>
    protected int WaitTime { get; set; } = 300000;

    #region ChangeStatus

    /// <summary>
    /// Изменить статус - в работе
    /// </summary>
    /// <param name="token">CancellationToken.</param>
    /// <returns>Данные о парсере или null, если парсера для выполнения нет.</returns>
    protected async Task<InfoParser?> ChangeStatusOnCompleteAsync(CancellationToken token)
    {
        using var scope = _serviceProvider.CreateScope();
        var parserRepository = scope.ServiceProvider.GetRequiredService<IBaseRepository<TDbContext, InfoParser>>();
        var parserProvider = scope.ServiceProvider.GetRequiredService<IParserProvider>();

        var parser = await parserProvider.GetOldEntityReadyExecuteAsync();
        if (parser == null) return null;

        parser.StartTime = DateTime.UtcNow;
        parser.IsStart = true;
        parser.IsQueue = false;
        parser.ExceptionMessage = null;

        await parserRepository.UpdateAsync(parser);
        return parser;
    }

    /// <summary>
    /// Изменить статус - завершено.
    /// </summary>
    /// <param name="token">CancellationToken.</param>
    /// <returns>Данные о парсере.</returns>
    protected async Task<InfoParser> ChangeStatusOnCompletedAsync(CancellationToken token)
    {
        using var scope = _serviceProvider.CreateScope();
        var parserRepository = scope.ServiceProvider.GetRequiredService<IBaseRepository<TDbContext, InfoParser>>();
        var parserProvider = scope.ServiceProvider.GetRequiredService<IParserProvider>();

        var parser = await parserProvider.GetActiveBackgroundTaskAsync();
        if (parser == null) throw new Exception("There are no tasks in the queue to be executed.");

        parser.IsCompleted = true;
        parser.IsStart = false;
        parser.IsStartUpdate = false;
        parser.CompletionTime = DateTime.UtcNow;

        await parserRepository.UpdateAsync(parser);
        return parser;
    }

    /// <summary>
    /// Изменить статус - ошибка.
    /// </summary>
    /// <param name="exception">Exception.</param>
    /// <param name="token">CancellationToken.</param>
    protected async Task ChangeStatusOnErrorAsync(Exception exception, CancellationToken token)
    {
        using var scope = _serviceProvider.CreateScope();
        var parserRepository = scope.ServiceProvider.GetRequiredService<IBaseRepository<TDbContext, InfoParser>>();
        var parserProvider = scope.ServiceProvider.GetRequiredService<IParserProvider>();

        try
        {
            var parser = await parserProvider.GetActiveBackgroundTaskAsync();
            if (parser == null) throw new Exception($"The started task was not found.");

            parser.IsCompleted = true;
            parser.IsQueue = false;
            parser.IsStart = false;
            parser.IsStartUpdate = false;
            parser.ExceptionMessage = DescriptionOfErrors.GetExeption(exception);
            parser.CompletionTime = DateTime.UtcNow;

            await parserRepository.UpdateAsync(parser);
        }
        catch
        {
        }
    }

    #endregion

    #region AbstractMethod

    /// <summary>
    /// Запуск парсинга.
    /// </summary>
    /// <param name="parserWorker">Интерфейс для работы с парсером.</param>
    /// <param name="parser">Сущность парсера.</param>
    /// <param name="token">CancellationToken.</param>
    protected abstract Task ExecuteParseAsync(IParserWorker parserWorker, InfoParser parser, CancellationToken token);

    /// <summary>
    /// Обновить данные парсинга
    /// </summary>
    /// <param name="parserWorker">Интерфейс для работы с парсером.</param>
    /// <param name="parser">Сущность парсера.</param>
    /// <param name="token">CancellationToken.</param>
    protected abstract Task UpdateExecutedParseAsync(IParserWorker parserWorker, InfoParser parser, CancellationToken token);

    /// <summary>
    /// Выполнить после завершения задачи.
    /// </summary>
    /// <param name="parser">Сущность парсера.</param>
    /// <param name="token">CancellationToken.</param>
    protected virtual Task ExecuteAfterTaskCompletedAsync(InfoParser parser, CancellationToken token)
    {
        return Task.CompletedTask;
    }

    #endregion

    /// <summary>
    /// Запустить задачу.
    /// </summary>
    /// <param name="token">Токен отмены.</param>
    /// <returns>Task.</returns>
    /// <exception cref="ArgumentException">Объект не найден.</exception>
    protected override async Task ExecuteAsync(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            try
            {
                // Изменение статуса задачи - на выполнении

                var parser = await ChangeStatusOnCompleteAsync(token);
                if (parser == null) continue;

                _logger.BackgroundWorkCreated(WorkTypeEnum.WebSiteParsing.ToString(), parser.Id.ToString());

                // Запуск парсера

                using (var scope = _serviceProvider.CreateScope())
                {
                    var backgroundWork = scope.ServiceProvider.GetRequiredService<IParserWorker>();

                    if (!parser.IsStartUpdate) await ExecuteParseAsync(backgroundWork, parser, token);
                    else await UpdateExecutedParseAsync(backgroundWork, parser, token);
                }

                // Изменение статуса задачи - завершенная

                parser = await ChangeStatusOnCompletedAsync(token);

                _logger.BackgroundWorkComleted(WorkTypeEnum.WebSiteParsing.ToString(), parser.Id.ToString());

                // Выполнить после завершения работы парсера

                await ExecuteAfterTaskCompletedAsync(parser, token);
            }
            catch (Exception ex)
            {
                await ChangeStatusOnErrorAsync(ex, token);
            }
            finally
            {
                await Task.Delay(WaitTime, token);
            }
        }
    }
}