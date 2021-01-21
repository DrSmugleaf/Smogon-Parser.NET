using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace SmogonParser.NET.Parsers.Smogon.Json
{
    public class SmogonAbility
    {
        public SmogonAbility(
            string name,
            string description,
            string isNonStandard,
            ImmutableHashSet<string> genFamily)
        {
            Name = name;
            Description = description;
            IsNonStandard = isNonStandard;
            GenFamily = genFamily;
        }

        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("description")]
        public string Description { get; }

        [JsonPropertyName("isNonstandard")]
        public string IsNonStandard { get; }

        [JsonPropertyName("genfamily")]
        public ImmutableHashSet<string> GenFamily { get; }
    }
}
