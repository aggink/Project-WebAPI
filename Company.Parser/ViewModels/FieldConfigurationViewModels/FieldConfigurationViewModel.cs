using Company.Base.Entities;

namespace Company.Parser.ViewModels.FieldConfigurationViewModels;

public class FieldConfigurationViewModel : IPrimaryKey
{
    public Guid Id { get; set; }

    public Guid ConfigurationId { get; set; }

    public string PropertyName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string StringParse { get; set; } = null!;
}