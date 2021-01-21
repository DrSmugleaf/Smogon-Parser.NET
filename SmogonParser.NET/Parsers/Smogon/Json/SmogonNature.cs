using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace SmogonParser.NET.Parsers.Smogon.Json
{
    public class SmogonNature
    {
        public SmogonNature(
            string name,
            decimal health,
            decimal attack,
            decimal defense,
            decimal specialAttack,
            decimal specialDefense,
            decimal speed,
            string summary,
            ImmutableHashSet<string> genFamily)
        {
            Name = name;
            Health = health;
            Attack = attack;
            Defense = defense;
            SpecialAttack = specialAttack;
            SpecialDefense = specialDefense;
            Speed = speed;
            Summary = summary;
            GenFamily = genFamily;
        }

        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("hp")]
        public decimal Health { get; }

        [JsonPropertyName("atk")]
        public decimal Attack { get; }

        [JsonPropertyName("def")]
        public decimal Defense { get; }

        [JsonPropertyName("spa")]
        public decimal SpecialAttack { get; }

        [JsonPropertyName("spd")]
        public decimal SpecialDefense { get; }

        [JsonPropertyName("spe")]
        public decimal Speed { get; }

        [JsonPropertyName("summary")]
        public string Summary { get; }

        [JsonPropertyName("genfamily")]
        public ImmutableHashSet<string> GenFamily { get; }
    }
}
