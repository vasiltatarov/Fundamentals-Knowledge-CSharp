using System;
using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();

            var pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            var matchedNames = Regex.Matches(input, pattern);

            foreach (var name in matchedNames)
            {
                Console.Write(name + " ");
            }
        }
    }
}
