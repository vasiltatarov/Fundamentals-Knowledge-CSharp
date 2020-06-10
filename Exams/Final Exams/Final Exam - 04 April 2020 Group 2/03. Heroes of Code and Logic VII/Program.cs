using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalExams
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] heroes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Hero hero = new Hero(heroes[0], int.Parse(heroes[1]), int.Parse(heroes[2]));

                Heroes.HeroesList.Add(hero);
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] line = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                if (line[0] == "CastSpell")
                {
                    CastSpell(line);
                }
                else if (line[0] == "TakeDamage")
                {
                    TakeDamage(line);
                }
                else if (line[0] == "Recharge")
                {
                    Recharge(line);
                }
                else if (line[0] == "Heal")
                {
                    Heal(line);
                }
            }

            foreach (var hero in Heroes.HeroesList.OrderByDescending(x => x.Hp).ThenBy(x => x.Name))
            {
                Console.WriteLine($"{hero.Name}");
                Console.WriteLine($"  HP: {hero.Hp}");
                Console.WriteLine($"  MP: {hero.Mp}");
            }
        }


        static void Recharge(string[] line)
        {
            string heroName = line[1];
            int amount = int.Parse(line[2]);

            var match = Heroes.HeroesList.Find(x => x.Name == heroName);

            if (match.Mp + amount > 200)
            {
                Console.WriteLine($"{heroName} recharged for {200 - match.Mp} MP!");
                match.Mp = 200;

                return;
            }

            match.Mp += amount;

            Console.WriteLine($"{heroName} recharged for {amount} MP!");
        }

        static void Heal(string[] line)
        {
            string heroName = line[1];
            int amount = int.Parse(line[2]);

            var match = Heroes.HeroesList.Find(x => x.Name == heroName);

            if (match.Hp + amount > 100)
            {
                Console.WriteLine($"{heroName} healed for {100 - match.Hp} HP!");
                match.Hp = 100;

                return;
            }

            match.Hp += amount;

            Console.WriteLine($"{heroName} healed for {amount} HP!");
        }

        static void TakeDamage(string[] line)
        {
            string heroName = line[1];
            int damage = int.Parse(line[2]);
            string attacker = line[3];

            var match = Heroes.HeroesList.Find(x => x.Name == heroName);

            match.Hp -= damage;

            if (match.Hp > 0)
            {
                Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {match.Hp} HP left!");
            }
            else
            {
                Heroes.HeroesList.Remove(match);

                Console.WriteLine($"{heroName} has been killed by {attacker}!");
            }
        }

        static void CastSpell(string[] line)
        {
            string heroName = line[1];
            int mpNeeded = int.Parse(line[2]);
            string spellName = line[3];

            var match = Heroes.HeroesList.Find(x => x.Name == heroName);

            if (match.Mp >= mpNeeded)
            {
                match.Mp -= mpNeeded;
                Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {match.Mp} MP!");
            }
            else
            {
                Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
            }
        }
    }
}
