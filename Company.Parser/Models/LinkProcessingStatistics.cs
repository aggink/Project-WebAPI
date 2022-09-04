namespace Company.Parser.Models;

/// <summary>
/// Статистические данные об обработке ссылок.
/// </summary>
public class LinkProcessingStatistics
{
    /// <summary>
    /// Всего ссылок.
    /// </summary>
    public int TotalLinks { get; set; }

    /// <summary>
    /// Количество обработанных ссылок.
    /// </summary>
    public int TotalProcessedLinks { get; set; }

    /// <summary>
    /// Количество не обработанных ссылок.
    /// </summary>
    public int TotalUnProcessedLinks
    {
        get { return TotalLinks - TotalProcessedLinks; }
    }

    /// <summary>
    /// Количество ошибок при обработке ссылок.
    /// </summary>
    public int TotalLinkHandlingErrors { get; set; }

    /// <summary>
    /// Среднее время обработки одной ссылки.
    /// </summary>
    public decimal AverageLinkProcessingMilliseconds { get; set; }

    /// <summary>
    /// Минимальное время обработки одной ссылки в миллисекундах.
    /// </summary>
    public int MinLinkProcessingMilliseconds { get; set; }

    /// <summary>
    /// Максимальное время обработки одной ссылки в миллисекундах.
    /// </summary>
    public int MaxLinkProcessingMilliseconds { get; set; }
}