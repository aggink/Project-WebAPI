using Company.Base.Entities;

namespace Company.Parser.ViewModels.URLViewModels;

public class URLViewModel : IPrimaryKey
{
    public Guid Id { get; set; }

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
}