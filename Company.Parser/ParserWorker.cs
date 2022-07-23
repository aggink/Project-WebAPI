using Company.Parser.Interfaces;
using Company.Parser.Loaders;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Company.Parser
{
    public class ParserWorker<TParserPage, TParserProperty> : IParserWorker<TParserProperty>
        where TParserPage : ParserPage<TParserPage, TParserProperty>
        where TParserProperty : class, IPropertyParser
    {
        #region Constructor

        private readonly IHtmlLoader _htmlLoader;
        private readonly IParserPage<TParserPage, TParserProperty> _parserPage;
        private readonly ILogger<ParserWorker<TParserPage, TParserProperty>> _logger;
        public ParserWorker(
            IHtmlLoader htmlLoader, 
            IParserPage<TParserPage, TParserProperty> parserPage,
            ILogger<ParserWorker<TParserPage, TParserProperty>> logger)
        {
            _htmlLoader = htmlLoader;
            _parserPage = parserPage;
            _logger = logger;

        }

        #endregion

        #region Property - SleepTime

        private int sleepTime = 15000;
        /// <summary>
        /// Максимальное время ожидания между get запросами
        /// </summary>
        public int SleepTime
        {
            get
            {
                return sleepTime;
            }
            set
            {
                if (value < 0) sleepTime = 15000;
                else sleepTime = value;
            }
        }

        #endregion

        /// <summary>
        /// Url адреса для парсинга
        /// </summary>
        private readonly List<string?> WebPageUrls = new();

        public async void Worker(TParserProperty parserProperty)
        {
            WebPageUrls!.Clear();
            WebPageUrls.Add(parserProperty.URL);

            await ParseWebPage(parserProperty);
        }

        /// <summary>
        /// Парсинг веб-страниц
        /// </summary>
        /// <param name="_parserPage"></param>
        /// <returns></returns>
        private async Task ParseWebPage(TParserProperty parserProperty)
        {
            Stopwatch watch = new();

            for (int i = 0; i < WebPageUrls!.Count; i++)
            {
                try
                {
                    watch.Start();

                    var source = await _htmlLoader.GetSourceByPageAsync(WebPageUrls[i]!);
                    var urls = await _parserPage.ParseAsync(parserProperty, source);
                    if (urls != null)
                    {
                        var newUrls = urls.Where(x =>
                            !string.IsNullOrEmpty(x) &&
                            x.Contains(parserProperty.URL, StringComparison.OrdinalIgnoreCase) &&
                            WebPageUrls.FirstOrDefault(y => y != x) == null).ToList();

                        if (newUrls.Any()) WebPageUrls.AddRange(newUrls);
                    }

                }
                catch (Exception ex)
                {
                    _logger.LogError($"URL: {WebPageUrls[i]!}\n{ex.Message}");
                }
                finally
                {
                    watch.Stop();

                    int sleep = SleepTime - (int)watch.ElapsedMilliseconds;
                    if (sleep > 0) Thread.Sleep(sleep);

                    watch.Reset();
                }
            }
        }
    }
}