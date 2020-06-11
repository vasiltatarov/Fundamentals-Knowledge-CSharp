using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._P_rates
{
    class Program
    {
        static void Main()
        {
            string cityes;
            while ((cityes = Console.ReadLine()) != "Sail")
            {
                string[] cityArgs = cityes.Split("||", StringSplitOptions.RemoveEmptyEntries);

                City city = new City(cityArgs[0], int.Parse(cityArgs[1]), int.Parse(cityArgs[2]));
                var exist = Cityes.CityList.Find(x => x.CityName == cityArgs[0]);

                if (exist != null)
                {
                    exist.Population += int.Parse(cityArgs[1]);
                    exist.Gold += int.Parse(cityArgs[2]);
                }
                else
                {
                    Cityes.CityList.Add(city);
                }
            }

            string events;
            while ((events = Console.ReadLine()) != "End")
            {
                string[] command = events.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                var match = Cityes.CityList.Find(x => x.CityName == command[1]);

                if (command[0] == "Plunder")
                {
                    string town = command[1];
                    int people = int.Parse(command[2]);
                    int gold = int.Parse(command[3]);

                    match.Population -= people;
                    match.Gold -= gold;

                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                    if (match.Population <= 0 || match.Gold <= 0)
                    {
                        Console.WriteLine($"{town} has been wiped off the map!");
                        Cityes.CityList.Remove(match);
                    }
                }
                else if (command[0] == "Prosper")
                {
                    string town = command[1];
                    int gold = int.Parse(command[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        continue;
                    }

                    match.Gold += gold;
                    Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {match.Gold} gold.");
                }
            }

            if (Cityes.CityList.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {Cityes.CityList.Count} wealthy settlements to go to:");

                foreach (var city in Cityes.CityList.OrderByDescending(x => x.Gold).ThenBy(x => x.CityName))
                {
                    Console.WriteLine($"{city.CityName} -> Population: {city.Population} citizens, Gold: {city.Gold} kg");
                }
            }
        }
    }
}
