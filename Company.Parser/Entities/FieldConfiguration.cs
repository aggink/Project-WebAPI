using Company.Base.Entities;
using Company.Parser.Entities.Interfaces;

namespace Company.Parser.Entities;

/// <summary>
/// Класс описывающий поле парсера
/// </summary>
public class FieldConfiguration : Auditable, IParser
{
    /// <summary>
    /// Индентификатор конфигурации парсера
    /// </summary>
    public Guid ConfigurationId { get; set; }

    /// <summary>
    /// Наименование свойства (куда положить данные)
    /// </summary>
    public string PropertyName { get; set; } = null!;

    /// <summary>
    /// Описание свойства
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// Значение по умолчанию
    /// </summary>
    //public string DefaultValue { get; set; } = null!;

    /// <summary>
    /// Параметры поиска (поиск нужной информации на веб-странице)
    /// </summary>
    public string StringParse { get; set; } = null!;

    /// <summary>
    /// Конфигурации парсера
    /// </summary>
    public virtual ConfigurationParser? Configuration { get; set; }
}