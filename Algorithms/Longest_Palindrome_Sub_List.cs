using System;

namespace Longest_Palindrome_Sub_List
{
    class Program
    {
        static void Main()
        {
            FindPalindrome();
        }

        private static void FindPalindrome()
        {
            var letters = Console.ReadLine();
            int maxLength = 0;

            for (int i = 0; i < letters.Length; i++)
            {
                maxLength = Math.Max(maxLength, PalindromeLength(i, i, letters));
            }

            for (int i = 0; i < letters.Length - 1; i++)
            {
                maxLength = Math.Max(maxLength, PalindromeLength(i, i + 1, letters));
            }

            Console.WriteLine(maxLength);
        }

        public static int PalindromeLength(int leftIndex, int rightIndex, string letters)
        {
            while (leftIndex >= 0 && rightIndex < letters.Length && letters[leftIndex] == letters[rightIndex])
            {
                leftIndex--;
                rightIndex++;
            }

            return rightIndex - leftIndex - 1;
        }
    }
}
