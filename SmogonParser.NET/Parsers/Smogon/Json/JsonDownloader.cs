using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace SmogonParser.NET.Parsers.Smogon.Json
{
    public class JsonDownloader
    {
        // private static readonly Regex DexSettingsMatcher = new(@"<script type=""text/javascript"">\s+dexSettings = {""injectRpcs"":\[(.+)\].*}\s+</script>\s+</head>");
        private static readonly Regex DexSettingsMatcher = new(@"<script type=""text/javascript"">\s+dexSettings = (.+)\s+</script>\s+</head>");

        public string GetGenerationUrl(string generation)
        {
            return $"https://www.smogon.com/dex/{generation}/pokemon";
        }

        public void Download(string generation = "ss")
        {
            var url = GetGenerationUrl(generation);
            var html = new WebClient().DownloadString(url);
            var match = DexSettingsMatcher.Match(html);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var json = JsonSerializer.Deserialize<SmogonResponse>(match.Groups[1].Value, options);
        }
    }
}
