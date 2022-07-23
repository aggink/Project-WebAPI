namespace Company.Parser.Interfaces
{
    public interface IParserPage<TParserPage, TParserProperty>
        where TParserPage : ParserPage<TParserPage, TParserProperty>
        where TParserProperty : class, IPropertyParser
    {
        /// <summary>
        /// Обработка веб-страницы
        /// </summary>
        /// <param name="parseProperty">Правила обработки веб-страницы</param>
        /// <param name="sourse">Загруженная веб-страница</param>
        /// <returns>Ссылки на веб-странице</returns>
        Task<IEnumerable<string?>> ParseAsync(TParserProperty parseProperty, string sourse);
    }
}