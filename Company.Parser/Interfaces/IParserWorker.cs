namespace Company.Parser.Interfaces;

public interface IParserWorker<TParserProperty>
{
    /// <summary>
    /// Запуск парсера для разных рекламных платформ
    /// </summary>
    /// <param name="parserProperty">Настройки для парсинга веб-страницы</param>
    void Worker(TParserProperty parserProperty);
}
