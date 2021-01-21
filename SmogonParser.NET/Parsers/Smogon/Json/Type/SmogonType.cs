using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace SmogonParser.NET.Parsers.Smogon.Json.Type
{
    [JsonConverter(typeof(SmogonTypeConverter))]
    public class SmogonType
    {
        public SmogonType(
            string name,
            ImmutableHashSet<SmogonAttackEffectiveness> attackEffectiveness,
            ImmutableHashSet<string> genFamily,
            string description)
        {
            Name = name;
            AttackEffectiveness = attackEffectiveness;
            GenFamily = genFamily;
            Description = description;
        }

        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("atk_effectives")]
        public ImmutableHashSet<SmogonAttackEffectiveness> AttackEffectiveness { get; }

        [JsonPropertyName("genfamily")]
        public ImmutableHashSet<string> GenFamily { get; }

        [JsonPropertyName("description")]
        public string Description { get; }
    }
}
