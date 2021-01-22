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
            var response = JsonSerializer.Deserialize<SmogonResponse>(json, options);

            Assert.NotNull(response);

            foreach (var property in typeof(SmogonResponse).GetProperties())
            {
                var value = property.GetValue(response);
                Assert.NotNull(value);
            }

            var firstSerializedJson = JsonSerializer.Serialize(response, options);
            var deserializedResponse = JsonSerializer.Deserialize<SmogonResponse>(firstSerializedJson, options);

            Assert.That(response, Is.EqualTo(deserializedResponse));
        }
    }
}
