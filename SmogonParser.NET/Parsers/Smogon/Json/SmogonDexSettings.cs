using System.Collections.Generic;
using System.Linq;

namespace SmogonParser.NET.Parsers.Smogon.Json
{
    public class SmogonDexSettings
    {

        public SmogonDexSettings(
            IEnumerable<SmogonGeneration> generations,
            IEnumerable<SmogonPokemon> pokemons,
            IEnumerable<SmogonFormat> formats,
            IEnumerable<SmogonNature> natures,
            IEnumerable<SmogonAbility> abilities,
            IEnumerable<SmogonMoveFlag> moveFlags,
            IEnumerable<SmogonMove> moves,
            IEnumerable<SmogonType> types,
            IEnumerable<SmogonItem> item)
        {
            Generations = generations.ToHashSet();
            Pokemons = pokemons.ToHashSet();
            Formats = formats.ToHashSet();
            Natures = natures.ToHashSet();
            Abilities = abilities.ToHashSet();
            MoveFlags = moveFlags.ToHashSet();
            Moves = moves.ToHashSet();
            Types = types.ToHashSet();
            Item = item.ToHashSet();
        }

        public IReadOnlySet<SmogonGeneration> Generations { get; }
        public IReadOnlySet<SmogonPokemon> Pokemons { get; }
        public IReadOnlySet<SmogonFormat> Formats { get; }
        public IReadOnlySet<SmogonNature> Natures { get; }
        public IReadOnlySet<SmogonAbility> Abilities { get; }
        public IReadOnlySet<SmogonMoveFlag> MoveFlags { get; }
        public IReadOnlySet<SmogonMove> Moves { get; }
        public IReadOnlySet<SmogonType> Types { get; }
        public IReadOnlySet<SmogonItem> Item { get; }
    }
}
