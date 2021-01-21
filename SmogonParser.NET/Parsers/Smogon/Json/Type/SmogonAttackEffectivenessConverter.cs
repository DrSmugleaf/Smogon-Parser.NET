using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using SmogonParser.NET.Extensions;

namespace SmogonParser.NET.Parsers.Smogon.Json.Type
{
    public class SmogonAttackEffectivenessConverter : JsonConverter<SmogonAttackEffectiveness>
    {
        public override SmogonAttackEffectiveness Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
        {
            var name = reader.ReadStringOrThrow();
            var effectiveness = reader.ReadOrThrow<decimal>();

            reader.ReadOrThrow(JsonTokenType.EndArray);

            return new SmogonAttackEffectiveness(name, effectiveness);
        }

        public override void Write(Utf8JsonWriter writer, SmogonAttackEffectiveness value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
