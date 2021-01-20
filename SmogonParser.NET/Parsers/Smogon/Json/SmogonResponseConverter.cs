using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using SmogonParser.NET.Extensions;

namespace SmogonParser.NET.Parsers.Smogon.Json
{
    public class SmogonResponseConverter : JsonConverter<SmogonResponse>
    {
        private static readonly Regex DumpBasicsGen = new(@"\[""dex"",""dump-basics"",{""gen"":""\w+""}\]");

        public override SmogonResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            reader.ReadOrThrow("injectRpcs");

            reader.ReadOrThrow(JsonTokenType.StartArray, 2);
            reader.ReadOrThrow(@"[""dex"",""dump-gens""]");

            reader.ReadOrThrow(JsonTokenType.StartArray);

            var generations = reader.Deserialize<HashSet<SmogonGeneration>>(options);

            reader.ReadOrThrow(JsonTokenType.EndArray);

            reader.ReadOrThrow(JsonTokenType.StartArray);
            reader.ReadOrThrow(DumpBasicsGen);

            reader.ReadOrThrow(JsonTokenType.StartObject);
            reader.ReadOrThrow("pokemon");

            var pokemons = reader.Deserialize<HashSet<SmogonPokemon>>(options);

            reader.GetOrThrow(JsonTokenType.EndArray);
            reader.ReadOrThrow("formats");

            var formats = reader.Deserialize<HashSet<SmogonFormat>>(options);

            reader.GetOrThrow(JsonTokenType.EndArray);
            reader.ReadOrThrow("natures");

            var natures = reader.Deserialize<HashSet<SmogonNature>>(options);

            reader.GetOrThrow(JsonTokenType.EndArray);
            reader.ReadOrThrow("abilities");

            var abilities = reader.Deserialize<HashSet<SmogonAbility>>(options);

            reader.GetOrThrow(JsonTokenType.EndArray);
            reader.ReadOrThrow("moveflags");

            var moveFlags = reader.Deserialize<HashSet<SmogonMoveFlag>>(options);

            reader.GetOrThrow(JsonTokenType.EndArray);
            reader.ReadOrThrow("moves");

            var moves = reader.Deserialize<HashSet<SmogonMove>>(options);

            reader.GetOrThrow(JsonTokenType.EndArray);
            reader.ReadOrThrow("types");

            var types = reader.Deserialize<HashSet<SmogonType>>(options);

            reader.GetOrThrow(JsonTokenType.EndArray);
            reader.ReadOrThrow("items");

            var items = reader.Deserialize<HashSet<SmogonItem>>(options);

            reader.GetOrThrow(JsonTokenType.EndArray);
            reader.ReadOrThrow(JsonTokenType.EndObject);
            reader.ReadOrThrow(JsonTokenType.EndArray, 2);
            reader.ReadOrThrow("showEditorUI");
            reader.Read();
            reader.ReadOrThrow(JsonTokenType.EndObject);

            var settings = new SmogonDexSettings(generations, pokemons, formats, natures, abilities, moveFlags, moves, types, items);

            return new SmogonResponse(settings);
        }

        public override void Write(Utf8JsonWriter writer, SmogonResponse value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
