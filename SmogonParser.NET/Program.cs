using SmogonParser.NET.Parsers.Smogon.Json;

namespace SmogonParser.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            new JsonDownloader().Download();
        }
    }
}
