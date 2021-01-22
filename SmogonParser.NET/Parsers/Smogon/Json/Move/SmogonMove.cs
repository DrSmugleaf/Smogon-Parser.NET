using System;
using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace SmogonParser.NET.Parsers.Smogon.Json.Move
{
    public class SmogonMove : IEquatable<SmogonMove>
    {
        public SmogonMove(
            string name,
            string isNonStandard,
            string category,
            int power,
            int accuracy,
            int priority,
            int pp,
            string description,
            string type,
            ImmutableHashSet<string> flags,
            ImmutableHashSet<string> genFamily)
        {
            Name = name;
            IsNonStandard = isNonStandard;
            Category = category;
            Power = power;
            Accuracy = accuracy;
            Priority = priority;
            Pp = pp;
            Description = description;
            Type = type;
            Flags = flags;
            GenFamily = genFamily;
        }

        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("isNonstandard")]
        public string IsNonStandard { get; }

        [JsonPropertyName("category")]
        public string Category { get; }

        [JsonPropertyName("power")]
        public int Power { get; }

        [JsonPropertyName("accuracy")]
        public int Accuracy { get; }

        [JsonPropertyName("priority")]
        public int Priority { get; }

        [JsonPropertyName("pp")]
        public int Pp { get; }

        [JsonPropertyName("description")]
        public string Description { get; }

        [JsonPropertyName("type")]
        public string Type { get; }

        [JsonPropertyName("flags")]
        public ImmutableHashSet<string> Flags { get; }

        [JsonPropertyName("genfamily")]
        public ImmutableHashSet<string> GenFamily { get; }

        public bool Equals(SmogonMove? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name &&
                   IsNonStandard == other.IsNonStandard &&
                   Category == other.Category &&
                   Power == other.Power &&
                   Accuracy == other.Accuracy &&
                   Priority == other.Priority &&
                   Pp == other.Pp &&
                   Description == other.Description &&
                   Type == other.Type &&
                   Flags.SetEquals(other.Flags) &&
                   GenFamily.SetEquals(other.GenFamily);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((SmogonMove) obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Name);
            hashCode.Add(IsNonStandard);
            hashCode.Add(Category);
            hashCode.Add(Power);
            hashCode.Add(Accuracy);
            hashCode.Add(Priority);
            hashCode.Add(Pp);
            hashCode.Add(Description);
            hashCode.Add(Type);

            foreach (var flag in Flags)
            {
                hashCode.Add(flag);
            }

            foreach (var family in GenFamily)
            {
                hashCode.Add(family);
            }

            return hashCode.ToHashCode();
        }

        public static bool operator ==(SmogonMove? left, SmogonMove? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SmogonMove? left, SmogonMove? right)
        {
            return !Equals(left, right);
        }
    }
}
