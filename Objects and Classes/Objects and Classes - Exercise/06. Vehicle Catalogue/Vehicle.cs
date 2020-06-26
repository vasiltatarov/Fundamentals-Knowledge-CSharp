using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectAndClasses
{
    public class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }


        public Vehicle(string type, string model, string color, int horsePower)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }

        public override string ToString()
        {
            Console.WriteLine($"Type: {this.Type}");
            Console.WriteLine($"Model: {this.Model}");
            Console.WriteLine($"Color: {this.Color}");
            Console.WriteLine($"Horsepower: {this.HorsePower}");
            return base.ToString(); 
        }
    }
}
