using Company.Base.Entities;
using System.ComponentModel.DataAnnotations;

namespace Company.WebAPI.ViewModels.ParseValuesProductViewModel;

/// <summary>
/// Сущность для обновления информации о товаре.
/// </summary>
public class UpdateParseValuesProductViewModel : IPrimaryKey
{
    /// <summary>
    /// Индентификатор
    /// </summary>
    [Required]
    public Guid Id { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Описание
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Текстовая информация (таблица для последующей обработки)
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    /// Цена
    /// </summary>
    public string? Price { get; set; }

    /// <summary>
    /// Цена
    /// </summary>
    public string? Price5 { get; set; }

    /// <summary>
    /// Цена
    /// </summary>
    public string? Price10 { get; set; }

    /// <summary>
    /// Налчие товара в офисе
    /// </summary>
    public string? AvailabilityProductOffice { get; set; }

    /// <summary>
    /// Наличие товара на складе
    /// </summary>
    public string? AvailabilityProductStock { get; set; }
}