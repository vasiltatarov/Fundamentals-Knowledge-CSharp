using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary
{
    public class Dwarf
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Physics { get; set; }

        public Dwarf(string name, string color, int physics)
        {
            Name = name;
            Color = color;
            Physics = physics;
        }

    }
}
