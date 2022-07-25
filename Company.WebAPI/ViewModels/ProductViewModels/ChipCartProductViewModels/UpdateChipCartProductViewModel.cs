using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Company.WebAPI.ViewModels.ProductViewModels.ChipCartProductViewModels;

#nullable disable

public class UpdateChipCartProductViewModel : IValidatableObject
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

    [JsonProperty(PropertyName = "price")]
    public decimal Price { get; set; }

    [JsonProperty(PropertyName = "availability")]
    public string Availability { get; set; }

    [JsonProperty(PropertyName = "availability_type")]
    public string AvailabilityType { get; set; }

    [JsonProperty(PropertyName = "weight")]
    public string Weight { get; set; }

    [JsonProperty(PropertyName = "vendor")]
    public string Vendor { get; set; }

    [JsonProperty(PropertyName = "code_product")]
    public string CodeProduct { get; set; }

    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; }

    [JsonProperty(PropertyName = "color")]
    public string Color { get; set; }

    [JsonProperty(PropertyName = "printer_compatibility")]
    public string PrinterCompatibility { get; set; }

    [JsonProperty(PropertyName = "cartridge_compatibility")]
    public string CartridgeCompatibility { get; set; }

    [JsonProperty(PropertyName = "product_type")]
    public string TypeProduct { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        throw new NotImplementedException();
    }
}

#nullable enable