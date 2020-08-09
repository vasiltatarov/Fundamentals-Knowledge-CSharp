using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P02
{
    class Program
    {
        static void Main()
        {
            var places = Console.ReadLine();

            var pattern = @"([\=\/])(?<dest>[A-Z][a-zA-Z]{2,})\1";

            var match = Regex.Matches(places, pattern);

            var travelPoints = 0;
            var listOfMatches = new List<string>();

            foreach (Match place in match)
            {
                if (place.Success)
                {
                    var currMatch = place.Groups["dest"].Value;

                    var currLength = currMatch.Length;

                    travelPoints += currLength;

                    listOfMatches.Add(currMatch);
                }
                
            }

            Console.WriteLine($"Destinations: {string.Join(", ", listOfMatches)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
