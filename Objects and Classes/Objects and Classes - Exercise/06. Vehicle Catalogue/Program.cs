using System;
using System.Collections.Generic;
using System.Linq;

namespace ObjectAndClasses
{
    class Program
    {
        static void Main()
        {
            var vehicles = new List<Vehicle>();
            string line;

            while ((line = Console.ReadLine()) != "End")
            {
                string[] input = line.Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries);
                string type = input[0];
                string model = input[1];
                string color = input[2];
                int horsePower = int.Parse(input[3]);

                if (type == "car")
                {
                    Vehicle car = new Vehicle("Car", model, color, horsePower);
                    vehicles.Add(car);
                }
                else if (type == "truck")
                {
                    Vehicle truck = new Vehicle("Truck", model, color, horsePower);
                    vehicles.Add(truck);
                }
            }

            string modelOfVehicle;

            while ((modelOfVehicle = Console.ReadLine()) != "Close the Catalogue")
            {
                if (vehicles.Exists(x => x.Model == modelOfVehicle))
                {
                    var findModel = vehicles.Find(x => x.Model == modelOfVehicle);
                    findModel.ToString();
                }
            }

            var cars = vehicles.Where(x => x.Type == "Car").ToList();
            var trucks = vehicles.Where(x => x.Type == "Truck").ToList();

            double carsAvgHorsepower = cars.Count > 0 ? cars.Average(x => x.HorsePower) : 0.0;
            double trucksAvgHorsepower = trucks.Count > 0 ? trucks.Average(x => x.HorsePower) : 0.0;

            Console.WriteLine($"Cars have average horsepower of: {carsAvgHorsepower:F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucksAvgHorsepower:F2}.");
        }
    }
}