namespace Company.WebAPI.Infrastructure.Enums;

/// <summary>
/// Варианты сортировки
/// </summary>
public enum SortEnum
{
    /// <summary>
    /// Не задано
    /// </summary>
    None,

    /// <summary>
    /// Сортировка в порядке возрастания
    /// </summary>
    OrderBy,

    /// <summary>
    /// Сортировка в порядке убывания
    /// </summary>
    OrderByDescending
}