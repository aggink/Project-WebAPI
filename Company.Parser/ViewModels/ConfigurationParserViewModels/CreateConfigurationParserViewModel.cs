using Company.Parser.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Company.Parser.ViewModels.ConfigurationParserViewModels;

public class CreateConfigurationParserViewModel : IValidatableObject
{
    [Required]
    public Guid ParserId { get; set; }

    [Required]
    public string URL { get; set; } = null!;

    [Required]
    public string SiteName { get; set; } = null!;

    [Required]
    public string CompanyName { get; set; } = null!;

    [Required]
    public string CompanyDescription { get; set; } = null!;

    public string? ComparatorLink { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        List<ValidationResult> errors = new();

        if (string.IsNullOrWhiteSpace(URL) || !ValidatorExtension.CheckURLValid(URL))
        {
            errors.Add(new ValidationResult("Invalid URL.", new[] { nameof(URL) }));
        }
        if (ComparatorLink != null && !String.IsNullOrWhiteSpace(ComparatorLink))
        {
            ComparatorLink = Regex.Replace(ComparatorLink, @"\s+", " ");
        }

        return errors;
    }
}