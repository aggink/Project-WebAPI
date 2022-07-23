using Company.WebAPI.ViewModels.ParserViewModels.PropertyParserViewModels;
using Newtonsoft.Json;

namespace Company.WebAPI.ViewModel.ParserViewModels;

/// <summary>
/// Сведения о парсинге
/// </summary>
public class WorkParserViewModel
{
    [JsonProperty(PropertyName = "id")]
    public Guid Id { get; set; }

    [JsonProperty(PropertyName = "property_parser_id")]
    public Guid PropertyParserId { get; set; }

    [JsonProperty(PropertyName = "is_started")]
    public bool IsStarted { get; set; }

    [JsonProperty(PropertyName = "is_completed")]
    public bool IsCompleted { get; set; }

    [JsonProperty(PropertyName = "start_time")]
    public DateTime StartTime { get; set; }

    [JsonProperty(PropertyName = "completion_time")]
    public DateTime CompletionTime { get; set; }

    [JsonProperty(PropertyName = "property_parser")]
    public PropertyParserViewModel PropertyParser { get; set; } = null!;
}