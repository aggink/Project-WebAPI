using Company.Entity.Base;

namespace Company.Entity.Parser;

#nullable disable

/// <summary>
/// Класс описывающий поле парсера
/// </summary>
public class FieldParser : Auditable
{
    public Guid PropertyParserId { get; set; }

    /// <summary>
    /// Наименование свойства (куда положить данные)
    /// </summary>
    public string PropertyName { get; set; }

    /// <summary>
    /// Значение по умолчанию
    /// </summary>
    public string DefaultValue { get; set; }

    /// <summary>
    /// Параметры поиска (поиск нужной информации на веб-странице)
    /// </summary>
    public string StringParse { get; set; }
}

#nullable enable
