namespace Company.Entity;

/// <summary>
/// Типы валидации для методов CRUD
/// </summary>
public enum TypeValidation
{
    /// <summary>
    /// Required by naming conventions
    /// </summary>
    None,

    /// <summary>
    /// Создание
    /// </summary>
    Create,

    /// <summary>
    /// Обновление
    /// </summary>
    Update,

    /// <summary>
    /// Удаление
    /// </summary>
    Delete
}
