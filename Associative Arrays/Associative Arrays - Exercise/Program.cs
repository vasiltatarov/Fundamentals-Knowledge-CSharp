using System;
using System.Collections.Generic;

namespace Problem_01
{
    class Program
    {
        //Write a program that counts all characters in a string except for space(' '). 
        //Print all the occurrences in the following format:
        //{char} -> {occurrences}

        static void Main()
        {
            string word = Console.ReadLine();

            var countChars = new Dictionary<char, int>();

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] != ' ')
                {
                    if (countChars.ContainsKey(word[i]))
                    {
                        countChars[word[i]]++;
                    }
                    else
                    {
                        countChars.Add(word[i], 1);
                    }
                }
            }

            foreach (var item in countChars)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
