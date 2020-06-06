using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string[] message = Console.ReadLine().Split("|");

        string capitalLettersRegex = @"([\$|#|%|\*|&])(?<first>[A-Z]+)\1";
        string asciiCodeRegex = @"(\d{2}):(\d{2})";

        Match capitalLetters = Regex.Match(message[0], capitalLettersRegex);
        var lettersAsciiCode = Regex.Matches(message[1], asciiCodeRegex);

        string word = capitalLetters.Groups["first"].Value;

        for (int i = 0; i < word.Length; i++)
        {
            int asciiCode = word[i];
            int asciCode = 0;
            int asciiLength = 0;

            foreach (Match item in lettersAsciiCode)
            {
                if (asciiCode == int.Parse(item.Groups[1].Value))
                {
                    asciCode = int.Parse(item.Groups[1].Value);
                    asciiLength = int.Parse(item.Groups[2].Value) + 1;
                    break;
                }
            }

            string[] separateWords = message[2].Split(" ");

            foreach (var item in separateWords)
            {
                if (item[0] == (char)asciCode && item.Length == asciiLength)
                {
                    Console.WriteLine(item);
                    break;
                }
            }
        }
    }
}
