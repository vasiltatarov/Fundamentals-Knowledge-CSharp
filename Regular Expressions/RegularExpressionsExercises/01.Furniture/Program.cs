using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    class Program
    {
        static void Main()
        {
            double totalSpendMoney = 0;
            var pattern = @">>(?<item>\w+)<<(?<price>\d+[.]?\d*)!(?<quantity>\d+)";
            var boughtFurniture = new List<string>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Purchase")
                {
                    break;
                }

                var matchFurniture = Regex.Match(input, pattern);

                if (matchFurniture.Success)
                {
                    var furniture = matchFurniture.Groups["item"].Value;
                    var price = double.Parse(matchFurniture.Groups["price"].Value);
                    var quantity = int.Parse(matchFurniture.Groups["quantity"].Value);

                    boughtFurniture.Add(furniture);
                    totalSpendMoney += price * quantity;
                }
            }

            Console.WriteLine("Bought furniture:");

            foreach (var furniture in boughtFurniture)
            {
                Console.WriteLine(furniture);
            }

            Console.WriteLine($"Total money spend: {totalSpendMoney:F2}");
        }
    }
}
