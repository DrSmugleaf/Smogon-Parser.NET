using System;
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
using SmogonParser.NET.Parsers.Smogon.Json.Nature;
using SmogonParser.NET.Parsers.Smogon.Json.Pokemon;
using SmogonParser.NET.Parsers.Smogon.Json.Types;

namespace SmogonParser.NET.Parsers.Smogon.Json.Response
{
    public class SmogonResponseConverter : JsonConverter<SmogonResponse>
    {
        private static readonly Regex DumpBasicsGen = new(@"\[""dex"",""dump-basics"",{""gen"":""(\w+)""}\]");

        private const string DumpGensString = @"[""dex"",""dump-gens""]";

        private string DumpBasicsGenString(string generation)
        {
            generation = generation.ToLowerInvariant();

            return $@"[""dex"",""dump-basics"",{{""gen"":""{generation}""}}]";
        }

        public override SmogonResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            reader.ReadOrThrow("injectRpcs");

            reader.ReadOrThrow(JsonTokenType.StartArray, 2);
            reader.ReadOrThrow(DumpGensString);

            reader.ReadOrThrow(JsonTokenType.StartArray);

            var generations = reader.Deserialize<ImmutableHashSet<SmogonGeneration>>(options);

            reader.ReadOrThrow(JsonTokenType.EndArray);

            reader.ReadOrThrow(JsonTokenType.StartArray);
            var match = reader.ReadOrThrow(DumpBasicsGen);
            var generationPrefix = match.Groups[1].Value;

            reader.ReadOrThrow(JsonTokenType.StartObject);

            var pokemons = reader.Deserialize<ImmutableHashSet<SmogonPokemon>>("pokemon", options);
            var formats = reader.Deserialize<ImmutableHashSet<SmogonFormat>>("formats", options);
            var natures = reader.Deserialize<ImmutableHashSet<SmogonNature>>("natures", options);
            var abilities = reader.Deserialize<ImmutableHashSet<SmogonAbility>>("abilities", options);
            reader.Deserialize<ImmutableHashSet<string>>("moveflags", options);
            var moves = reader.Deserialize<ImmutableHashSet<SmogonMove>>("moves", options);
            var types = reader.Deserialize<ImmutableHashSet<SmogonType>>("types", options);
            var items = reader.Deserialize<ImmutableHashSet<SmogonItem>>("items", options);

            reader.GetOrThrow(JsonTokenType.EndArray);
            reader.ReadOrThrow(JsonTokenType.EndObject);
            reader.ReadOrThrow(JsonTokenType.EndArray, 2);
            reader.ReadOrThrow("showEditorUI");
            reader.Read(); // null
            reader.ReadOrThrow(JsonTokenType.EndObject);

            return new SmogonResponse(generationPrefix, generations, pokemons, formats, natures, abilities, moves, types, items);
        }

        public override void Write(Utf8JsonWriter writer, SmogonResponse value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("injectRpcs");

            writer.WriteStartArray();
            writer.WriteStartArray();
            writer.WriteStringValue(DumpGensString);

            JsonSerializer.Serialize(writer, value.Generations, options);

            writer.WriteEndArray();

            writer.WriteStartArray();
            writer.WriteStringValue(DumpBasicsGenString(value.GenerationPrefix));

            writer.WriteStartObject();

            writer.WritePropertyName("pokemon");
            JsonSerializer.Serialize(writer, value.Pokemons, options);

            writer.WritePropertyName("formats");
            JsonSerializer.Serialize(writer, value.Formats, options);

            writer.WritePropertyName("natures");
            JsonSerializer.Serialize(writer, value.Natures, options);

            writer.WritePropertyName("abilities");
            JsonSerializer.Serialize(writer, value.Abilities, options);

            writer.WritePropertyName("moveflags");
            writer.WriteStartArray();
            writer.WriteEndArray();

            writer.WritePropertyName("moves");
            JsonSerializer.Serialize(writer, value.Moves, options);

            writer.WritePropertyName("types");
            JsonSerializer.Serialize(writer, value.Types, options);

            writer.WritePropertyName("items");
            JsonSerializer.Serialize(writer, value.Items, options);

            writer.WriteEndObject();
            writer.WriteEndArray();
            writer.WriteEndArray();
            writer.WriteNull("showEditorUI");
            writer.WriteEndObject();
        }
    }
}
