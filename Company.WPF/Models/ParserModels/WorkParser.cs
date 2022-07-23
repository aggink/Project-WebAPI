using System.Text.Json.Serialization;

namespace Company.WPF.Models.ParserModels;

#nullable disable

public class WorkParser
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("property_parser_id")]
    public Guid PropertyParserId { get; set; }

    [JsonPropertyName("is_started")]
    public bool IsStarted { get; set; }

    [JsonPropertyName("is_completed")]
    public bool IsCompleted { get; set; }

    [JsonPropertyName("start_time")]
    public DateTime StartTime { get; set; }

    [JsonPropertyName("completion_time")]
    public DateTime CompletionTime { get; set; }

    [JsonPropertyName("property_parser")]
    public PropertyParser PropertyParser { get; set; }
}

#nullable enable