using Company.Entity.Base;

namespace Company.Entity.Parser;

#nullable disable

public class WorkParser : Auditable
{
    public Guid PropertyParserId { get; set; }

    /// <summary>
    /// Начать парсинг веб-сайта
    /// </summary>
    public bool IsStart { get; set; }

    /// <summary>
    /// Завершенин ли парсинг!?
    /// </summary>
    public bool IsCompleted { get; set; }

    /// <summary>
    /// Время начала
    /// </summary>
    public DateTime StartTime { get; set; }

    /// <summary>
    /// Время завершения
    /// </summary>
    public DateTime CompletionTime { get; set; }

    /// <summary>
    /// Свойства парсера
    /// </summary>
    public PropertyParser PropertyParser { get; set; }
}

#nullable enable