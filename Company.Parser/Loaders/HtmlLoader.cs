using Microsoft.Extensions.Logging;

namespace Company.Parser.Loaders
{
    /// <summary>
    /// Класс реализующий функции загрузки HTML страницы
    /// </summary>
    public class HtmlLoader : IHtmlLoader
    {
        private readonly HttpClient client;
        private readonly ILogger _logger;
        public HtmlLoader(ILogger<HtmlLoader> logger)
        {
            client = new HttpClient();
            _logger = logger;
        }

        /// <summary>
        /// Тип обработываемых страниц
        /// </summary>
        private readonly string ContentType = "html";

        public async Task<string> GetSourceByPageAsync(string url)
        {
            if(string.IsNullOrEmpty(url)) throw new ArgumentNullException(nameof(url));

            var response = await client.GetAsync(url);
            if(response != null && response.IsSuccessStatusCode)
            {
                if (!ContentType.Contains(ContentType, StringComparison.OrdinalIgnoreCase))
                    _logger.LogInformation($"Queued Hosted Service is stopping. URL: {url}");

                return await response.Content.ReadAsStringAsync();
            }

            throw new ArgumentNullException(nameof(response));
        }
    }
}