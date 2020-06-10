using System;
using System.Collections.Generic;
using System.Text;

namespace FinalExams
{
    public class Hero
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Mp { get; set; }

        public Hero(string name, int hp, int mp)
        {
            this.Name = name;
            this.Hp = hp;
            this.Mp = mp;
        }
    }
}
