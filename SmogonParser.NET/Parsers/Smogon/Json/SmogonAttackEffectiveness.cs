using System.Text.Json.Serialization;

namespace SmogonParser.NET.Parsers.Smogon.Json
{
    [JsonConverter(typeof(SmogonAttackEffectivenessConverter))]
    public class SmogonAttackEffectiveness
    {
        public SmogonAttackEffectiveness(string name, decimal effectiveness)
        {
            Name = name;
            Effectiveness = effectiveness;
        }

        public string Name { get; }

        public decimal Effectiveness { get; }
    }
}
