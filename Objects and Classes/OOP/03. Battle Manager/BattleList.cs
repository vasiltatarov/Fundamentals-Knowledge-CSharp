using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Battle_Manager
{
    public class BattleList
    {
        public static List<BattlePerson> Battles { get; set; } = new List<BattlePerson>();

        public static void DeleteAll(string username)
        {
            BattleList.Battles.RemoveRange(0, BattleList.Battles.Count);
        }

        public static void Delete(string username)
        {
            var user = BattleList.Battles.Find(x => x.Name == username);

            if (user != null)
            {
                BattleList.Battles.Remove(user);
            }
        }

        public static void Attack(string attackerName, string defenderName, int damage)
        {
            var attacker = BattleList.Battles.Find(x => x.Name == attackerName);
            var defender = BattleList.Battles.Find(x => x.Name == defenderName);

            if ((attacker != null) && (defender != null))
            {
                defender.Health -= damage;
                attacker.Energy -= 1;

                if (defender.Health <= 0)
                {
                    BattleList.Battles.Remove(defender);

                    Console.WriteLine($"{defenderName} was disqualified!");
                }

                if (attacker.Energy == 0)
                {
                    BattleList.Battles.Remove(attacker);

                    Console.WriteLine($"{attackerName} was disqualified!");
                }
            }
        }

        public static void AddPerson(string name, int health, int energy)
        {
            var person = BattleList.Battles.Find(x => x.Name == name);

            if (person != null)
            {
                person.Health += health;
            }
            else
            {
                BattleList.Battles.Add(BattlePerson.CreatePerson(name, health, energy));
            }
        }
    }
}
