using Newtonsoft.Json;

namespace Company.WebAPI.ViewModels.ProductViewModels.RamisProductViewModels;

#nullable disable

public class RamisProductViewModel
{
    [JsonProperty(PropertyName = "id")]
    public Guid Id { get; set; }

    [JsonProperty(PropertyName = "property_parser_id")]
    public Guid PropertyParserId { get; set; }

    [JsonProperty(PropertyName = "url")]
    public string URL { get; set; }

    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    [JsonProperty(PropertyName = "manufacturer")]
    public string Manufacturer { get; set; }

    [JsonProperty(PropertyName = "article")]
    public string Article { get; set; }

    [JsonProperty(PropertyName = "weight")]
    public string Weight { get; set; }

    [JsonProperty(PropertyName = "vendor")]
    public string Vendor { get; set; }

    [JsonProperty(PropertyName = "code_product")]
    public string CodeProduct { get; set; }

    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; }

    [JsonProperty(PropertyName = "price")]
    public decimal Price { get; set; }

    [JsonProperty(PropertyName = "availability")]
    public string Availability { get; set; }

    [JsonProperty(PropertyName = "availability_type")]
    public string AvailabilityType { get; set; }

    [JsonProperty(PropertyName = "color")]
    public string Color { get; set; }

    [JsonProperty(PropertyName = "printer_compatibility")]
    public string PrinterCompatibility { get; set; }

    [JsonProperty(PropertyName = "cartridge_compatibility")]
    public string CartridgeCompatibility { get; set; }

    [JsonProperty(PropertyName = "quantity_package")]
    public int QuantityPackage { get; set; }

    [JsonProperty(PropertyName = "trademark_and_pn")]
    public string TrademarkAndPN { get; set; }
}

#nullable enable