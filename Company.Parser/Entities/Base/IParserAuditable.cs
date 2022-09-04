namespace Company.Parser.Entities.Base;

/// <summary>
/// Индентификаторы информации о парсере
/// </summary>
public interface IParserAuditable
{
    /// <summary>
    /// Индентификатор информации о ссылки
    /// </summary>
    Guid InfoURLId { get; set; }
}