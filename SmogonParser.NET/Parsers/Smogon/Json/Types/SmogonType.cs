using System;
using System.Collections.Immutable;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace SmogonParser.NET.Parsers.Smogon.Json.Types
{
    [JsonConverter(typeof(SmogonTypeConverter))]
    [PublicAPI]
    public class SmogonType : IEquatable<SmogonType>
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

        public bool Equals(SmogonType? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name &&
                   AttackEffectiveness.SetEquals(other.AttackEffectiveness) &&
                   GenFamily.SetEquals(other.GenFamily) &&
                   Description == other.Description;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((SmogonType) obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();

            hashCode.Add(Name);

            foreach (var effectiveness in AttackEffectiveness)
            {
                hashCode.Add(effectiveness);
            }

            foreach (var family in GenFamily)
            {
                hashCode.Add(family);
            }

            hashCode.Add(Description);

            return hashCode.ToHashCode();
        }

        public static bool operator ==(SmogonType? left, SmogonType? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SmogonType? left, SmogonType? right)
        {
            return !Equals(left, right);
        }
    }
}
