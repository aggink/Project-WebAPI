using Company.Base.Entities;

namespace Company.Parser.Entities.Base;

/// <summary>
/// 
/// </summary>
public abstract class ParserAuditable : Auditable, IParserAuditable
{
    /// <summary>
    /// Индентификатор информации о ссылки
    /// </summary>
    public Guid InfoURLId { get; set; }

    public InfoURL? InfoURL { get; set; }
}