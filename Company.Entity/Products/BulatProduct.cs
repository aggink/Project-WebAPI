using Company.Entity.Base;

namespace Company.Entity.Products;

#nullable disable
public class BulatProduct : Auditable, IProduct, IPropertyParserId
{
    public Guid PropertyParserId { get; set; }
    public string URL { get; set; }

    public string Name { get; set; }

    public string Manufacturer { get; set; }

    public string Article { get; set; }

    public string Weight { get; set; }

    public string Vendor { get; set; }

    public string CodeProduct { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public string Availability { get; set; }

    public string AvailabilityType { get; set; }

    public string Color { get; set; }

    /// <summary>
    /// Совместимость/модель принтера
    /// </summary>
    public string Compatibility { get; set; }

    /// <summary>
    /// Длина/Ширина/Высота
    /// </summary>
    public string LengthWidthHeight { get; set; }

    /// <summary>
    /// Модель
    /// </summary>
    public string Model { get; set; }

    /// <summary>
    /// Аналог продукта
    /// </summary>
    public string AnalogProduct { get; set; }

    /// <summary>
    /// Ресурс стр.
    /// </summary>
    public double Resource { get; set; }

    /// <summary>
    /// Тип товара
    /// </summary>
    public string TypeProduct { get; set; }

    /// <summary>
    /// Тип оргтехники
    /// </summary>
    public string TypeEquipment { get; set; }

    /// <summary>
    /// Оригинальность расходника
    /// </summary>
    public string OriginallyProduct { get; set; }

    /// <summary>
    /// Серия продукта
    /// </summary>
    public string SeriesProduct { get; set; }

    /// <summary>
    /// Цена от 5 шт
    /// </summary>
    public decimal PriceFrom5 { get; set; }

    /// <summary>
    /// Цена от 10 шт
    /// </summary>
    public decimal PriceFrom10 { get; set; }
}

#nullable enable
