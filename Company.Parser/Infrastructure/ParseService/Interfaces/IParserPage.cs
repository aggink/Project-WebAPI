using Company.Parser.Entities;
using Company.Parser.Models.ParserBackgroundModels;

namespace Company.Parser.Infrastructure.ParseService.Interfaces;

/// <summary>
/// Интерфейс для работы с парсером страниц
/// </summary>
public interface IParserPage
{
    /// <summary>
    /// Обработка веб-страницы.
    /// </summary>
    /// <param name="parser">Данные парсера.</param>
    /// <param name="source">Загруженная веб-страница.</param>
    /// <returns>Объект со счтанными значениями с веб-страницы.</returns>
    Task<(Value, IEnumerable<InfoURL>)> ParseAsync(InfoParser parser, string source);
}