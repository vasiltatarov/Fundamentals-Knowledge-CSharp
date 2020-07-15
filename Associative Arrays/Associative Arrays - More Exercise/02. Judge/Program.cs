using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_01
{
    class Program
    {
        static void Main()
        {
            var users = new Dictionary<string, Dictionary<string, int>>();
            var individualStatistics = new Dictionary<string, int>();

            string command = Console.ReadLine();
            while (command != "no more time")
            {
                string[] line = command.Split(" -> ");
                string username = line[0];
                string contest = line[1];
                int points = int.Parse(line[2]);
                bool itMustSum = false;

                if (!(username.Contains(" ") || contest.Contains(" ")))
                {
                    if (users.ContainsKey(contest))
                    {
                        if (users[contest].ContainsKey(username))
                        {
                            int currentPoints = users[contest][username];

                            if (currentPoints < points)
                            {
                                users[contest][username] = points;
                                points -= currentPoints;

                                itMustSum = true;
                            }
                        }
                        else
                        {
                            users[contest].Add(username, points);
                            itMustSum = true;
                        }
                    }
                    else
                    {
                        users.Add(contest, new Dictionary<string, int>());
                        users[contest].Add(username, points);

                        itMustSum = true;
                    }

                    if (!individualStatistics.ContainsKey(username))
                    {
                        individualStatistics[username] = 0;
                    }

                    if (itMustSum)
                    {
                        individualStatistics[username] += points;
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var contest in users)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Keys.Count} participants");

                int position = 1;

                foreach (var user in contest.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{position++}. {user.Key} <::> {user.Value}");
                }
            }

            Console.WriteLine("Individual standings:");

            int positions = 1;

            foreach (var statistics in individualStatistics.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{positions++}. {statistics.Key} -> {statistics.Value}");
            }
        }
    }
}
