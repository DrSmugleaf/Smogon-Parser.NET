using System.Text.Json;

namespace SmogonParser.NET.Parsers.Smogon.Json.Response
{
    public static class SmogonResponseExtensions
    {
        public static string ToJson(this SmogonResponse response, JsonSerializerOptions? options = null)
        {
            return JsonSerializer.Serialize(response, options);
        }
    }
}
