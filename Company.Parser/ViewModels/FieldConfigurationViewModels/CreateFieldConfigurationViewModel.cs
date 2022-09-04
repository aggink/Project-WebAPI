using System.ComponentModel.DataAnnotations;

namespace Company.Parser.ViewModels.FieldConfigurationViewModels;

public class CreateFieldConfigurationViewModel
{
    [Required]
    public Guid ConfigurationId { get; set; }

    [Required]
    public string PropertyName { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public string StringParse { get; set; } = null!;
}