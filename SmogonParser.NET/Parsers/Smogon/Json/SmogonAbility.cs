using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace SmogonParser.NET.Parsers.Smogon.Json
{
    public class SmogonAbility
    {
        public SmogonAbility(
            string name,
            string description,
            string isNonstandard,
            ImmutableHashSet<string> genFamily)
        {
            Name = name;
            Description = description;
            IsNonstandard = isNonstandard;
            GenFamily = genFamily;
        }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("isNonstandard")]
        public string IsNonstandard { get; set; }

        [JsonPropertyName("genfamily")]
        public ImmutableHashSet<string> GenFamily { get; set; }
    }
}
