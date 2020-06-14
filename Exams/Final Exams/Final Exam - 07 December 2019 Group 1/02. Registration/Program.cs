using System;
using System.Text.RegularExpressions;

namespace _02._Registration
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string regex = @"U\$(?<name>[A-Z][a-z]{2,})U\$P@\$(?<password>[A-Za-z]{5,}[0-9]+)P@\$";
            int successfulRegistrationsCount = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, regex);

                if (match.Success)
                {
                    successfulRegistrationsCount++;
                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {match.Groups["name"].Value}, Password: {match.Groups["password"].Value}");
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }

            Console.WriteLine($"Successful registrations: {successfulRegistrationsCount}");
        }
    }
}
