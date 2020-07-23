using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.Race
{
    class Program
    {
        static void Main()
        {
            var participants = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            var racers = new Dictionary<string, int>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "end of race")
                {
                    break;
                }

                var name = string.Empty;
                var distance = 0;

                for (int i = 0; i < input.Length; i++)
                {
                    if (char.IsLetter(input[i]))
                    {
                        name += input[i];
                    }
                    else if (char.IsDigit(input[i]))
                    {
                        distance += input[i] - '0';
                    }
                }

                if (participants.Contains(name))
                {
                    if (racers.ContainsKey(name))
                    {
                        racers[name] += distance;
                    }
                    else
                    {
                        racers.Add(name, distance);
                    }
                }
            }

            var count = 1;

            foreach (var (name, time) in racers.OrderByDescending(x => x.Value))
            {
                if (count == 1)
                {
                    Console.WriteLine($"{count}st place: {name}");
                }
                else if (count == 2)
                {
                    Console.WriteLine($"{count}nd place: {name}");
                }
                else if (count == 3)
                {
                    Console.WriteLine($"{count}rd place: {name}");
                }

                count++;

                if (count == 4)
                {
                    return;
                }
            }
        }
    }
}
