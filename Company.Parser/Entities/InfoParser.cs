using Company.Base.Entities;
using Company.Parser.Entities.Interfaces;

namespace Company.Parser.Entities;

/// <summary>
/// Данные о парсере
/// </summary>
public class InfoParser : Auditable, IParser
{
    /// <summary>
    /// Начать парсинг веб-сайта
    /// </summary>
    public bool IsStart { get; set; }

    /// <summary>
    /// Находится ли в очереди на парсинг?
    /// </summary>
    public bool IsQueue { get; set; }

    /// <summary>
    /// Завершенин ли парсинг!?
    /// </summary>
    public bool IsCompleted { get; set; }

    /// <summary>
    /// Запустить обновление
    /// </summary>
    public bool IsStartUpdate { get; set; }

    /// <summary>
    /// Время начала
    /// </summary>
    public DateTime StartTime { get; set; }

    /// <summary>
    /// Время завершения
    /// </summary>
    public DateTime CompletionTime { get; set; }

    /// <summary>
    /// Сообщение об ошибке
    /// </summary>
    public string? ExceptionMessage { get; set; }

    /// <summary>
    /// Список настроек парсера
    /// </summary>
    public virtual ICollection<ConfigurationParser> Configurations { get; set; } = null!;
}