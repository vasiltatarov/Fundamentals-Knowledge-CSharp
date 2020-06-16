using System;
using System.Linq;

namespace _03._Battle_Manager
{
    class Program
    {
        static void Main()
        {
            string lines;

            while ((lines = Console.ReadLine()) != "Results")
            {
                string[] command = lines.Split(":", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Add")
                {
                    string name = command[1];
                    int health = int.Parse(command[2]);
                    int energy = int.Parse(command[3]);

                    BattleList.AddPerson(name, health, energy);
                }
                else if (command[0] == "Attack")
                {
                    string attackerName = command[1];
                    string defenderName = command[2];
                    int damage = int.Parse(command[3]);

                    BattleList.Attack(attackerName, defenderName, damage);
                }
                else if (command[0] == "Delete")
                {
                    string username = command[1];

                    if (command[1] != "All")
                    {
                        BattleList.Delete(username);
                    }
                    else
                    {
                        BattleList.DeleteAll(username);
                    }
                }
            }

            Console.WriteLine($"People count: {BattleList.Battles.Count}");

            foreach (var person in BattleList.Battles.OrderByDescending(x => x.Health).ThenBy(x => x.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Health} - {person.Energy}");
            }
        }
    }
}
