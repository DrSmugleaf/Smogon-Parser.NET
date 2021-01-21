using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmogonParser.NET.Parsers.Smogon.Json
{
    public class SmogonOob
    {
        [JsonPropertyName("dex_number")]
        public int DexNumber { get; }

        [JsonPropertyName("evos")]
        public List<string> Evos { get; }

        [JsonPropertyName("alts")]
        public List<object> Alts { get; }

        [JsonPropertyName("genfamily")]
        public List<string> Genfamily { get; }
    }
}
