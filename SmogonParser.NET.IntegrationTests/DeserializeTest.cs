using System.Text.Json;
using NUnit.Framework;
using SmogonParser.NET.Parsers.Smogon.Json.Response;

namespace SmogonParser.NET.IntegrationTests
{
    [TestFixture]
    [TestOf(typeof(SmogonResponseConverter))]
    public class DeserializeTest
    {
        [TestCase(TestConstants.InjectRpcsJson)]
        public void Test(string json)
        {
            var response = JsonSerializer.Deserialize<SmogonResponse>(json);

            Assert.NotNull(response);

            foreach (var property in typeof(SmogonResponse).GetProperties())
            {
                var value = property.GetValue(response);
                Assert.NotNull(value);
            }
        }
    }
}
