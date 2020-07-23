using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    class Program
    {
        static void Main()
        {
            var attackedPlanets = new List<string>();
            var destroyedPlanets = new List<string>();

            int n = int.Parse(Console.ReadLine());

            var keyPattern = @"[sStTaArR]";
            var decryptedMessagePattern = @"@(?<name>[A-Za-z]+)[^@\-!:>]*:(?<population>\d+)[^@\-!:>]*!(?<type>A|D)![^@\-!:>]*->(?<soldiers>\d+)";

            for (int i = 0; i < n; i++)
            {
                var message = Console.ReadLine();

                var key = Regex.Matches(message, keyPattern).Count;

                var decryptedMessage = DecryptMessage(key, message);

                var matchPlanet = Regex.Match(decryptedMessage, decryptedMessagePattern);

                if (matchPlanet.Success)
                {
                    var planetName = matchPlanet.Groups["name"].Value;
                    var attackType = char.Parse(matchPlanet.Groups["type"].Value);

                    if (attackType == 'A')
                    {
                        attackedPlanets.Add(planetName);
                    }
                    else if (attackType == 'D')
                    {
                        destroyedPlanets.Add(planetName);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

            foreach (var planet in attackedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            foreach (var planet in destroyedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }
        }

        static string DecryptMessage(int key, string message)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < message.Length; i++)
            {
                sb.Append((char)(message[i] - key));
            }

            return sb.ToString();
        }
    }
}
