namespace Company.Entity.Products;

/// <summary>
/// Основные свойства продукции
/// </summary>
public interface IBaseProduct
{
    /// <summary>
    /// Адрес веб-страницы
    /// </summary>
    public string URL { get; set; }

    /// <summary>
    /// Название товара
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Производитель/Марка
    /// </summary>
    public string Manufacturer { get; set; }

    /// <summary>
    /// Артикул
    /// </summary>
    public string Article { get; set; }

    /// <summary>
    /// Цена
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Наличие товара
    /// </summary>
    public string Availability { get; set; }

    /// <summary>
    /// Статус наличия товара
    /// </summary>
    public string AvailabilityType { get; set; }
}
