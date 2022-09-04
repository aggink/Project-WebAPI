using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Company.Parser.Entities;
using Company.Parser.Infrastructure.ParseService.Interfaces;
using Company.Parser.Infrastructure.Providers.Interfaces;
using Company.Parser.Models.ParserBackgroundModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace Company.Parser.Infrastructure.ParseService;

/// <summary>
/// Базовый класс отвечающий за парсинг страниц
/// </summary>
public class ParserPage : IParserPage
{
    #region Constructor

    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<ParserPage> _logger;

    private readonly IHtmlParser HtmlParser;
    private CancellationToken CancellationToken { get; set; }

    public ParserPage(
        IServiceProvider serviceProvider,
        ILogger<ParserPage> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;

        HtmlParser = new HtmlParser();
        CancellationToken = new CancellationToken();
    }

    #endregion

    #region Properties

    /// <summary>
    /// Служит точкой входа в содержимое HTML-документа
    /// </summary>
    private IHtmlDocument HtmlDocument { get; set; } = null!;

    #endregion

    /// <summary>
    /// Обработка веб-страницы
    /// </summary>
    /// <param name="parser">Данные парсера.</param>
    /// <param name="source">Данные полученные с веб-страницы</param>
    /// <returns>Объект со счтанными значениями с веб-страницы</returns>
    /// <exception cref="ArgumentException">Ошибка при сохранении ссылок в базу данных.</exception>
    public async Task<(Value, IEnumerable<InfoURL>)> ParseAsync(InfoParser parser, string source)
    {
        HtmlDocument = await HtmlParser.ParseDocumentAsync(source, CancellationToken);
        if (CancellationToken.IsCancellationRequested) throw new Exception($"CancellationToken = {CancellationToken.IsCancellationRequested}.");

        // Обработка страницы
        var parseResult = ParsePage(parser.Configurations);

        // Добавление ссылок полученных со страницы в БД
        var addLinksResult = await GetNewLinksAsync(parseResult.Configuration);

        Clear();
        return (parseResult, addLinksResult);
    }

    #region ParsePage

    /// <summary>
    /// Обработка веб-страницы.
    /// </summary>
    /// <returns>Список считанных значений со страницы.</returns>
    private Value ParsePage(IEnumerable<ConfigurationParser> configurations)
    {
        using var collection = new BlockingCollection<(double Ratio, int Count, Value Values)>();

        Parallel.ForEach(configurations!, configuration =>
        {
            Value value = new()
            {
                Configuration = configuration
            };

            foreach (var field in configuration.Fields)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(field.StringParse)) continue;

                    var element = HtmlDocument.QuerySelector(field.StringParse);
                    if (element == null) continue;

                    value.AddParameter(field.PropertyName, Regex.Replace(element.TextContent, @"\s+", " "));
                }
                catch
                {
                    continue;
                }
            }

            var ratio = value.Count * 100d / configuration.Fields.Count;
            collection.Add(new(ratio, configuration.Fields.Count, value));
        });

        (double Ratio, int Count, Value Value) = collection.MaxBy(x => x.Ratio);
        return Value;
    }

    /// <summary>
    /// Удалить теги, пробелы и тд из строки.
    /// </summary>
    /// <param name="inputString">Строка для обработки.</param>
    /// <returns>Строка без HTML-тегов и многочисленных пробелов.</returns>
    private static string RemoveAllTagsFromHTML(string inputString)
    {
        const string HTML_TAG_PATTERN = "<.*?>|\a|\b|\f|\n|\r|\t|\v|<!--.*?-->";
        const string PATTERN = @"\s+";
        return Regex.Replace(Regex.Replace(inputString, HTML_TAG_PATTERN, @" "), PATTERN, @" ");
    }

    /// <summary>
    /// Удалить все атрибуты из тегов в строке.
    /// </summary>
    /// <param name="inputString">Строка для обработки.</param>
    /// <returns>Строка без атрибутов в тегах.</returns>
    private static string RemoveAllAttributesFromTags(string inputString)
    {
        const string HTML_TAG_PATTERN = "<([a-z][a-z0-9]*)[^>]*?(/?)>|\a|\b|\f|\n|\r|\t|\v|<!--.*?-->";
        const string PATTERN = @"\s+";
        return Regex.Replace(Regex.Replace(inputString, HTML_TAG_PATTERN, @" "), PATTERN, @" ");
    }

    #endregion

    #region AddNewLinksTodataBase

    /// <summary>
    /// Получить новые ссылки.
    /// </summary>
    /// <returns>Список ссылок или null.</returns>
    private async Task<IEnumerable<InfoURL>> GetNewLinksAsync(ConfigurationParser configuration)
    {
        #region DependencyInjection

        using var scope = _serviceProvider.CreateScope();
        var _infoURLProvider = scope.ServiceProvider.GetRequiredService<IURLBackgroundTaskProvider>();

        #endregion

        IEnumerable<string?> links = HtmlDocument!.GetElementsByTagName("a").Select(a => a.GetAttribute("href"));
        var selectLinks = SelectLinks(links!, configuration);

        var newLinks = await _infoURLProvider.GetLinksNotStoredByDBAsync(configuration.ParserId, selectLinks!);
        return newLinks.Select(x =>
        new InfoURL()
        {
            ParserId = configuration.ParserId,
            Url = x
        });
    }

    /// <summary>
    /// Отобрать ссылки (убрать все лишнее).
    /// </summary>
    /// <param name="links">Список ссылок.</param>
    /// <param name="configuration">Конфигурация парсера.</param>
    /// <returns>Список ссылок.</returns>
    private static IEnumerable<string> SelectLinks(IEnumerable<string?> links, ConfigurationParser configuration)
    {
        return (IEnumerable<string>)links.Where(url =>
        {
            if (url == null) return false;
            else if (string.IsNullOrWhiteSpace(url)) return false;
            else if (!url.Contains(configuration.URL, StringComparison.OrdinalIgnoreCase)) return false;
            else if (configuration.ComparatorLink != null)
            {
                if (configuration.ComparatorLink
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Any(x => string.IsNullOrWhiteSpace(x) || url.Contains(x, StringComparison.OrdinalIgnoreCase))) return false;
            }

            try
            {
                var address = new Uri(url);
                if (!Uri.CheckSchemeName(address.Scheme)) return false;
                else if (address.Scheme == Uri.UriSchemeFile) return false;
                else if (address.Scheme == Uri.UriSchemeMailto) return false;
                else if (address.Scheme == Uri.UriSchemeFtp) return false;
                else if (address.Scheme == Uri.UriSchemeFtps) return false;
                else if (address.Scheme == Uri.UriSchemeGopher) return false;
                else if (address.Scheme == Uri.UriSchemeNetPipe) return false;
                else if (address.Scheme == Uri.UriSchemeNetTcp) return false;
                else if (address.Scheme == Uri.UriSchemeNews) return false;
                else if (address.Scheme == Uri.UriSchemeNntp) return false;
                else if (address.Scheme == Uri.UriSchemeSftp) return false;
                else if (address.Scheme == Uri.UriSchemeSsh) return false;
                else if (address.Scheme == Uri.UriSchemeTelnet) return false;
                else if (address.Scheme == Uri.UriSchemeWs) return false;
                else if (address.Scheme == Uri.UriSchemeWss) return false;
                else if (address.Scheme != Uri.UriSchemeHttps && address.Scheme != Uri.UriSchemeHttp) return false;
                else return true;
            }
            catch
            {
                return false;
            }
        }).Distinct();
    }

    #endregion

    /// <summary>
    /// Очистка объектов
    /// </summary>
    private void Clear()
    {
        if (HtmlDocument != null) HtmlDocument.Dispose();
    }

    ~ParserPage() => Clear();
}