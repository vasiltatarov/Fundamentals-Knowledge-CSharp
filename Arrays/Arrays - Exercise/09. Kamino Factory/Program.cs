using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] bestArr = new int[n];
        int bestLength = 0;
        int bestIndex = 0;
        int bestSample = 0;
        int currSample = 0;
        int bestSum = 0;

        string line = Console.ReadLine();
        while (line != "Clone them!")
        {
            int[] dna = line.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int currLength = 1;
            int currIndex = 0;
            int currSum = dna.Sum();
            currSample++;

            for (int i = 0; i < dna.Length; i++)
            {
                if (dna[i] == 0)
                {
                    continue;
                }

                for (int index = i+1; index < dna.Length; index++)
                {
                    if (dna[index] == 1)
                    {
                        currLength++;
                        currIndex = i;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if ((currLength > bestLength) ||
                (currLength == bestLength && currIndex < bestIndex) ||
                (currLength == bestLength && currIndex == bestIndex && currSum > bestSum))
            {
                bestLength = currLength;
                bestArr = dna;
                bestIndex = currIndex;
                bestSample = currSample;
                bestSum = currSum;
            }

            line = Console.ReadLine();
        }

        Console.WriteLine($"Best DNA sample {bestSample} with sum: {bestArr.Sum()}.");
        Console.WriteLine(string.Join(" ", bestArr));
    }
}
