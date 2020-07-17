using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Text_Processing___More_Exercise
{
    class Program
    {
        static void Main()
        {
            var keys = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var pattern = @"\&(?<type>\w+)\&[\w]*\<(?<coords>\w+)\>";

            while (true)
            {
                var text = Console.ReadLine();

                if (text == "find")
                {
                    break;
                }

                var sb = FoundCoordinates(keys, text);

                var match = Regex.Match(sb, pattern);

                if (match.Success)
                {
                    var type = match.Groups["type"].Value;
                    var coordinates = match.Groups["coords"].Value;

                    Console.WriteLine($"Found {type} at {coordinates}");
                }

                //var typeBeginIndex = sb.IndexOf('&');
                //var typeEndIndex = sb.LastIndexOf('&');

                //var coordinatesBeginIndex = sb.IndexOf('<');
                //var coordinatesEndIndex = sb.LastIndexOf('>');

                //var type = sb.Substring(typeBeginIndex + 1, typeEndIndex - typeBeginIndex - 1);
                //var coordinates = sb.Substring(coordinatesBeginIndex + 1, coordinatesEndIndex - coordinatesBeginIndex - 1);
            }
        }

        private static string FoundCoordinates(int[] keys, string text)
        {
            var sb = new StringBuilder();
            int indexOfKey = 0;

            for (int i = 0; i < text.Length; i++)
            {
                sb.Append((char)(text[i] - keys[indexOfKey]));
                indexOfKey++;

                if (indexOfKey == keys.Length)
                {
                    indexOfKey = 0;
                }
            }

            return sb.ToString();
        }
    }
}
