using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace SmogonParser.NET.Parsers.Smogon.Json
{
    public class SmogonFormat
    {
        public SmogonFormat(string name, string shorthand, IEnumerable<string> genFamily)
        {
            Name = name;
            Shorthand = shorthand;
            GenFamily = genFamily.ToHashSet();
        }

        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("shorthand")]
        public string Shorthand { get; }

        [JsonPropertyName("genFamily")]
        public IReadOnlySet<string> GenFamily { get; }
    }
}
