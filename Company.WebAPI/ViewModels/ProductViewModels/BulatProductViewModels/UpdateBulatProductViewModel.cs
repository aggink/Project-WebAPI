using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Company.WebAPI.ViewModels.ProductViewModels.BulatProductViewModels;

#nullable disable

public class UpdateBulatProductViewModel : IValidatableObject
{
    [Required]
    [JsonProperty(PropertyName = "id")]
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

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

    [JsonProperty(PropertyName = "price")]
    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonProperty(PropertyName = "availability")]
    [JsonPropertyName("availability")]
    public string Availability { get; set; }

    [JsonProperty(PropertyName = "availability_type")]
    [JsonPropertyName("availability_type")]
    public string AvailabilityType { get; set; }

    [JsonProperty(PropertyName = "color")]
    [JsonPropertyName("color")]
    public string Color { get; set; }

    [JsonProperty(PropertyName = "compatibility")]
    [JsonPropertyName("compatibility")]
    public string Compatibility { get; set; }

    [JsonProperty(PropertyName = "length_width_height")]
    [JsonPropertyName("length_width_height")]
    public string LengthWidthHeight { get; set; }

    [JsonProperty(PropertyName = "model")]
    [JsonPropertyName("model")]
    public string Model { get; set; }

    [JsonProperty(PropertyName = "analog_product")]
    [JsonPropertyName("analog_product")]
    public string AnalogProduct { get; set; }

    [JsonProperty(PropertyName = "resource")]
    [JsonPropertyName("resource")]
    public double Resource { get; set; }

    [JsonProperty(PropertyName = "product_type")]
    [JsonPropertyName("product_type")]
    public string TypeProduct { get; set; }

    [JsonProperty(PropertyName = "equipment_type")]
    [JsonPropertyName("equipment_type")]
    public string TypeEquipment { get; set; }

    [JsonProperty(PropertyName = "originally_product")]
    [JsonPropertyName("originally_product")]
    public string OriginallyProduct { get; set; }

    [JsonProperty(PropertyName = "series_product")]
    [JsonPropertyName("series_product")]
    public string SeriesProduct { get; set; }

    [JsonProperty(PropertyName = "price_from5")]
    [JsonPropertyName("price_from5")]
    public decimal PriceFrom5 { get; set; }

    [JsonProperty(PropertyName = "price_from10")]
    [JsonPropertyName("price_from10")]
    public decimal PriceFrom10 { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        throw new NotImplementedException();
    }
}

#nullable enable