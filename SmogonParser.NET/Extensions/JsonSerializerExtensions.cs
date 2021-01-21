using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace SmogonParser.NET.Extensions
{
    public static class JsonSerializerExtensions
    {
        public static T Deserialize<T>(ref this Utf8JsonReader reader, JsonSerializerOptions? options = null)
        {
            return JsonSerializer.Deserialize<T>(ref reader, options) ?? throw new NullReferenceException();
        }

        public static bool TryDeserialize<T>(
            ref this Utf8JsonReader reader,
            [NotNullWhen(true)] out T? value,
            JsonSerializerOptions? options = null)
        {
            return (value = JsonSerializer.Deserialize<T>(ref reader, options)) != null;
        }

        /// <summary>
        ///     Deserializes a named array of type "object": []
        /// </summary>
        /// <param name="reader">The reader to deserialize from.</param>
        /// <param name="expectedKey">The key to look for when deserializing the array.</param>
        /// <param name="options">
        ///     Optional instance of <see cref="JsonSerializerOptions"/> to use.
        /// </param>
        /// <typeparam name="T">The type to deserialize into.</typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(
            ref this Utf8JsonReader reader,
            string expectedKey,
            JsonSerializerOptions? options = null)
        {
            reader.ReadOrThrow(expectedKey);
            var value = reader.Deserialize<T>(options);
            reader.GetOrThrow(JsonTokenType.EndArray);

            return value;
        }
    }
}
