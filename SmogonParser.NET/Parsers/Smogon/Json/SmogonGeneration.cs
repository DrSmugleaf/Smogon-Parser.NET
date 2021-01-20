using System.Text.Json.Serialization;

namespace SmogonParser.NET.Parsers.Smogon.Json
{
    public class SmogonGeneration
    {
        public SmogonGeneration(string name, string shorthand)
        {
            Name = name;
            Shorthand = shorthand;
        }

        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("shorthand")]
        public string Shorthand { get; }
    }
}
