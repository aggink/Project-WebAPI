using Company.Base.Entities;
using Company.Parser.ViewModels.ConfigurationParserViewModels;

namespace Company.Parser.ViewModels.ParserViewModels;

/// <summary>
/// Сведения о парсинге
/// </summary>
public class ParserViewModel : IPrimaryKey
{
    public Guid Id { get; set; }

    public bool IsStarted { get; set; }

    public bool IsStartUpdate { get; set; }

    public bool IsQueue { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime CompletionTime { get; set; }

    public string? ExceptionMessage { get; set; }

    public IEnumerable<ConfigurationParserViewModel>? Configurations { get; set; }
}