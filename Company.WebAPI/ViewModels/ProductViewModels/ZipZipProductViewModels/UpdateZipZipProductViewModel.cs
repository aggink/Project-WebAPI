using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Company.WebAPI.ViewModels.ProductViewModels.ZipZipProductViewModels;

#nullable disable

public class UpdateZipZipProductViewModel : IValidatableObject
{
    [Required]
    [JsonProperty(PropertyName = "id")]
    public Guid Id { get; set; }

    [Required]
    [JsonProperty(PropertyName = "property_parser_id")]
    public Guid PropertyParserId { get; set; }

    [Required]
    [JsonProperty(PropertyName = "url")]
    public string URL { get; set; }

    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    [JsonProperty(PropertyName = "manufacturer")]
    public string Manufacturer { get; set; }

    [JsonProperty(PropertyName = "article")]
    public string Article { get; set; }

    [JsonProperty(PropertyName = "compatibility")]
    public string Compatibility { get; set; }

    [JsonProperty(PropertyName = "availability")]
    public string Availability { get; set; }

    [JsonProperty(PropertyName = "availability_type")]
    public string AvailabilityType { get; set; }

    [JsonProperty(PropertyName = "price")]
    public decimal Price { get; set; }

    [JsonProperty(PropertyName = "originally_product")]
    public string OriginallyProduct { get; set; }

    [JsonProperty(PropertyName = "category")]
    public string Category { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        throw new NotImplementedException();
    }
}

#nullable enable