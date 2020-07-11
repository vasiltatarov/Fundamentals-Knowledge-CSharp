using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_01
{
    class Program
    {
        /*
Write a program that keeps information about products and their prices. Each product has a name, a price and a quantity.
If the product doesn’t exist yet, add it with its starting quantity.If you receive a product, which already exists,
increase its quantity by the input quantity and if its price is different, replace the price as well.
You will receive products’ names, prices and quantities on new lines. Until you receive the command "buy", keep adding items.
When you do receive the command "buy", print the items with their names and total price of all the products with that name. 
Input
Until you receive "buy", the products will be coming in the format: "{name} {price} {quantity}".
Output
Print information about each product in the following format: "{productName} -> {totalPrice}"
Format the average grade to the 2nd digit after the decimal separator.
         */
        static void Main()
        {
            var products = new Dictionary<string, List<double>>();

            string command = Console.ReadLine();
            while (command != "buy")
            {
                string[] line = command.Split(" ");

                string name = line[0];
                double price = double.Parse(line[1]);
                int quantity = int.Parse(line[2]);

                if (products.ContainsKey(name))
                {
                    products[name][0] = price;
                    products[name][1] += quantity;
                }
                else
                {
                    products.Add(name, new List<double>() { price, quantity });
                }

                command = Console.ReadLine();
            }

            foreach (var item in products)
            {
                double result = item.Value[0] * item.Value[1];
                Console.WriteLine($"{item.Key} -> {result:F2}");
            }
        }
    }
}
