using Company.Base.Entities;
using System.ComponentModel.DataAnnotations;

namespace Company.Parser.ViewModels.FieldConfigurationViewModels;

public class UpdateFieldConfigurationViewModel : IPrimaryKey
{

    [Required]
    public Guid Id { get; set; }

    [Required]
    public Guid ConfigurationId { get; set; }

    [Required]
    public string PropertyName { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public string StringParse { get; set; } = null!;
}