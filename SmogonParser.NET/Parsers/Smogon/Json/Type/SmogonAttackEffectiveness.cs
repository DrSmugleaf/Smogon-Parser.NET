using System;
using System.Text.Json.Serialization;

namespace SmogonParser.NET.Parsers.Smogon.Json.Type
{
    [JsonConverter(typeof(SmogonAttackEffectivenessConverter))]
    public class SmogonAttackEffectiveness : IEquatable<SmogonAttackEffectiveness>
    {
        public SmogonAttackEffectiveness(string name, decimal effectiveness)
        {
            Name = name;
            Effectiveness = effectiveness;
        }

        public string Name { get; }

        public decimal Effectiveness { get; }

        public bool Equals(SmogonAttackEffectiveness? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name &&
                   Effectiveness == other.Effectiveness;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((SmogonAttackEffectiveness) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Effectiveness);
        }

        public static bool operator ==(SmogonAttackEffectiveness? left, SmogonAttackEffectiveness? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SmogonAttackEffectiveness? left, SmogonAttackEffectiveness? right)
        {
            return !Equals(left, right);
        }
    }
}
