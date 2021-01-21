using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace SmogonParser.NET.Parsers.Smogon.Json
{
    public class SmogonFormat
    {
        public SmogonFormat(string name, string shorthand, ImmutableHashSet<string> genFamily)
        {
            Name = name;
            Shorthand = shorthand;
            GenFamily = genFamily;
        }

        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("shorthand")]
        public string Shorthand { get; }

        [JsonPropertyName("genFamily")]
        public ImmutableHashSet<string> GenFamily { get; }
    }
}
