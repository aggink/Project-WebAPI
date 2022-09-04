using Microsoft.Extensions.Logging;

namespace Company.Parser.Extensions.HtmlLoader;

/// <summary>
/// Класс реализующий функции загрузки HTML страницы
/// </summary>
public class HtmlLoader : IHtmlLoader
{
    private readonly HttpClient client;
    private readonly ILogger<HtmlLoader> _logger;

    public HtmlLoader(ILogger<HtmlLoader> logger)
    {
        client = new HttpClient();
        _logger = logger;
    }

    public async Task<string> GetSourceByPageAsync(string url)
    {
        if (string.IsNullOrWhiteSpace(url)) throw new Exception($"URL not set. {nameof(url)} has the value of null or empty.");

        var response = await client.GetAsync(url);
        if (response == null) throw new Exception("The response is not received.");
        else if (!response.IsSuccessStatusCode) throw new Exception($"StatusCode: {response.StatusCode}, ReasonPhrase: {response.ReasonPhrase}.");
        else return await response.Content.ReadAsStringAsync();
    }

    ~HtmlLoader()
    {
        client.Dispose();
    }
}