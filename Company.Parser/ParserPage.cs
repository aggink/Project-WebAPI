using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Company.Parser.Interfaces;
using System.Text.RegularExpressions;

namespace Company.Parser
{
    /// <summary>
    /// Базовый класс отвечающий за парсинг страниц
    /// </summary>
    public abstract class ParserPage<TParserPage, TParserProperty> : IParserPage<TParserPage, TParserProperty>
        where TParserPage : ParserPage<TParserPage, TParserProperty>
        where TParserProperty : class, IPropertyParser
    {
        #region Constructor

        /// <summary>
        /// Интерфейс парсера HTML
        /// </summary>
        protected IHtmlParser HtmlParser { get; private set; }

        /// <summary>
        /// Полученная веб-страница
        /// </summary>
        protected IHtmlDocument HtmlDocument { get; set; } = null!;
        protected CancellationToken CancellationToken { get; private set; }
        public ParserPage()
        {
            HtmlParser = new HtmlParser();
            CancellationToken = new CancellationToken();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Свойства парсера (данные для запуска парсера)
        /// </summary>
        protected TParserProperty ParserProperty = null!;

        #endregion

        #region Parse

        /// <summary>
        /// Реализация парсера одной веб-страницы
        /// </summary>
        /// <returns>Ссылки с веб-страницы</returns>
        protected abstract Task<IEnumerable<string?>> ParseAsync();

        public async Task<IEnumerable<string?>> ParseAsync(TParserProperty parseProperty, string sourse)
        {
            HtmlDocument = await HtmlParser.ParseDocumentAsync(sourse, CancellationToken);
            if (CancellationToken.IsCancellationRequested) throw new Exception(nameof(sourse));

            ParserProperty = parseProperty;

            return await ParseAsync();
        }

        #endregion

        /// <summary>
        /// Получить все ссылки с веб-страницы
        /// </summary>
        /// <returns>Список ссылок с веб-страницы</returns>
        protected IEnumerable<string?> GetAllTagLinks()
        {
            return HtmlDocument!.GetElementsByTagName("a").Select(a => a.GetAttribute("href"));
        }

        /// <summary>
        /// Удаление тегов, пробелов и тд из строки
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        protected string StripHTML(string inputString)
        {
            const string HTML_TAG_PATTERN = "<.*?>|\a|\b|\f|\n|\r|\t|\v";
            const string PATTERN = @"\s+";
            return Regex.Replace(Regex.Replace(inputString, HTML_TAG_PATTERN, @" "), PATTERN, @" ");
        }
    }
}