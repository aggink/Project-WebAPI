using Company.Base.Entities;
using System.ComponentModel.DataAnnotations;

namespace Company.WebAPI.ViewModels.ProductViewModels;

/// <summary>
/// Сущность для обновления информации о товаре.
/// </summary>
public class UpdateProductViewModel : IPrimaryKey
{
    /// <summary>
    /// Индентификатор
    /// </summary>
    [Required]
    public Guid Id { get; set; }

    #region Base

    /// <summary>
    /// Название товара
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Производитель/Марка
    /// </summary>
    public string? Manufacturer { get; set; }

    /// <summary>
    /// Артикул
    /// </summary>
    public string? Article { get; set; }

    /// <summary>
    /// Цена
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Наличие товара
    /// </summary>
    public string? Availability { get; set; }

    /// <summary>
    /// Статус наличия товара
    /// </summary>
    public string? AvailabilityType { get; set; }

    /// <summary>
    /// Вес
    /// </summary>
    public string? Weight { get; set; }

    /// <summary>
    /// Для устройств марки ... / Вендор / OEM-Бренд
    /// </summary>
    public string? Vendor { get; set; }

    /// <summary>
    /// Код товара/OEM Part Number / ОЕМ номер
    /// </summary>
    public string? CodeProduct { get; set; }

    /// <summary>
    /// Описание продукта
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Цвет
    /// </summary>
    public string? Color { get; set; }

    #endregion

    #region B

    /// <summary>
    /// Совместимость/модель принтера
    /// </summary>
    public string? Compatibility { get; set; }

    /// <summary>
    /// Длина/Ширина/Высота
    /// </summary>
    public string? LengthWidthHeight { get; set; }

    /// <summary>
    /// Модель
    /// </summary>
    public string? Model { get; set; }

    /// <summary>
    /// Аналог продукта
    /// </summary>
    public string? AnalogProduct { get; set; }

    /// <summary>
    /// Ресурс стр.
    /// </summary>
    public double Resource { get; set; }

    /// <summary>
    /// Тип товара
    /// </summary>
    public string? TypeProduct { get; set; }

    /// <summary>
    /// Тип оргтехники
    /// </summary>
    public string? TypeEquipment { get; set; }

    /// <summary>
    /// Оригинальность расходника
    /// </summary>
    public string? OriginallyProduct { get; set; }

    /// <summary>
    /// Серия продукта
    /// </summary>
    public string? SeriesProduct { get; set; }

    /// <summary>
    /// Цена от 5 шт
    /// </summary>
    public decimal PriceFrom5 { get; set; }

    /// <summary>
    /// Цена от 10 шт
    /// </summary>
    public decimal PriceFrom10 { get; set; }

    /// <summary>
    /// Код ТН ВЭД
    /// </summary>
    public string? CodeTN { get; set; }

    #endregion

    #region C

    /// <summary>
    /// Принтеры номенклатуры
    /// </summary>
    public string? PrinterCompatibility { get; set; }

    /// <summary>
    /// Картриджи номенклатуры
    /// </summary>
    public string? CartridgeCompatibility { get; set; }

    #endregion

    #region R

    /// <summary>
    /// Количество в упаковке
    /// </summary>
    public int QuantityPackage { get; set; }

    /// <summary>
    /// Торговая марка и P/N:
    /// </summary>
    public string? TrademarkAndPN { get; set; }

    #endregion

    #region Z

    /// <summary>
    /// Узел/Категория
    /// </summary>
    public string? Category { get; set; }

    #endregion
}