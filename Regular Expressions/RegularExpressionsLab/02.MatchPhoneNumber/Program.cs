using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();

            var pattern = @"\+359([-|| ])2\1\d{3}\1\d{4}\b";

            var matchedPhones = Regex.Matches(input, pattern);

            Console.WriteLine(string.Join(", ", matchedPhones));
        }
    }
}
