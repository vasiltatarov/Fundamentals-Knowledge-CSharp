using System;
using System.Reflection.PortableExecutable;

namespace _08.Letters_Change_Numbers
{
    class Program
    {
        static void Main()
        {
            var text = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double totalSum = 0;

            foreach (var currText in text)
            {
                double currentSum = 0;

                var firstLetter = currText[0];
                var lastLetter = currText[currText.Length - 1];
                var number = double.Parse(currText.Substring(1, currText.Length - 2));

                if (char.IsUpper(firstLetter))
                {
                    currentSum = number / FindUpperLetterPosition(firstLetter);
                }
                else if (char.IsLower(firstLetter))
                {
                    currentSum = number * FindLowerLetterPosition(firstLetter);
                }

                if (char.IsUpper(lastLetter))
                {
                    currentSum = currentSum - FindUpperLetterPosition(lastLetter);
                }
                else if (char.IsLower(lastLetter))
                {
                    currentSum = currentSum + FindLowerLetterPosition(lastLetter);
                }

                totalSum += currentSum;
            }

            Console.WriteLine($"{totalSum:F2}");
        }

        private static int FindLowerLetterPosition(char lastLetter)
        {
            return lastLetter - 96;
        }

        private static int FindUpperLetterPosition(char letter)
        {
            return letter - 64;
        }
    }
}
