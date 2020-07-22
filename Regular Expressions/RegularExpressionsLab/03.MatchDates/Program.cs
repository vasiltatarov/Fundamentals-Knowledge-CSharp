using System;
using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();

            var pattern = @"\b(?<day>\d{2})([-|.|\/])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";

            var matchedDates = Regex.Matches(input, pattern);

            foreach (Match date in matchedDates)
            {
                var day = date.Groups["day"].Value;
                var month = date.Groups["month"].Value;
                var year = date.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
