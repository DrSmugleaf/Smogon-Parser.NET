﻿using System;
using System.Collections.Immutable;
using System.Text.Json;
using System.Text.Json.Serialization;
using SmogonParser.NET.Extensions;

namespace SmogonParser.NET.Parsers.Smogon.Json.Types
{
    public class SmogonTypeConverter : JsonConverter<SmogonType>
    {
        public override SmogonType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var name = reader.ReadValueOrThrow<string>("name");

            reader.ReadOrThrow("atk_effectives");
            reader.ReadOrThrow(JsonTokenType.StartArray);

            var attackEffectiveness = reader.Deserialize<ImmutableHashSet<SmogonAttackEffectiveness>>();

            reader.ReadOrThrow("genfamily");

            var genFamily = reader.Deserialize<ImmutableHashSet<string>>();
            var description = reader.ReadValueOrThrow<string>("description");

            reader.ReadOrThrow(JsonTokenType.EndObject);

            return new SmogonType(name, attackEffectiveness, genFamily, description);
        }

        public override void Write(Utf8JsonWriter writer, SmogonType value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("name", value.Name);

            writer.WritePropertyName("atk_effectives");
            JsonSerializer.Serialize(writer, value.AttackEffectiveness, options);

            writer.WritePropertyName("genfamily");
            JsonSerializer.Serialize(writer, value.GenFamily, options);

            writer.WriteString("description", value.Description);

            writer.WriteEndObject();
        }
    }
}
