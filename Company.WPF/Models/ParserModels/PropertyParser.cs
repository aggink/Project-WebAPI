using System.Text.Json.Serialization;

namespace Company.WPF.Models.ParserModels;

#nullable disable

public class PropertyParser
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("url")]
    public string URL { get; set; }

    [JsonPropertyName("name_site")]
    public string NameSite { get; set; }

    [JsonPropertyName("company_name")]
    public string NameCompany { get; set; }

    [JsonPropertyName("company_description")]
    public string DescriptionCompany { get; set; }

    [JsonPropertyName("type_name")]
    public string NameType { get; set; }

    [JsonPropertyName("parser_params")]
    public IEnumerable<FieldParser> ParamsParser { get; set; }
}

#nullable enable