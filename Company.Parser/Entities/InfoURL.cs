using Company.Base.Entities;
using Company.Parser.Entities.Interfaces;

namespace Company.Parser.Entities;

/// <summary>
/// Сведения о url-адресе.
/// </summary>
public class InfoURL : Auditable, IParser
{
    /// <summary>
    /// Индентификатор парсера.
    /// </summary>
    public Guid ParserId { get; set; }

    /// <summary>
    /// URL-адрес.
    /// </summary>
    public string Url { get; set; } = null!;

    /// <summary>
    /// Был ли адрес обработан?
    /// </summary>
    /// <value>True - адрес был обработан. False - адрес ожидает обработки.</value>
    public bool HasBeenProcessed { get; set; }

    /// <summary>
    /// Упешно ли завершилось считывание?
    /// </summary>
    /// <value>True - чтение завершилось успешно. False - чтение завершилось провалом.</value>
    public bool IsSuccess { get; set; }

    /// <summary>
    /// Время обработки ссылки.
    /// </summary>
    public int ElapsedMilliseconds { get; set; }

    /// <summary>
    /// Сообщение об ошибке
    /// </summary>
    public string? ExceptionMessage { get; set; }

    /// <summary>
    /// Данные парсера.
    /// </summary>
    public virtual InfoParser? Parser { get; set; }
}