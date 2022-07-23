using Company.Entity.Base;
using Company.Parser.Interfaces;

namespace Company.Entity.Parser;

#nullable disable

/// <summary>
/// Настройка парсера
/// </summary>
public class PropertyParser : ForeignKeyUser, IPropertyParser
{
    public string URL { get; set; }

    /// <summary>
    /// Название веб-сайта
    /// </summary>
    public string NameSite { get; set; }

    /// <summary>
    /// Название компании
    /// </summary>
    public string CompanyName { get; set; }

    /// <summary>
    /// Описание компании
    /// </summary>
    public string CompanyDescription { get; set; }

    /// <summary>
    /// Название класса для парсинга
    /// </summary>
    public string TypeName { get; set; }

    /// <summary>
    /// Параметры парсинга
    /// </summary>
    public ICollection<FieldParser> ParserParams { get; set; }
}

#nullable enable
