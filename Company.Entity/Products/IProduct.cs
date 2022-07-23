namespace Company.Entity.Products;

/// <summary>
/// Расширенный список свойств подукции (основные + доп. свойства)
/// </summary>
public interface IProduct : IBaseProduct
{
    /// <summary>
    /// Вес
    /// </summary>
    public string Weight { get; set; }

    /// <summary>
    /// Для устройств марки ... / Вендор / OEM-Бренд
    /// </summary>
    public string Vendor { get; set; }

    /// <summary>
    /// Код товара/OEM Part Number / ОЕМ номер
    /// </summary>
    public string CodeProduct { get; set; }

    /// <summary>
    /// Описание продукта
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Цвет
    /// </summary>
    public string Color { get; set; }
}
