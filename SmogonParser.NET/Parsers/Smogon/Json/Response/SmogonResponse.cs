using System.Collections.Immutable;
using System.Text.Json.Serialization;
using SmogonParser.NET.Parsers.Smogon.Json.Ability;
using SmogonParser.NET.Parsers.Smogon.Json.Format;
using SmogonParser.NET.Parsers.Smogon.Json.Generation;
using SmogonParser.NET.Parsers.Smogon.Json.Item;
using SmogonParser.NET.Parsers.Smogon.Json.Move;
using SmogonParser.NET.Parsers.Smogon.Json.MoveFlag;
using SmogonParser.NET.Parsers.Smogon.Json.Nature;
using SmogonParser.NET.Parsers.Smogon.Json.Pokemon;
using SmogonParser.NET.Parsers.Smogon.Json.Type;

namespace SmogonParser.NET.Parsers.Smogon.Json.Response
{
    [JsonConverter(typeof(SmogonResponseConverter))]
    public class SmogonResponse
    {
        public SmogonResponse(
            ImmutableHashSet<SmogonGeneration> generations,
            ImmutableHashSet<SmogonPokemon> pokemons,
            ImmutableHashSet<SmogonFormat> formats,
            ImmutableHashSet<SmogonNature> natures,
            ImmutableHashSet<SmogonAbility> abilities,
            ImmutableHashSet<SmogonMoveFlag> moveFlags,
            ImmutableHashSet<SmogonMove> moves,
            ImmutableHashSet<SmogonType> types,
            ImmutableHashSet<SmogonItem> item)
        {
            Generations = generations;
            Pokemons = pokemons;
            Formats = formats;
            Natures = natures;
            Abilities = abilities;
            MoveFlags = moveFlags;
            Moves = moves;
            Types = types;
            Item = item;
        }

        public ImmutableHashSet<SmogonGeneration> Generations { get; }

        public ImmutableHashSet<SmogonPokemon> Pokemons { get; }

        public ImmutableHashSet<SmogonFormat> Formats { get; }

        public ImmutableHashSet<SmogonNature> Natures { get; }

        public ImmutableHashSet<SmogonAbility> Abilities { get; }

        public ImmutableHashSet<SmogonMoveFlag> MoveFlags { get; }

        public ImmutableHashSet<SmogonMove> Moves { get; }

        public ImmutableHashSet<SmogonType> Types { get; }

        public ImmutableHashSet<SmogonItem> Item { get; }
    }
}
