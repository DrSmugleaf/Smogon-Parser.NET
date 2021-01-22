using System;
using System.Collections.Immutable;
using System.Text.Json.Serialization;
using SmogonParser.NET.Parsers.Smogon.Json.Ability;
using SmogonParser.NET.Parsers.Smogon.Json.Format;
using SmogonParser.NET.Parsers.Smogon.Json.Generation;
using SmogonParser.NET.Parsers.Smogon.Json.Item;
using SmogonParser.NET.Parsers.Smogon.Json.Move;
using SmogonParser.NET.Parsers.Smogon.Json.Nature;
using SmogonParser.NET.Parsers.Smogon.Json.Pokemon;
using SmogonParser.NET.Parsers.Smogon.Json.Type;

namespace SmogonParser.NET.Parsers.Smogon.Json.Response
{
    [JsonConverter(typeof(SmogonResponseConverter))]
    public class SmogonResponse : IEquatable<SmogonResponse>
    {
        public SmogonResponse(
            string generationPrefix,
            ImmutableHashSet<SmogonGeneration> generations,
            ImmutableHashSet<SmogonPokemon> pokemons,
            ImmutableHashSet<SmogonFormat> formats,
            ImmutableHashSet<SmogonNature> natures,
            ImmutableHashSet<SmogonAbility> abilities,
            ImmutableHashSet<SmogonMove> moves,
            ImmutableHashSet<SmogonType> types,
            ImmutableHashSet<SmogonItem> items)
        {
            GenerationPrefix = generationPrefix;
            Generations = generations;
            Pokemons = pokemons;
            Formats = formats;
            Natures = natures;
            Abilities = abilities;
            Moves = moves;
            Types = types;
            Items = items;
        }

        public string GenerationPrefix { get; }

        public ImmutableHashSet<SmogonGeneration> Generations { get; }

        public ImmutableHashSet<SmogonPokemon> Pokemons { get; }

        public ImmutableHashSet<SmogonFormat> Formats { get; }

        public ImmutableHashSet<SmogonNature> Natures { get; }

        public ImmutableHashSet<SmogonAbility> Abilities { get; }

        public ImmutableHashSet<SmogonMove> Moves { get; }

        public ImmutableHashSet<SmogonType> Types { get; }

        public ImmutableHashSet<SmogonItem> Items { get; }

        public bool Equals(SmogonResponse? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return GenerationPrefix == other.GenerationPrefix &&
                   Generations.SetEquals(other.Generations) &&
                   Pokemons.SetEquals(other.Pokemons) &&
                   Formats.SetEquals(other.Formats) &&
                   Natures.SetEquals(other.Natures) &&
                   Abilities.SetEquals(other.Abilities) &&
                   Moves.SetEquals(other.Moves) &&
                   Types.SetEquals(other.Types) &&
                   Items.SetEquals(other.Items);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((SmogonResponse) obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(GenerationPrefix);
            hashCode.Add(Generations);
            hashCode.Add(Pokemons);
            hashCode.Add(Formats);
            hashCode.Add(Natures);
            hashCode.Add(Abilities);
            hashCode.Add(Moves);
            hashCode.Add(Types);
            hashCode.Add(Items);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(SmogonResponse? left, SmogonResponse? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SmogonResponse? left, SmogonResponse? right)
        {
            return !Equals(left, right);
        }
    }
}
