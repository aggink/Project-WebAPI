using Newtonsoft.Json;

namespace Company.WebAPI.ViewModels.ParserViewModels.FieldParserViewModels;

#nullable disable
public class FieldParserViewModel
{
    [JsonProperty(PropertyName = "id")]
    public Guid Id { get; set; }

    [JsonProperty(PropertyName = "property_parser_id")]
    public Guid PropertyParserId { get; set; }

    [JsonProperty(PropertyName = "property_name")]
    public string PropertyName { get; set; }

    [JsonProperty(PropertyName = "default_value")]
    public string DefaultValue { get; set; }

    [JsonProperty(PropertyName = "string_parse")]
    public string StringParse { get; set; }
}

#nullable enable