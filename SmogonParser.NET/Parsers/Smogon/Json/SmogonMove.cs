using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace SmogonParser.NET.Parsers.Smogon.Json
{
    public class SmogonMove
    {
        public SmogonMove(
            string name,
            string isNonStandard,
            string category,
            int power,
            int accuracy,
            int priority,
            int pp,
            string description,
            string type,
            ImmutableHashSet<string> flags,
            ImmutableHashSet<string> genFamily)
        {
            Name = name;
            IsNonStandard = isNonStandard;
            Category = category;
            Power = power;
            Accuracy = accuracy;
            Priority = priority;
            Pp = pp;
            Description = description;
            Type = type;
            Flags = flags;
            GenFamily = genFamily;
        }

        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("isNonstandard")]
        public string IsNonStandard { get; }

        [JsonPropertyName("category")]
        public string Category { get; }

        [JsonPropertyName("power")]
        public int Power { get; }

        [JsonPropertyName("accuracy")]
        public int Accuracy { get; }

        [JsonPropertyName("priority")]
        public int Priority { get; }

        [JsonPropertyName("pp")]
        public int Pp { get; }

        [JsonPropertyName("description")]
        public string Description { get; }

        [JsonPropertyName("type")]
        public string Type { get; }

        [JsonPropertyName("flags")]
        public ImmutableHashSet<string> Flags { get; }

        [JsonPropertyName("genfamily")]
        public ImmutableHashSet<string> GenFamily { get; }
    }
}
