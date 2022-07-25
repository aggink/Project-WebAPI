using Newtonsoft.Json;

namespace Company.WebAPI.ViewModels.ProductViewModels.ZipZipProductViewModels;

#nullable disable

public class ZipZipProductViewModel
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
}

#nullable enable