namespace Company.Parser.Extensions.HtmlLoader;

public interface IHtmlLoader
{
    /// <summary>
    /// Получить HTML страницу
    /// </summary>
    /// <param name="url">URL адрес веб-страницы</param>
    /// <returns>Текст с веб-страницы</returns>
    Task<string> GetSourceByPageAsync(string url);
}