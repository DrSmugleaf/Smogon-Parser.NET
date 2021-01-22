using System.Collections.Immutable;
using System.Text.Json;
using NUnit.Framework;
using SmogonParser.NET.Parsers.Smogon.Json.Ability;
using SmogonParser.NET.Parsers.Smogon.Json.Format;
using SmogonParser.NET.Parsers.Smogon.Json.Generation;
using SmogonParser.NET.Parsers.Smogon.Json.Item;
using SmogonParser.NET.Parsers.Smogon.Json.Move;
using SmogonParser.NET.Parsers.Smogon.Json.Nature;
using SmogonParser.NET.Parsers.Smogon.Json.Pokemon;
using SmogonParser.NET.Parsers.Smogon.Json.Response;
using SmogonParser.NET.Parsers.Smogon.Json.Types;

namespace SmogonParser.NET.IntegrationTests
{
    [TestFixture]
    [TestOf(typeof(SmogonResponseConverter))]
    public class SerializeTest
    {
        [Test]
        public void Test()
        {
            var response = new SmogonResponse(
                    "prefix",
                    ImmutableHashSet<SmogonGeneration>.Empty,
                    ImmutableHashSet<SmogonPokemon>.Empty,
                    ImmutableHashSet<SmogonFormat>.Empty,
                    ImmutableHashSet<SmogonNature>.Empty,
                    ImmutableHashSet<SmogonAbility>.Empty,
                    ImmutableHashSet<SmogonMove>.Empty,
                    ImmutableHashSet<SmogonType>.Empty,
                    ImmutableHashSet<SmogonItem>.Empty);

            var json = response.ToJson();

            Assert.NotNull(json);
        }
    }
}
