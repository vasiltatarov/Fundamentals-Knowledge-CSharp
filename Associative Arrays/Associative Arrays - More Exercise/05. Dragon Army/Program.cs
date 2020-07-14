using Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_01
{
    class Program
    {
        static void Main()
        {
            var dragons = new Dictionary<string, SortedDictionary<string, DragonStats>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                ReadDragons(dragons);
            }

            PrintDragons(dragons);
        }

        private static void PrintDragons(Dictionary<string, SortedDictionary<string, DragonStats>> dragons)
        {
            foreach (var kvp in dragons)
            {
                var maxDamage = dragons[kvp.Key].Select(x => x.Value.Damage).ToList();
                var maxHealth = dragons[kvp.Key].Select(x => x.Value.Health).ToList();
                var maxArmor = dragons[kvp.Key].Select(x => x.Value.Armor).ToList();

                Console.WriteLine($"{kvp.Key}::({maxDamage.Average():F2}/{maxHealth.Average():F2}/{maxArmor.Average():F2})");

                foreach (var (name, stats) in kvp.Value)
                {
                    Console.WriteLine($"-{name} -> damage: {stats.Damage}, health: {stats.Health}, armor: {stats.Armor}");
                }
            }
        }

        private static void ReadDragons(Dictionary<string, SortedDictionary<string, DragonStats>> dragons)
        {
            var typeOfDragon = Console.ReadLine().Split();

            var type = typeOfDragon[0];
            var name = typeOfDragon[1];
            var damage = typeOfDragon[2];
            var health = typeOfDragon[3];
            var armor = typeOfDragon[4];

            if (damage == "null")
            {
                damage = "45";
            }
            if (health == "null")
            {
                health = "250";
            }
            if (armor == "null")
            {
                armor = "10";
            }

            if (!dragons.ContainsKey(type))
            {
                dragons.Add(type, new SortedDictionary<string, DragonStats>());
            }

            var stats = new DragonStats(int.Parse(damage), int.Parse(health), int.Parse(armor));

            if (!dragons[type].ContainsKey(name))
            {
                dragons[type].Add(name, stats);
            }
            else
            {
                dragons[type][name] = stats;
            }
        }
    }
}
