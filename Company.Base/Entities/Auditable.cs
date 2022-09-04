namespace Company.Base.Entities;

/// <summary>
/// Абстрактный класс с базовыми свойствами
/// </summary>
public abstract class Auditable : IAuditable
{
    /// <summary>
    /// Первичный ключ
    /// </summary>
    public Guid Id { get; set; } = default!;

    /// <summary>
    /// Время создания
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Уникальное имя создавшего
    /// </summary>
    public string CreatedBy { get; set; } = null!;

    /// <summary>
    /// Время обновления
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Уникальное имя обновлявшего
    /// </summary>
    public string UpdatedBy { get; set; } = null!;
}
