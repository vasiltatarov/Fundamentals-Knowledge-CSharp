using System;
using System.Text;

namespace _06.Replace_Repeating_Chars
{
    class Program
    {
        static void Main()
        {
            var text = Console.ReadLine();

            StringBuilder result = ReplaceRepeatingChars(text);

            Console.WriteLine(result);
        }

        private static StringBuilder ReplaceRepeatingChars(string text)
        {
            var result = new StringBuilder();

            var currentLetter = text[0];
            result.Append(currentLetter);

            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] != currentLetter)
                {
                    result.Append(text[i]);
                    currentLetter = text[i];
                }
            }

            return result;
        }
    }
}
