using Company.Base.Entities;

namespace Company.Parser.ViewModels.URLViewModels;

public class UpdateURLViewModel : IPrimaryKey
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
}