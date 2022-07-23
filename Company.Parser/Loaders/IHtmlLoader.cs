namespace Company.Parser.Loaders
{
    public interface IHtmlLoader
    {
        /// <summary>
        /// Получить HTML страницу
        /// </summary>
        /// <param name="url">URL адрес веб-страницы</param>
        /// <param name="predicate">Метод выборки url-страницы</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<string> GetSourceByPageAsync(string url);
    }
}