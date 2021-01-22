using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using SmogonParser.NET.Parsers.Smogon.Json.Response;

namespace SmogonParser.NET.Parsers.Smogon.Json
{
    public class JsonDownloader
    {
        private static readonly Regex JsonMatcher = new(@"<script type=""text/javascript"">\s+dexSettings = (.+)\s+</script>\s+</head>");

        public string GetGenerationUrl(string generation)
        {
            return $"https://www.smogon.com/dex/{generation}/pokemon";
        }

        public SmogonResponse? Download(string generation)
        {
            var url = GetGenerationUrl(generation);
            var html = new WebClient().DownloadString(url);
            var match = JsonMatcher.Match(html);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<SmogonResponse>(match.Groups[1].Value, options);
        }

        public bool TryDownload(string generation, [NotNullWhen(true)] out SmogonResponse? response)
        {
            return (response = Download(generation)) != null;
        }
    }
}
