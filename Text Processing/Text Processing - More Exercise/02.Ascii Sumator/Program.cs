using System;

namespace Text_Processing___More_Exercise
{
    class Program
    {
        static void Main()
        {
            var firstChar = char.Parse(Console.ReadLine());
            var secondChar = char.Parse(Console.ReadLine());
            var someText = Console.ReadLine();

            int totalSumOfCharacters = FindSumOfCharactersBetween(firstChar, secondChar, someText);

            Console.WriteLine(totalSumOfCharacters);
        }

        private static int FindSumOfCharactersBetween(char firstChar, char secondChar, string someText)
        {
            var totalSumOfCharacters = 0;

            for (int i = 0; i < someText.Length; i++)
            {
                if (someText[i] > firstChar && someText[i] < secondChar)
                {
                    totalSumOfCharacters += someText[i];
                }
            }

            return totalSumOfCharacters;
        }
    }
}
