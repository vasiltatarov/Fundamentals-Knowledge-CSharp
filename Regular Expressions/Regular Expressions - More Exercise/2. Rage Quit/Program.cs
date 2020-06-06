using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string text = Console.ReadLine();

        StringBuilder result = new StringBuilder();

        var uniqueSymbols = new List<char>();

        string regex = @"([\D]+)([\d]+)";

        var match = Regex.Matches(text, regex);

        foreach (Match item in match)
        {
            string symbols = item.Groups[1].Value;
            int repeat = int.Parse(item.Groups[2].Value);

            for (int i = 0; i < repeat; i++)
            {
                result.Append(symbols.ToUpper());
            }

            foreach (var symbol in symbols.ToUpper())
            {
                if (!uniqueSymbols.Contains(symbol) && !char.IsNumber(symbol))
                {
                    uniqueSymbols.Add(symbol);
                }
            }
        }

        Console.WriteLine($"Unique symbols used: {uniqueSymbols.Count}");
        Console.WriteLine(result);
    }
}
