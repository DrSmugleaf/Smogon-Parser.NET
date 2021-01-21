using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace SmogonParser.NET.Parsers.Smogon.Json.Pokemon
{
    public class SmogonOob
    {
        public SmogonOob(
            int dexNumber,
            ImmutableHashSet<string> evolutions,
            ImmutableHashSet<string> alts,
            ImmutableHashSet<string> genFamily)
        {
            DexNumber = dexNumber;
            Evolutions = evolutions;
            Alts = alts;
            GenFamily = genFamily;
        }

        [JsonPropertyName("dex_number")]
        public int DexNumber { get; }

        [JsonPropertyName("evos")]
        public ImmutableHashSet<string> Evolutions { get; }

        [JsonPropertyName("alts")]
        public ImmutableHashSet<string> Alts { get; }

        [JsonPropertyName("genfamily")]
        public ImmutableHashSet<string> GenFamily { get; }
    }
}
