using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    class Program
    {
        static void Main()
        {
            var emojis = new List<string>();
            string text = Console.ReadLine();
            string regex = @"(::|\*\*)(?<emoj>[A-Z][a-z]{2,})\1";
            int coolThresholdSum = 1;

            foreach (var digit in text)
            {
                if (char.IsDigit(digit))
                {
                    coolThresholdSum *= digit - '0';
                }
            }

            var match = Regex.Matches(text, regex);

            foreach (Match emoj in match)
            {
                string currentEmoj = emoj.Groups["emoj"].Value;
                int currentSumLetters = 0;

                for (int i = 0; i < currentEmoj.Length; i++)
                {
                    currentSumLetters += currentEmoj[i];
                }

                if (currentSumLetters > coolThresholdSum)
                {
                    emojis.Add(emoj.Value);
                }
            }

            Console.WriteLine($"Cool threshold: {coolThresholdSum}");
            Console.WriteLine($"{match.Count} emojis found in the text. The cool ones are:");

            foreach (var emoj in emojis)
            {
                Console.WriteLine(emoj);
            }
        }
    }
}
