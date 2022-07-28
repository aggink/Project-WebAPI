using Company.Entity.Products;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Company.WebAPI.ViewModels.ParserViewModels.PropertyParserViewModels;

#nullable disable

public class UpdatePropertyParserViewModel : IValidatableObject
{
    [Required]
    [JsonProperty(PropertyName = "id")]
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [Required]
    [JsonProperty(PropertyName = "url")]
    [JsonPropertyName("url")]
    public string URL { get; set; }

    [Required]
    [JsonProperty(PropertyName = "name_site")]
    [JsonPropertyName("name_site")]
    public string NameSite { get; set; }

    [Required]
    [JsonProperty(PropertyName = "company_name")]
    [JsonPropertyName("company_name")]
    public string CompanyName { get; set; }

    [Required]
    [JsonProperty(PropertyName = "company_description")]
    [JsonPropertyName("company_description")]
    public string CompanyDescription { get; set; }

    [Required]
    [JsonProperty(PropertyName = "type_name")]
    [JsonPropertyName("type_name")]
    public string TypeName { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        List<ValidationResult> errors = new();

        if(Id == Guid.Empty)
        {
            errors.Add(new ValidationResult("Не задано поле.", new[] { nameof(Id) }));
        }

        if (string.IsNullOrWhiteSpace(URL) || !CheckURLValid(URL))
        {
            errors.Add(new ValidationResult("Некорректный URL-адрес.", new[] { nameof(URL) }));
        }

        if (string.IsNullOrWhiteSpace(NameSite))
        {
            errors.Add(new ValidationResult("Не задано поле.", new[] { nameof(NameSite) }));
        }

        if (string.IsNullOrWhiteSpace(CompanyName))
        {
            errors.Add(new ValidationResult("Не задано поле.", new[] { nameof(NameSite) }));
        }

        if (string.IsNullOrWhiteSpace(CompanyDescription))
        {
            errors.Add(new ValidationResult("Не задано поле.", new[] { nameof(NameSite) }));
        }

        if (string.IsNullOrWhiteSpace(TypeName))
        {
            errors.Add(new ValidationResult("Не задано поле.", new[] { nameof(NameSite) }));
        }
        else if (!CheckTypeName(TypeName))
        {
            errors.Add(new ValidationResult("Значение поля не соответствует разрешенным значениям для данного поля.", new[] { nameof(TypeName) }));
        }

        return errors;
    }

    private bool CheckURLValid(string source)
    {
        try
        {
            if (Uri.TryCreate(source, UriKind.Absolute, out Uri uriResult) &&
                (uriResult.Scheme == Uri.UriSchemeHttps || uriResult.Scheme == Uri.UriSchemeHttp))
            {
                return true;
            }
        }
        catch { return false; }

        return false;
    }

    private bool CheckTypeName(string name)
    {
        List<string> nameClass = new()
        {
            nameof(BulatProduct),
            nameof(RamisProduct),
            nameof(ZipZipProduct),
            nameof(ChipCartProduct)
        };

        var result = nameClass.FirstOrDefault(x => x.Equals(name));
        if (result == null) return false;

        return true;
    }
}

#nullable enable