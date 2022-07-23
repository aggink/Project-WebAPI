using Company.WebAPI.ViewModels.ParserViewModels.FieldParserViewModels;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Company.WebAPI.ViewModels.ParserViewModels.PropertyParserViewModels;

#nullable disable

public class PropertyParserViewModel
{
    [JsonProperty(PropertyName = "id")]
    public Guid Id { get; set; }

    [JsonProperty(PropertyName = "url")]
    public string URL { get; set; }

    [JsonProperty(PropertyName = "name_site")]
    public string NameSite { get; set; }

    [JsonProperty(PropertyName = "company_name")]
    public string CompanyName { get; set; }

    [JsonProperty(PropertyName = "company_description")]
    public string CompanyDescription { get; set; }

    [JsonProperty(PropertyName = "type_name")]
    public string TypeName { get; set; }

    [JsonProperty(PropertyName = "parser_params")]
    public ICollection<FieldParserViewModel> ParserParams { get; set; }
}

#nullable enable