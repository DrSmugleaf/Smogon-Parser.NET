using System;
using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace SmogonParser.NET.Parsers.Smogon.Json.Ability
{
    public class SmogonAbility : IEquatable<SmogonAbility>
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

        public bool Equals(SmogonAbility? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name &&
                   Description == other.Description &&
                   IsNonStandard == other.IsNonStandard &&
                   GenFamily.SetEquals(other.GenFamily);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((SmogonAbility) obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();

            hashCode.Add(Name);
            hashCode.Add(Description);
            hashCode.Add(IsNonStandard);

            foreach (var family in GenFamily)
            {
                hashCode.Add(family);
            }

            return hashCode.ToHashCode();
        }

        public static bool operator ==(SmogonAbility? left, SmogonAbility? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SmogonAbility? left, SmogonAbility? right)
        {
            return !Equals(left, right);
        }
    }
}
