using System;
using System.Text.Json.Serialization;

namespace SmogonParser.NET.Parsers.Smogon.Json.Generation
{
    public class SmogonGeneration : IEquatable<SmogonGeneration>
    {
        public SmogonGeneration(string name, string shorthand)
        {
            Name = name;
            Shorthand = shorthand;
        }

        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("shorthand")]
        public string Shorthand { get; }

        public bool Equals(SmogonGeneration? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name &&
                   Shorthand == other.Shorthand;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((SmogonGeneration) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Shorthand);
        }

        public static bool operator ==(SmogonGeneration? left, SmogonGeneration? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SmogonGeneration? left, SmogonGeneration? right)
        {
            return !Equals(left, right);
        }
    }
}
