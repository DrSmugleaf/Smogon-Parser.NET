﻿using System;
using System.Collections.Immutable;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using SmogonParser.NET.Extensions;
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
    public class SmogonResponseConverter : JsonConverter<SmogonResponse>
    {
        private static readonly Regex DumpBasicsGen = new(@"\[""dex"",""dump-basics"",{""gen"":""\w+""}\]");

        public override SmogonResponse Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
        {
            reader.ReadOrThrow("injectRpcs");

            reader.ReadOrThrow(JsonTokenType.StartArray, 2);
            reader.ReadOrThrow(@"[""dex"",""dump-gens""]");

            reader.ReadOrThrow(JsonTokenType.StartArray);

            var generations = reader.Deserialize<ImmutableHashSet<SmogonGeneration>>(options);

            reader.ReadOrThrow(JsonTokenType.EndArray);

            reader.ReadOrThrow(JsonTokenType.StartArray);
            reader.ReadOrThrow(DumpBasicsGen);

            reader.ReadOrThrow(JsonTokenType.StartObject);

            var pokemons = reader.Deserialize<ImmutableHashSet<SmogonPokemon>>("pokemon", options);
            var formats = reader.Deserialize<ImmutableHashSet<SmogonFormat>>("formats", options);
            var natures = reader.Deserialize<ImmutableHashSet<SmogonNature>>("natures", options);
            var abilities = reader.Deserialize<ImmutableHashSet<SmogonAbility>>("abilities", options);
            var moveFlags = reader.Deserialize<ImmutableHashSet<SmogonMoveFlag>>("moveflags", options);
            var moves = reader.Deserialize<ImmutableHashSet<SmogonMove>>("moves", options);
            var types = reader.Deserialize<ImmutableHashSet<SmogonType>>("types", options);
            var items = reader.Deserialize<ImmutableHashSet<SmogonItem>>("items", options);

            reader.GetOrThrow(JsonTokenType.EndArray);
            reader.ReadOrThrow(JsonTokenType.EndObject);
            reader.ReadOrThrow(JsonTokenType.EndArray, 2);
            reader.ReadOrThrow("showEditorUI");
            reader.Read();
            reader.ReadOrThrow(JsonTokenType.EndObject);

            return new SmogonResponse(generations, pokemons, formats, natures, abilities, moveFlags, moves, types, items);
        }

        public override void Write(Utf8JsonWriter writer, SmogonResponse value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
