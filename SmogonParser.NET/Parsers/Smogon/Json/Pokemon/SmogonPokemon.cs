using System;
using System.Collections.Immutable;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace SmogonParser.NET.Parsers.Smogon.Json.Pokemon
{
    [PublicAPI]
    public class SmogonPokemon : IEquatable<SmogonPokemon>
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
            decimal height,
            ImmutableHashSet<string> types,
            ImmutableHashSet<string> abilities,
            ImmutableHashSet<string> formats,
            string isNonStandard,
            SmogonOob oob)
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
            Types = types;
            Abilities = abilities;
            Formats = formats;
            IsNonStandard = isNonStandard;
            Oob = oob;
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

        [JsonPropertyName("types")]
        public ImmutableHashSet<string> Types { get; }

        [JsonPropertyName("abilities")]
        public ImmutableHashSet<string> Abilities { get; }

        [JsonPropertyName("formats")]
        public ImmutableHashSet<string> Formats { get; }

        [JsonPropertyName("isNonstandard")]
        public string IsNonStandard { get; }

        [JsonPropertyName("oob")]
        public SmogonOob Oob { get; }

        public bool Equals(SmogonPokemon? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name &&
                   Health == other.Health &&
                   Attack == other.Attack &&
                   Defense == other.Defense &&
                   SpecialAttack == other.SpecialAttack &&
                   SpecialDefense == other.SpecialDefense &&
                   Speed == other.Speed &&
                   Weight == other.Weight &&
                   Height == other.Height &&
                   Types.SetEquals(other.Types) &&
                   Abilities.SetEquals(other.Abilities) &&
                   Formats.SetEquals(other.Formats) &&
                   IsNonStandard == other.IsNonStandard &&
                   Oob.Equals(other.Oob);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((SmogonPokemon) obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Name);
            hashCode.Add(Health);
            hashCode.Add(Attack);
            hashCode.Add(Defense);
            hashCode.Add(SpecialAttack);
            hashCode.Add(SpecialDefense);
            hashCode.Add(Speed);
            hashCode.Add(Weight);
            hashCode.Add(Height);

            foreach (var type in Types)
            {
                hashCode.Add(type);
            }

            foreach (var ability in Abilities)
            {
                hashCode.Add(ability);
            }

            foreach (var format in Formats)
            {
                hashCode.Add(format);
            }

            hashCode.Add(IsNonStandard);
            hashCode.Add(Oob);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(SmogonPokemon? left, SmogonPokemon? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SmogonPokemon? left, SmogonPokemon? right)
        {
            return !Equals(left, right);
        }
    }
}
