using System.Text.Json;

namespace Company.WebAPI.Extensions;

public static class ConvertorExtensions
{
    public static string ConvertListToJson<T>(List<T> list)
    {
        return JsonSerializer.Serialize(list, default(JsonSerializerOptions));
    }

    public static List<T>? ConvertJsonToList<T>(string json)
    {
        return JsonSerializer.Deserialize<List<T>>(json, default(JsonSerializerOptions));
    }
}