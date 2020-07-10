using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_01
{
    class Program
    {
        static void Main()
        {
            var dictionary = new Dictionary<string, List<string>>();

            while (true)
            {
                var lines = Console.ReadLine();

                if (lines == "Lumpawaroo")
                {
                    break;
                }

                if (lines.Contains('|'))
                {
                    var input = lines.Split(" | ", StringSplitOptions.RemoveEmptyEntries);

                    var forceSide = input[0];
                    var forceUser = input[1];

                    if (!dictionary.ContainsKey(forceSide))
                    {
                        dictionary.Add(forceSide, new List<string>());
                    }

                    bool isExist = false;

                    foreach (var kvp in dictionary)
                    {
                        if (kvp.Value.Contains(forceUser))
                        {
                            isExist = true;
                        }
                    }

                    if (!isExist)
                    {
                        dictionary[forceSide].Add(forceUser);
                    }
                }
                else if (lines.Contains('>'))
                {
                    var input = lines.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                    var forceUser = input[0];
                    var forceSide = input[1];

                    bool isExist = false;
                    var side = "";

                    foreach (var kvp in dictionary)
                    {
                        if (kvp.Value.Contains(forceUser))
                        {
                            isExist = true;
                            side = kvp.Key;
                        }
                    }

                    if (isExist)
                    {
                        dictionary[side].Remove(forceUser);
                    }

                    if (!dictionary.ContainsKey(forceSide))
                    {
                        dictionary.Add(forceSide, new List<string>());
                    }

                    dictionary[forceSide].Add(forceUser);

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
            }

            dictionary = dictionary
                .Where(x => x.Value.Count > 0)
                .OrderByDescending(x => x.Value.Count())
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x=> x.Value);

            foreach (var (side, users) in dictionary)
            {
                Console.WriteLine($"Side: {side}, Members: {users.Count}");

                foreach (var user in users.OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}
