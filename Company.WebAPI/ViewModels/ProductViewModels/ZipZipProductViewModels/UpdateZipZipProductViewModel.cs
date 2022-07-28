using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Company.WebAPI.ViewModels.ProductViewModels.ZipZipProductViewModels;

#nullable disable

public class UpdateZipZipProductViewModel : IValidatableObject
{
    [Required]
    [JsonProperty(PropertyName = "id")]
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [Required]
    [JsonProperty(PropertyName = "property_parser_id")]
    [JsonPropertyName("property_parser_id")]
    public Guid PropertyParserId { get; set; }

    [JsonProperty(PropertyName = "url")]
    [JsonPropertyName("url")]
    public string URL { get; set; }

    [JsonProperty(PropertyName = "name")]
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonProperty(PropertyName = "manufacturer")]
    [JsonPropertyName("manufacturer")]
    public string Manufacturer { get; set; }

    [JsonProperty(PropertyName = "article")]
    [JsonPropertyName("article")]
    public string Article { get; set; }

    [JsonProperty(PropertyName = "compatibility")]
    [JsonPropertyName("compatibility")]
    public string Compatibility { get; set; }

    [JsonProperty(PropertyName = "availability")]
    [JsonPropertyName("availability")]
    public string Availability { get; set; }

    [JsonProperty(PropertyName = "availability_type")]
    [JsonPropertyName("availability_type")]
    public string AvailabilityType { get; set; }

    [JsonProperty(PropertyName = "price")]
    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonProperty(PropertyName = "originally_product")]
    [JsonPropertyName("originally_product")]
    public string OriginallyProduct { get; set; }

    [JsonProperty(PropertyName = "category")]
    [JsonPropertyName("category")]
    public string Category { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        throw new NotImplementedException();
    }
}

#nullable enable