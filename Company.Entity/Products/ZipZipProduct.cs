using Company.Entity.Base;

namespace Company.Entity.Products;

#nullable disable

public class ZipZipProduct : Auditable, IBaseProduct, IPropertyParserId
{
    public Guid PropertyParserId { get; set; }
    public string URL { get; set; }
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public string Article { get; set; }
    public string Compatibility { get; set; }
    public string Availability { get; set; }
    public string AvailabilityType { get; set; }

    public decimal Price { get; set; }

    /// <summary>
    /// Оригинальность расходника
    /// </summary>
    public string OriginallyProduct { get; set; }

    /// <summary>
    /// Узел/Категория
    /// </summary>
    public string Category { get; set; }
}

#nullable enable
