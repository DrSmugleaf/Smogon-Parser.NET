using System.Net;
using NUnit.Framework;
using SmogonParser.NET.Parsers.Smogon.Json.Response;

namespace SmogonParser.NET.IntegrationTests
{
    [TestFixture]
    [Ignore("Run manually")]
    public class DownloadTest
    {
        [TestCase("rb")]
        [TestCase("gs")]
        [TestCase("rs")]
        [TestCase("dp")]
        [TestCase("bw")]
        [TestCase("xy")]
        [TestCase("sm")]
        [TestCase("ss")]
        public void Test(string generation)
        {
            var response = SmogonResponseExtensions.Download(generation);

            Assert.NotNull(response);

            foreach (var property in typeof(SmogonResponse).GetProperties())
            {
                var value = property.GetValue(response);

                Assert.NotNull(value);
            }
        }

        [TestCase("")]
        public void TestFailure(string generation)
        {
            Assert.Throws<WebException>(() =>
            {
                SmogonResponseExtensions.Download(generation);
            });
        }
    }
}
