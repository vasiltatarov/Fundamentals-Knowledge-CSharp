using System;
using System.Linq;

namespace _02._Archery_Tournament
{
    class Program
    {
        static void Main()
        {
            var targets = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string lines;
            int totalPoints = 0;

            while ((lines = Console.ReadLine()) != "Game over")
            {
                var command = lines.Split("@", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Shoot Left")
                {
                    int startIndex = int.Parse(command[1]);
                    int length = int.Parse(command[2]);

                    if (startIndex < 0 || startIndex >= targets.Count)
                    {
                        continue;
                    }

                    int traversingIndex = startIndex - length;

                    while (traversingIndex < 0 || traversingIndex >= targets.Count)
                    {
                        traversingIndex += targets.Count;
                    }

                    if (targets[traversingIndex] < 5)
                    {
                        totalPoints += targets[traversingIndex];
                        targets[traversingIndex] = 0;
                    }
                    else
                    {
                        targets[traversingIndex] -= 5;
                        totalPoints += 5;
                    }
                }
                else if (command[0] == "Shoot Right")
                {
                    int startIndex = int.Parse(command[1]);
                    int length = int.Parse(command[2]);

                    if (startIndex < 0 || startIndex >= targets.Count)
                    {
                        continue;
                    }

                    int traversingIndex = startIndex + length;

                    while (traversingIndex < 0 || traversingIndex >= targets.Count)
                    {
                        traversingIndex -= targets.Count;
                    }

                    if (targets[traversingIndex] < 5)
                    {
                        totalPoints += targets[traversingIndex];
                        targets[traversingIndex] = 0;
                    }
                    else
                    {
                        targets[traversingIndex] -= 5;
                        totalPoints += 5;
                    }
                }
                else if (command[0] == "Reverse")
                {
                    targets.Reverse();
                }
            }

            Console.WriteLine(string.Join(" - ", targets));
            Console.WriteLine($"Iskren finished the archery tournament with {totalPoints} points!");
        }
    }
}
