using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_03
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var topGreaterNumbers = new List<int>();

            double sumAverageNumbers = numbers.Average();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > sumAverageNumbers)
                {
                    topGreaterNumbers.Add(numbers[i]);
                }
            }

            if (topGreaterNumbers.Count == 0)
            {
                Console.WriteLine("No");
                return;
            }

            var orderedNumbers = topGreaterNumbers.OrderByDescending(x => x).ToList().Take(5);

            Console.WriteLine(string.Join(" ", orderedNumbers));

            //var orderedNumbers = numbers.Where(x => x > numbers.Average()).OrderByDescending(x => x).Take(5).ToList();

            //topGreaterNumbers.Sort();
            //topGreaterNumbers.Reverse();

            //for (int i = 0; i < orderedNumbers.Count; i++)
            //{
            //    Console.Write($"{orderedNumbers[i]} ");

            //    if (i == 4)
            //    {
            //        break;
            //    }
            //}
        }
    }
}
