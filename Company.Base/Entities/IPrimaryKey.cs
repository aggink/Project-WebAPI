namespace Company.Base.Entities;

/// <summary>
/// Интерфейс определяющий первичный ключ
/// </summary>
public interface IPrimaryKey
{
    /// <summary>
    /// Первичный ключ
    /// </summary>
    Guid Id { get; set; }
}