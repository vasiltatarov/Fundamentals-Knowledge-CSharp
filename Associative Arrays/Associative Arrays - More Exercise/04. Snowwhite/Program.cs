using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary
{
    class Program
    {
        static void Main()
        {
            List<Dwarf> dwarfs = new List<Dwarf>();

            ReadInput(dwarfs);
            PrintDwarfs(dwarfs);
        }

        private static void PrintDwarfs(List<Dwarf> dwarfs)
        {
            foreach (Dwarf dwarf in dwarfs.OrderByDescending(x => x.Physics)
                            .ThenByDescending(x => dwarfs.Count(y => y.Color == x.Color)))
            {
                Console.WriteLine($"({dwarf.Color}) {dwarf.Name} <-> {dwarf.Physics}");
            }
        }

        private static void ReadInput(List<Dwarf> dwarfs)
        {
            string command = Console.ReadLine();
            while (command != "Once upon a time")
            {
                string[] inputs = command.Split(" <:> ");
                string name = inputs[0];
                string color = inputs[1];
                int physics = int.Parse(inputs[2]);

                Dwarf repeat = dwarfs.Find(x => x.Name == name && x.Color == color);
                if (repeat != null)
                {
                    repeat.Physics = Math.Max(repeat.Physics, physics);
                }
                else
                {
                    Dwarf dwarf = new Dwarf(name, color, physics);
                    dwarfs.Add(dwarf);
                }

                command = Console.ReadLine();
            }
        }
    }
}