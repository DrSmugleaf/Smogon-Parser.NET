using System;
using System.Collections.Immutable;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace SmogonParser.NET.Parsers.Smogon.Json.Pokemon
{
    [PublicAPI]
    public class SmogonOob : IEquatable<SmogonOob>
    {
        public SmogonOob(
            int dexNumber,
            ImmutableHashSet<string> evolutions,
            ImmutableHashSet<string> alts,
            ImmutableHashSet<string> genFamily)
        {
            DexNumber = dexNumber;
            Evolutions = evolutions;
            Alts = alts;
            GenFamily = genFamily;
        }

        [JsonPropertyName("dex_number")]
        public int DexNumber { get; }

        [JsonPropertyName("evos")]
        public ImmutableHashSet<string> Evolutions { get; }

        [JsonPropertyName("alts")]
        public ImmutableHashSet<string> Alts { get; }

        [JsonPropertyName("genfamily")]
        public ImmutableHashSet<string> GenFamily { get; }

        public bool Equals(SmogonOob? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return DexNumber == other.DexNumber &&
                   Evolutions.SetEquals(other.Evolutions) &&
                   Alts.SetEquals(other.Alts) &&
                   GenFamily.SetEquals(other.GenFamily);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((SmogonOob) obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();

            hashCode.Add(DexNumber);

            foreach (var evolution in Evolutions)
            {
                hashCode.Add(evolution);
            }

            foreach (var alt in Alts)
            {
                hashCode.Add(alt);
            }

            foreach (var family in GenFamily)
            {
                hashCode.Add(family);
            }

            return hashCode.ToHashCode();
        }

        public static bool operator ==(SmogonOob? left, SmogonOob? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SmogonOob? left, SmogonOob? right)
        {
            return !Equals(left, right);
        }
    }
}
