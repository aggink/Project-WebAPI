namespace Company.Base.Entities;

/// <summary>
/// Интерфейс предоставляющий набор базовых полей
/// </summary>
public interface IAuditable : IPrimaryKey
{
    /// <summary>
    /// Время создания
    /// </summary>
    DateTime CreatedAt { get; set; }

    /// <summary>
    /// Уникальное имя создавшего
    /// </summary>
    string CreatedBy { get; set; }

    /// <summary>
    /// Время обновления
    /// </summary>
    DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Уникальное имя обновлявшего
    /// </summary>
    string UpdatedBy { get; set; }
}
