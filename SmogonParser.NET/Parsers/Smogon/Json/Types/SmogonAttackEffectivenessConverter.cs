﻿using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using SmogonParser.NET.Extensions;

namespace SmogonParser.NET.Parsers.Smogon.Json.Types
{
    public class SmogonAttackEffectivenessConverter : JsonConverter<SmogonAttackEffectiveness>
    {
        public override SmogonAttackEffectiveness Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var name = reader.ReadOrThrow<string>();
            var effectiveness = reader.ReadOrThrow<decimal>();

            reader.ReadOrThrow(JsonTokenType.EndArray);

            return new SmogonAttackEffectiveness(name, effectiveness);
        }

        public override void Write(Utf8JsonWriter writer, SmogonAttackEffectiveness value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            writer.WriteStringValue(value.Name);
            writer.WriteNumberValue(value.Effectiveness);
            writer.WriteEndArray();
        }
    }
}
