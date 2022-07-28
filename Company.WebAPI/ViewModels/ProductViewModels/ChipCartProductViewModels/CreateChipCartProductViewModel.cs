using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Company.WebAPI.ViewModels.ProductViewModels.ChipCartProductViewModels;

#nullable disable

public class CreateChipCartProductViewModel : IValidatableObject
{
    [Required]
    [JsonProperty(PropertyName = "property_parser_id")]
    [JsonPropertyName("property_parser_id")]
    public Guid PropertyParserId { get; set; }

    [Required]
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

    [JsonProperty(PropertyName = "price")]
    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonProperty(PropertyName = "availability")]
    [JsonPropertyName("availability")]
    public string Availability { get; set; }

    [JsonProperty(PropertyName = "availability_type")]
    [JsonPropertyName("availability_type")]
    public string AvailabilityType { get; set; }

    [JsonProperty(PropertyName = "weight")]
    [JsonPropertyName("weight")]
    public string Weight { get; set; }

    [JsonProperty(PropertyName = "vendor")]
    [JsonPropertyName("vendor")]
    public string Vendor { get; set; }

    [JsonProperty(PropertyName = "code_product")]
    [JsonPropertyName("code_product")]
    public string CodeProduct { get; set; }

    [JsonProperty(PropertyName = "description")]
    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonProperty(PropertyName = "color")]
    [JsonPropertyName("color")]
    public string Color { get; set; }

    [JsonProperty(PropertyName = "printer_compatibility")]
    [JsonPropertyName("printer_compatibility")]
    public string PrinterCompatibility { get; set; }

    [JsonProperty(PropertyName = "cartridge_compatibility")]
    [JsonPropertyName("cartridge_compatibility")]
    public string CartridgeCompatibility { get; set; }

    [JsonProperty(PropertyName = "product_type")]
    [JsonPropertyName("product_type")]
    public string TypeProduct { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        throw new NotImplementedException();
    }
}

#nullable enable