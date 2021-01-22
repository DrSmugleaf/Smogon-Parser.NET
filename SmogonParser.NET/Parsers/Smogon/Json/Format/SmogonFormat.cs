using System;
using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace SmogonParser.NET.Parsers.Smogon.Json.Format
{
    public class SmogonFormat : IEquatable<SmogonFormat>
    {
        public SmogonFormat(string name, string shorthand, ImmutableHashSet<string> genFamily)
        {
            Name = name;
            Shorthand = shorthand;
            GenFamily = genFamily;
        }

        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("shorthand")]
        public string Shorthand { get; }

        [JsonPropertyName("genfamily")]
        public ImmutableHashSet<string> GenFamily { get; }

        public bool Equals(SmogonFormat? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name &&
                   Shorthand == other.Shorthand &&
                   GenFamily.SetEquals(other.GenFamily);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((SmogonFormat) obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();

            hashCode.Add(Name);
            hashCode.Add(Shorthand);

            foreach (var family in GenFamily)
            {
                hashCode.Add(family);
            }

            return hashCode.ToHashCode();
        }

        public static bool operator ==(SmogonFormat? left, SmogonFormat? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SmogonFormat? left, SmogonFormat? right)
        {
            return !Equals(left, right);
        }
    }
}
