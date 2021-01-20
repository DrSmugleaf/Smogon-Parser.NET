using System.Text.Json.Serialization;

namespace SmogonParser.NET.Parsers.Smogon.Json
{
    public class SmogonPokemon
    {
        public SmogonPokemon(
            string name,
            int health,
            int attack,
            int defense,
            int specialAttack,
            int specialDefense,
            int speed,
            decimal weight,
            decimal height)
        {
            Name = name;
            Health = health;
            Attack = attack;
            Defense = defense;
            SpecialAttack = specialAttack;
            SpecialDefense = specialDefense;
            Speed = speed;
            Weight = weight;
            Height = height;
        }

        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("hp")]
        public int Health { get; }

        [JsonPropertyName("atk")]
        public int Attack { get; }

        [JsonPropertyName("def")]
        public int Defense { get; }

        [JsonPropertyName("spa")]
        public int SpecialAttack { get; }

        [JsonPropertyName("spd")]
        public int SpecialDefense { get; }

        [JsonPropertyName("spe")]
        public int Speed { get; }

        [JsonPropertyName("weight")]
        public decimal Weight { get; }

        [JsonPropertyName("height")]
        public decimal Height { get; }
    }
}
