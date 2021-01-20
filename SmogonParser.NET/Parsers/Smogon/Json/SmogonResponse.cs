using System.Text.Json.Serialization;

namespace SmogonParser.NET.Parsers.Smogon.Json
{
    [JsonConverter(typeof(SmogonResponseConverter))]
    public class SmogonResponse
    {
        public SmogonResponse(SmogonDexSettings dexSettings)
        {
            DexSettings = dexSettings;
        }

        public SmogonDexSettings DexSettings { get; }
    }
}
