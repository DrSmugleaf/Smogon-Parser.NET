using System.Text.Json;
using NUnit.Framework;
using SmogonParser.NET.Parsers.Smogon.Json.Response;

namespace SmogonParser.NET.IntegrationTests
{
    [TestFixture]
    [TestOf(typeof(SmogonResponseConverter))]
    public class SerializationConsistencyTest
    {
        [TestCase(TestConstants.InjectRpcsJson)]
        public void Test(string json)
        {
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true
            };
            var response = SmogonResponseExtensions.FromJson(json, options);

            Assert.NotNull(response);

            foreach (var property in typeof(SmogonResponse).GetProperties())
            {
                var value = property.GetValue(response);
                Assert.NotNull(value);
            }

            var firstSerializedJson = response.ToJson(options);
            var deserializedResponse = SmogonResponseExtensions.FromJsonOrThrow(firstSerializedJson, options);

            Assert.That(response, Is.EqualTo(deserializedResponse));
        }
    }
}
