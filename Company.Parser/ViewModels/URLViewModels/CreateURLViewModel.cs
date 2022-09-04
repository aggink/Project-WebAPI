namespace Company.Parser.ViewModels.URLViewModels;

public class CreateURLViewModel
{
    /// <summary>
    /// Индентификатор парсера.
    /// </summary>
    public Guid ParserId { get; set; }

    /// <summary>
    /// URL-адрес.
    /// </summary>
    public string Url { get; set; } = null!;
}