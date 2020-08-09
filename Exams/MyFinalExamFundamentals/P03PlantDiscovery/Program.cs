using System;
using System.Collections.Generic;
using System.Linq;

namespace P03
{
    public class Plant
    {
        public Plant(int rarity)
        {
            this.Rarity = rarity;
            this.Ratings = new List<double>();
        }

        public int Rarity { get; set; }
        public List<double> Ratings { get; set; }
        public double RatingAvg { get; set; }
    }

    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var plants = new Dictionary<string, Plant>();

            for (int i = 0; i < n; i++)
            {
                var plantsArgs = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);

                var plant = plantsArgs[0];
                var rarity = int.Parse(plantsArgs[1]);

                if (plants.ContainsKey(plant))
                {
                    plants[plant].Rarity = rarity;
                }
                else
                {
                    plants.Add(plant, new Plant(rarity));
                }
            }

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "Exhibition")
                {
                    break;
                }

                var args = command.Split(new[] { " - ", " " }, StringSplitOptions.RemoveEmptyEntries);

                if (args[0] == "Rate:")
                {
                    var plant = args[1];
                    var rating = double.Parse(args[2]);

                    if (plants.ContainsKey(plant))
                    {
                        plants[plant].Ratings.Add(rating);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (args[0] == "Update:")
                {
                    var plant = args[1];
                    var newRarity = int.Parse(args[2]);

                    if (plants.ContainsKey(plant))
                    {
                        plants[plant].Rarity = newRarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (args[0] == "Reset:")
                {
                    var plant = args[1];

                    if (plants.ContainsKey(plant))
                    {
                        plants[plant].Ratings = new List<double>();
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else
                {
                    Console.WriteLine("error");
                }
            }

            Console.WriteLine("Plants for the exhibition:");

            foreach (var plant in plants)
            {
                if (plant.Value.Ratings.Count != 0)
                {
                    plant.Value.RatingAvg = plant.Value.Ratings.Average();
                }
            }

            foreach (var (plant, rating) in plants.OrderByDescending(x => x.Value.Rarity).ThenByDescending(x => x.Value.RatingAvg))
            {
                Console.WriteLine($"- {plant}; Rarity: {rating.Rarity}; Rating: {rating.RatingAvg:F2}");
            }
        }
    }
}
