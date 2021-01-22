using System;
using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace SmogonParser.NET.Parsers.Smogon.Json.Nature
{
    public class SmogonNature : IEquatable<SmogonNature>
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

        public bool Equals(SmogonNature? other)
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
                   Summary == other.Summary &&
                   GenFamily.SetEquals(other.GenFamily);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((SmogonNature) obj);
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
            hashCode.Add(Summary);

            foreach (var family in GenFamily)
            {
                hashCode.Add(family);
            }

            return hashCode.ToHashCode();
        }

        public static bool operator ==(SmogonNature? left, SmogonNature? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SmogonNature? left, SmogonNature? right)
        {
            return !Equals(left, right);
        }
    }
}
