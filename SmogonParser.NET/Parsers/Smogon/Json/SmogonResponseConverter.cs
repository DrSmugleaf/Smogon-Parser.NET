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

            var pokemons = reader.Deserialize<HashSet<SmogonPokemon>>("pokemon", options);
            var formats = reader.Deserialize<HashSet<SmogonFormat>>("formats", options);
            var natures = reader.Deserialize<HashSet<SmogonNature>>("natures", options);
            var abilities = reader.Deserialize<HashSet<SmogonAbility>>("abilities", options);
            var moveFlags = reader.Deserialize<HashSet<SmogonMoveFlag>>("moveflags", options);
            var moves = reader.Deserialize<HashSet<SmogonMove>>("moves", options);
            var types = reader.Deserialize<HashSet<SmogonType>>("types", options);
            var items = reader.Deserialize<HashSet<SmogonItem>>("items", options);

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
