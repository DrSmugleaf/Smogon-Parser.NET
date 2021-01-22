using System;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using static System.StringComparison;

namespace SmogonParser.NET.Extensions
{
    public static class Utf8JsonReaderExtensions
    {
        public static void GetOrThrow(ref this Utf8JsonReader reader, JsonTokenType expectedToken)
        {
            if (reader.TokenType != expectedToken)
            {
                throw new JsonException($"Expected {expectedToken}, got {reader.TokenType}");
            }
        }

        public static void ReadOrThrow(ref this Utf8JsonReader reader, JsonTokenType expectedToken)
        {
            if (!reader.Read())
            {
                throw new JsonException("Token could not be read.");
            }

            reader.GetOrThrow(expectedToken);
        }

        public static void ReadOrThrow(ref this Utf8JsonReader reader, JsonTokenType expectedToken, int times)
        {
            for (var i = 0; i < times; i++)
            {
                reader.ReadOrThrow(expectedToken);
            }
        }

        public static void ReadOrThrow(ref this Utf8JsonReader reader, params JsonTokenType[] expectedTokens)
        {
            foreach (var token in expectedTokens)
            {
                reader.ReadOrThrow(token);
            }
        }

        public static T ReadOrThrow<T>(ref this Utf8JsonReader reader) where T : notnull
        {
            reader.Read();

            object? value = Type.GetTypeCode(typeof(T)) switch
            {
                TypeCode.Boolean => reader.GetBoolean(),
                TypeCode.Char => reader.GetString()?.ToCharArray().Single(),
                TypeCode.SByte => reader.GetSByte(),
                TypeCode.Byte => reader.GetByte(),
                TypeCode.Int16 => reader.GetInt16(),
                TypeCode.UInt16 => reader.GetUInt16(),
                TypeCode.Int32 => reader.GetInt32(),
                TypeCode.UInt32 => reader.GetUInt32(),
                TypeCode.Int64 => reader.GetInt64(),
                TypeCode.UInt64 => reader.GetUInt64(),
                TypeCode.Single => reader.GetSingle(),
                TypeCode.Double => reader.GetDouble(),
                TypeCode.Decimal => reader.GetDecimal(),
                TypeCode.DateTime => reader.GetDateTime(),
                TypeCode.String => reader.GetString(),
                _ => throw new ArgumentOutOfRangeException()
            };

            return (T) (value ?? throw new NullReferenceException());
        }

        public static T ReadOrThrow<T>(ref this Utf8JsonReader reader, T expectedValue) where T : notnull
        {
            var value = reader.ReadOrThrow<T>();

            if (!value.Equals(expectedValue))
            {
                throw new JsonException($"Expected {expectedValue}, got {value}");
            }

            return value;
        }

        public static T ReadValueOrThrow<T>(
            ref this Utf8JsonReader reader,
            string expectedKey,
            JsonSerializerOptions? options = null)
            where T : notnull
        {
            reader.ReadOrThrow(expectedKey);
            return reader.ReadOrThrow<T>();
        }

        public static string? Read(
            ref this Utf8JsonReader reader,
            string expectedString,
            JsonSerializerOptions? options = null)
        {
            if (!reader.Read())
            {
                return null;
            }

            var str = reader.GetString();

            if (str == null)
            {
                return null;
            }

            var comparison = options?.PropertyNameCaseInsensitive ?? false
                ? InvariantCultureIgnoreCase
                : InvariantCulture;

            if (!str.Equals(expectedString, comparison))
            {
                return null;
            }

            return str;
        }

        public static Match ReadOrThrow(ref this Utf8JsonReader reader, Regex regex)
        {
            var str = reader.ReadOrThrow<string>();

            if (!regex.IsMatch(str))
            {
                throw new JsonException($"Expected string matching {regex}, got {str}");
            }

            return regex.Match(str);
        }
    }
}
