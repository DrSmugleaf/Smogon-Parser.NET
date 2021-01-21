using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmogonParser.NET.Parsers.Smogon.Json
{
    public class SmogonOob
    {
        [JsonPropertyName("dex_number")]
        public int DexNumber { get; set; }

        [JsonPropertyName("evos")]
        public List<string> Evos { get; set; }

        [JsonPropertyName("alts")]
        public List<object> Alts { get; set; }

        [JsonPropertyName("genfamily")]
        public List<string> Genfamily { get; set; }
    }
}
