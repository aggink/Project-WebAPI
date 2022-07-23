using System.Text.Json.Serialization;

namespace Company.WPF.Models.ParserModels;

#nullable disable

public class FieldParser
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("property_parser_id")]
    public Guid PropertyParserId { get; set; }

    [JsonPropertyName("property_name")]
    public string NameProperty { get; set; }

    [JsonPropertyName("default_value")]
    public string DefaultValue { get; set; }

    [JsonPropertyName("string_parse")]
    public string StringParse { get; set; }
}

#nullable enable
