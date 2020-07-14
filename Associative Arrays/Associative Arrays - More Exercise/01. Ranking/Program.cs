using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_01
{
    class Program
    {
        static void Main()
        {
            var contests = new Dictionary<string, string>();
            var students = new SortedDictionary<string, Dictionary<string, int>>();
            
            ReadContests(contests);
            ReadStudentsInfo(contests, students);
            PrintBestStudent(students);
            PrintStudents(students);
        }

        private static void PrintStudents(SortedDictionary<string, Dictionary<string, int>> students)
        {
            Console.WriteLine("Ranking:");

            foreach (var kvp in students)
            {
                Console.WriteLine(kvp.Key);

                foreach (var contest in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }

        private static void PrintBestStudent(SortedDictionary<string, Dictionary<string, int>> students)
        {
            var user = "";
            int maxPoint = 0;

            foreach (var kvp in students)
            {
                int currentPoints = 0;

                foreach (var point in kvp.Value)
                {
                    currentPoints += point.Value;
                }

                if (currentPoints > maxPoint)
                {
                    maxPoint = currentPoints;
                    user = kvp.Key;
                }
            }

            Console.WriteLine($"Best candidate is {user} with total {maxPoint} points.");
        }

        private static void ReadStudentsInfo(Dictionary<string, string> contests, SortedDictionary<string, Dictionary<string, int>> students)
        {
            while (true)
            {
                var contestInfo = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);

                if (contestInfo[0] == "end of submissions")
                {
                    break;
                }

                var contest = contestInfo[0];
                var password = contestInfo[1];
                var username = contestInfo[2];
                var points = int.Parse(contestInfo[3]);

                if ((contests.ContainsKey(contest)) && (contests[contest] == password))
                {
                    if (!students.ContainsKey(username))
                    {
                        students.Add(username, new Dictionary<string, int>());
                    }

                    if (!students[username].ContainsKey(contest))
                    {
                        students[username].Add(contest, points);
                    }
                    else if (students[username][contest] < points)
                    {
                        students[username][contest] = points;
                    }
                }
            }
        }

        private static void ReadContests(Dictionary<string, string> contests)
        {
            while (true)
            {
                var contestInfo = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);

                if (contestInfo[0] == "end of contests")
                {
                    break;
                }

                var contest = contestInfo[0];
                var contestPoints = contestInfo[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, contestPoints);
                }
            }
        }
    }
}
