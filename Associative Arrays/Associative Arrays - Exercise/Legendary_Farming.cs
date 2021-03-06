﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_01
{
    class Program
    {
        /*
Shadowmourne - requires 250 Shards; Valanyr - requires 250 Fragments; Dragonwrath - requires 250 Motes;
Shards, Fragments and Motes are the key materials and everything else is junk. You will be given lines of input, in the format: 
(2 motes 3 ores 15 stones)
Keep track of the key materials - the first one that reaches the 250 mark, wins the race.At that point you have to print that the
corresponding legendary item is obtained. Then, print the remaining shards, fragments, motes, ordered by quantity in descending order,
then by name in ascending order, each on a new line. Finally, print the collected junk items in alphabetical order.
Input 
Each line comes in the following format: {quantity} {material} {quantity} {material} … {quantity} {material}
Output 
On the first line, print the obtained item in the format: {Legendary item} obtained!
On the next three lines, print the remaining key materials in descending order by quantity
If two key materials have the same quantity, print them in alphabetical order
On the final several lines, print the junk items in alphabetical order
All materials are printed in format {material}: {quantity}
The output should be lowercase, except for the first letter of the legendary
         */
        static void Main()
        {
            var legendaryDict = new Dictionary<string, int>
            {
                ["motes"] = 0,
                ["fragments"] = 0,
                ["shards"] = 0,
            };

            var junkDict = new Dictionary<string, int>();

            bool isStop = true;

            while (isStop)
            {
                var materials = Console.ReadLine().Split(" ").ToArray();

                int currentValue = 0;

                for (int i = 0; i < materials.Length; i++)
                {
                    int quantity = 0;
                    string material = "";

                    if (i % 2 == 0)
                    {
                        quantity = int.Parse(materials[i]);
                        currentValue = quantity;
                        continue;
                    }
                    else
                    {
                        material = materials[i].ToLower();
                    }

                    if (legendaryDict.ContainsKey(material))
                    {
                        legendaryDict[material] += currentValue;
                    }
                    else if (junkDict.ContainsKey(material))
                    {
                        junkDict[material] += currentValue;
                    }
                    else
                    {
                        junkDict.Add(material, currentValue);
                    }

                    if (legendaryDict["fragments"] >= 250)
                    {
                        Console.WriteLine($"Valanyr obtained!");
                        legendaryDict["fragments"] -= 250;

                        isStop = false;
                        break;
                    }
                    else if (legendaryDict["shards"] >= 250)
                    {
                        Console.WriteLine($"Shadowmourne obtained!");
                        legendaryDict["shards"] -= 250;

                        isStop = false;
                        break;
                    }
                    else if (legendaryDict["motes"] >= 250)
                    {
                        Console.WriteLine($"Dragonwrath obtained!");
                        legendaryDict["motes"] -= 250;

                        isStop = false;
                        break;
                    }
                }
            }

            var orderLegendaryDict = legendaryDict.OrderByDescending(x => x.Value).ThenBy(x => x.Key);

            foreach (var item in orderLegendaryDict)
            {

                Console.WriteLine(item.Key + ": " + item.Value);
            }

            var orederJunk = junkDict.OrderBy(x => x.Key);

            foreach (var item in orederJunk)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
        }
    }
}
