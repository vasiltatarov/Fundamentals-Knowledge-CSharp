﻿using System;

namespace _02.Character_Multiplier
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split();

            var firstString = input[0];
            var secondString = input[1];

            long totalSum = FindCharactersSum(firstString, secondString);

            Console.WriteLine(totalSum);
        }

        private static long FindCharactersSum(string firstString, string secondString)
        {
            long totalSum = 0;
            int firstIndex = 0;
            int secondIndex = 0;

            while (true)
            {
                int firstChar = 0;
                int secondChar = 0;

                if (firstIndex < firstString.Length)
                {
                    firstChar += firstString[firstIndex];
                }

                firstIndex++;

                if (secondIndex < secondString.Length)
                {
                    secondChar += secondString[secondIndex];
                }

                secondIndex++;

                if (firstChar == 0 && secondChar == 0)
                {
                    break;
                }

                if (firstChar != 0 && secondChar != 0)
                {
                    totalSum += firstChar * secondChar;
                }
                else
                {
                    totalSum += firstChar + secondChar;
                }
            }

            return totalSum;
        }
    }
}
