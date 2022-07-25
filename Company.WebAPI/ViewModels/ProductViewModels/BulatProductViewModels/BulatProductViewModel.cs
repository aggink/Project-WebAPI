using Newtonsoft.Json;

namespace Company.WebAPI.ViewModels.ProductViewModels.BulatProductViewModels;

#nullable disable

public class BulatProductViewModel
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

    [JsonProperty(PropertyName = "compatibility")]
    public string Compatibility { get; set; }

    [JsonProperty(PropertyName = "length_width_height")]
    public string LengthWidthHeight { get; set; }

    [JsonProperty(PropertyName = "model")]
    public string Model { get; set; }

    [JsonProperty(PropertyName = "analog_product")]
    public string AnalogProduct { get; set; }

    [JsonProperty(PropertyName = "resource")]
    public double Resource { get; set; }

    [JsonProperty(PropertyName = "product_type")]
    public string TypeProduct { get; set; }

    [JsonProperty(PropertyName = "equipment_type")]
    public string TypeEquipment { get; set; }

    [JsonProperty(PropertyName = "originally_product")]
    public string OriginallyProduct { get; set; }

    [JsonProperty(PropertyName = "series_product")]
    public string SeriesProduct { get; set; }

    [JsonProperty(PropertyName = "price_from5")]
    public decimal PriceFrom5 { get; set; }

    [JsonProperty(PropertyName = "price_from10")]
    public decimal PriceFrom10 { get; set; }
}

#nullable enable