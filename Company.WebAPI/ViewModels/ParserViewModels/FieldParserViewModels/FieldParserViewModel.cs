using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Company.WebAPI.ViewModels.ParserViewModels.FieldParserViewModels;

#nullable disable
public class FieldParserViewModel
{
    [JsonProperty(PropertyName = "id")]
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonProperty(PropertyName = "property_parser_id")]
    [JsonPropertyName("property_parser_id")]
    public Guid PropertyParserId { get; set; }

    [JsonProperty(PropertyName = "property_name")]
    [JsonPropertyName("property_name")]
    public string PropertyName { get; set; }

    [JsonProperty(PropertyName = "default_value")]
    [JsonPropertyName("default_value")]
    public string DefaultValue { get; set; }

    [JsonProperty(PropertyName = "string_parse")]
    [JsonPropertyName("string_parse")]
    public string StringParse { get; set; }
}

#nullable enable