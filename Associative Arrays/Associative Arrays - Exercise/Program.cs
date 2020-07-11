using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Problem_01
{
    class Program
    {
        static void Main()
        {
            var submissions = new Dictionary<string, Dictionary<string, int>>();
            var languages = new Dictionary<string, int>();
            string command;

            while ((command = Console.ReadLine()) != "exam finished")
            {
                var lines = command.Split("-", StringSplitOptions.RemoveEmptyEntries);

                if (lines[1] == "banned")
                {
                    var username = lines[0];

                    if (submissions.ContainsKey(username))
                    {
                        submissions.Remove(username);
                    }
                }
                else
                {
                    var username = lines[0];
                    var language = lines[1];
                    var points = int.Parse(lines[2]);

                    if (submissions.ContainsKey(username))
                    {
                        if (submissions[username].ContainsKey(language))
                        {
                            if (submissions[username][language] < points)
                            {
                                submissions[username][language] = points;
                            }
                        }
                        else
                        {
                            submissions[username].Add(language, points);
                        }
                    }
                    else
                    {
                        submissions.Add(username, new Dictionary<string, int>());
                        submissions[username].Add(language, points);
                    }

                    if (languages.ContainsKey(language))
                    {
                        languages[language]++;
                    }
                    else
                    {
                        languages.Add(language, 1);
                    }
                }
            }

            Console.WriteLine("Results:");

            submissions = submissions.OrderByDescending(x => x.Value.Values.Max())
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var (name, kvp) in submissions)
            {
                Console.WriteLine($"{name} | {kvp.Values.Max()}");
            }

            Console.WriteLine("Submissions:");

            languages = languages.OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key) 
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var (key, value) in languages)
            {
                Console.WriteLine($"{key} - {value}");
            }
        }
    }
}
