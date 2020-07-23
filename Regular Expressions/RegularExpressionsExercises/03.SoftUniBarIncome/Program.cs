using System;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    class Program
    {
        static void Main()
        {
            var pattern = @"%(?<customer>[A-Z][a-z]+)%[^\|\$\%\.]*<(?<product>\w+)>[^\||\$|\%|\.]*\|(?<count>\d+)\|[^\||\$|\%|\.|\d]*(?<price>\d+[.]?\d*)\$";
            double totalIncome = 0;

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "end of shift")
                {
                    break;
                }

                var matchInput = Regex.Match(input, pattern);

                totalIncome = IsMatchSuccess(totalIncome, matchInput);
            }

            Console.WriteLine($"Total income: {totalIncome:F2}");
        }

        private static double IsMatchSuccess(double totalIncome, Match matchInput)
        {
            if (matchInput.Success)
            {
                var customerName = matchInput.Groups["customer"].Value;
                var product = matchInput.Groups["product"].Value;
                var count = int.Parse(matchInput.Groups["count"].Value);
                var totalPrice = double.Parse(matchInput.Groups["price"].Value);

                totalIncome += totalPrice * count;

                Console.WriteLine($"{customerName}: {product} - {totalPrice * count:F2}");
            }

            return totalIncome;
        }
    }
}
