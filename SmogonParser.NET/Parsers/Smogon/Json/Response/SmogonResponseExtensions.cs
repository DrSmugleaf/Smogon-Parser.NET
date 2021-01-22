using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace SmogonParser.NET.Parsers.Smogon.Json.Response
{
    [PublicAPI]
    public static class SmogonResponseExtensions
    {
        private static readonly Regex JsonMatcher = new(@"<script type=""text/javascript"">\s+dexSettings = (.+)\s+</script>\s+</head>");

        public static string GetGenerationUrl(string generation)
        {
            return $"https://www.smogon.com/dex/{generation}/pokemon";
        }

        public static SmogonResponse? Download(string generation, JsonSerializerOptions? options = null)
        {
            var url = GetGenerationUrl(generation);
            var html = new WebClient().DownloadString(url);
            var match = JsonMatcher.Match(html);

            return JsonSerializer.Deserialize<SmogonResponse>(match.Groups[1].Value, options);
        }

        public static SmogonResponse DownloadOrThrow(string generation, JsonSerializerOptions? options = null)
        {
            return Download(generation, options) ?? throw new NullReferenceException();
        }

        public static bool TryDownload(string generation, [NotNullWhen(true)] out SmogonResponse? response)
        {
            return (response = Download(generation)) != null;
        }

        public static SmogonResponse? FromJson(string json, JsonSerializerOptions? options = null)
        {
            return JsonSerializer.Deserialize<SmogonResponse>(json, options);
        }

        public static SmogonResponse FromJsonOrThrow(string json, JsonSerializerOptions? options = null)
        {
            return FromJson(json, options) ?? throw new NullReferenceException();
        }

        public static bool TryFromJson(
            string json,
            [NotNullWhen(true)] out SmogonResponse? response,
            JsonSerializerOptions? options = null)
        {
            return (response = FromJson(json, options)) != null;
        }

        public static string ToJson(this SmogonResponse response, JsonSerializerOptions? options = null)
        {
            return JsonSerializer.Serialize(response, options);
        }
    }
}
