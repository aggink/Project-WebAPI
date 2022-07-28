﻿using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Company.WebAPI.ViewModels.ProductViewModels.ZipZipProductViewModels;

#nullable disable

public class ZipZipProductViewModel
{
    [JsonProperty(PropertyName = "id")]
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

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
}

#nullable enable