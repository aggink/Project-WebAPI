using Company.Base.Entities;
using Company.Parser.ViewModels.FieldConfigurationViewModels;

namespace Company.Parser.ViewModels.ConfigurationParserViewModels;

public class ConfigurationParserViewModel : IPrimaryKey
{
    public Guid Id { get; set; }

    public Guid ParserId { get; set; }

    public string URL { get; set; } = null!;

    public string SiteName { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string CompanyDescription { get; set; } = null!;

    public string? ComparatorLink { get; set; }

    public IEnumerable<FieldConfigurationViewModel>? Fields { get; set; }
}