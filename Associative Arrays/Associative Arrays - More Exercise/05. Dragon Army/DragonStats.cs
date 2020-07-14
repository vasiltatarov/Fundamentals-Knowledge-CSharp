using System;

namespace Dictionary
{
    public class DragonStats
    {
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }

        public DragonStats(int damage, int health, int armor)
        {
            this.Damage = damage;
            this.Health = health;
            this.Armor = armor;
        }
    }
}
