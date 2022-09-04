using Company.Base.Entities;
using Company.Parser.Entities.Interfaces;

namespace Company.Parser.Entities;

/// <summary>
/// Конфигурация парсера парсера
/// </summary>
public class ConfigurationParser : Auditable, IParser
{
    /// <summary>
    /// Индентификатор парсера
    /// </summary>
    public Guid ParserId { get; set; }

    /// <summary>
    /// Ссылка на ресурс
    /// </summary>
    public string URL { get; set; } = null!;

    /// <summary>
    /// Название веб-сайта
    /// </summary>
    public string SiteName { get; set; } = null!;

    /// <summary>
    /// Название компании
    /// </summary>
    public string CompanyName { get; set; } = null!;

    /// <summary>
    /// Описание компании
    /// </summary>
    public string CompanyDescription { get; set; } = null!;

    /// <summary>
    /// Не обрабатывать ссылки с данными значениями
    /// </summary>
    public string? ComparatorLink { get; set; }

    /// <summary>
    /// Параметры парсинга
    /// </summary>
    public virtual ICollection<FieldConfiguration> Fields { get; set; } = null!;

    /// <summary>
    /// Информация о парсере
    /// </summary>
    public virtual InfoParser? Parser { get; set; } = null!;
}