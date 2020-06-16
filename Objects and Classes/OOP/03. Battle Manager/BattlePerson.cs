using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Battle_Manager
{
    public class BattlePerson
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Energy { get; set; }

        public BattlePerson(string name, int health, int energy)
        {
            this.Name = name;
            this.Health = health;
            this.Energy = energy;
        }

        public static BattlePerson CreatePerson(string name, int health, int energy)
        {
            BattlePerson person = new BattlePerson(name, health, energy);

            return person;
        }
    }
}
