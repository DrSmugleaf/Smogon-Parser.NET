using System;
using System.Diagnostics.CodeAnalysis;
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

        public static T ReadOrThrow<T>(ref this Utf8JsonReader reader)
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

        public static T ReadValueOrThrow<T>(
            ref this Utf8JsonReader reader,
            string expectedKey,
            StringComparison comparison = InvariantCultureIgnoreCase)
        {
            reader.ReadOrThrow(expectedKey, comparison);
            return reader.ReadOrThrow<T>();
        }

        public static bool TryRead(ref this Utf8JsonReader reader, JsonTokenType expectedToken)
        {
            return reader.Read() && reader.TokenType == expectedToken;
        }

        public static string? Read(
            ref this Utf8JsonReader reader,
            string expectedString,
            StringComparison comparison = InvariantCultureIgnoreCase)
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

            if (!str.Equals(expectedString, comparison))
            {
                return null;
            }

            return str;
        }

        public static string ReadOrThrow(
            ref this Utf8JsonReader reader,
            string expectedString,
            StringComparison comparison = InvariantCultureIgnoreCase)
        {
            if (!reader.TryRead(expectedString, out var val, comparison))
            {
                throw new JsonException($"Expected {expectedString}, got {val}");
            }

            return val;
        }

        public static void ReadOrThrow(ref this Utf8JsonReader reader, Regex regex)
        {
            var str = reader.ReadStringOrThrow();

            if (!regex.IsMatch(str))
            {
                throw new JsonException($"Expected string matching {regex}, got {str}");
            }
        }

        public static bool TryRead(
            ref this Utf8JsonReader reader,
            string expectedString,
            [NotNullWhen(true)] out string? str,
            StringComparison comparison = InvariantCultureIgnoreCase)
        {
            return (str = reader.Read(expectedString, comparison)) != null;
        }

        public static bool TryRead(
            ref this Utf8JsonReader reader,
            string expectedString,
            StringComparison comparison = InvariantCultureIgnoreCase)
        {
            return reader.Read(expectedString, comparison) != null;
        }

        public static string? ReadString(ref this Utf8JsonReader reader)
        {
            if (!reader.Read())
            {
                return null;
            }

            if (reader.TokenType != JsonTokenType.String)
            {
                return null;
            }

            return reader.ReadString();
        }

        public static string ReadStringOrThrow(ref this Utf8JsonReader reader)
        {
            reader.ReadOrThrow(JsonTokenType.String);
            return reader.GetString() ?? throw new NullReferenceException();
        }

        public static bool TryReadString(
            ref this Utf8JsonReader reader,
            [NotNullWhen(true)] out string? val)
        {
            if (!reader.TryRead(JsonTokenType.String))
            {
                val = null;
                return false;
            }

            val = reader.GetString();
            return val != null;
        }

        public static int ReadIntOrThrow(ref this Utf8JsonReader reader)
        {
            reader.ReadOrThrow(JsonTokenType.Number);
            return reader.GetInt32();
        }

        public static float ReadFloatOrThrow(ref this Utf8JsonReader reader)
        {
            reader.ReadOrThrow(JsonTokenType.Number);
            return reader.GetSingle();
        }
    }
}
