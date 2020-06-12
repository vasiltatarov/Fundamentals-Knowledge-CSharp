using System;

namespace test
{
    class Program
    {
        static void Main()
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            decimal firstNumFacturial = GetFacturial(firstNum);
            decimal secondNumFacturial = GetFacturial(secondNum);

            decimal devideFact = devideFacturials(firstNumFacturial, secondNumFacturial);

            Console.WriteLine($"{devideFact:F2}");
        }

        static decimal GetFacturial(int number)
        {
            decimal fact = 1;

            for (int i = 1; i <= number; i++)
            {
                fact *= i;
            }

            return fact;
        }

        static decimal devideFacturials(decimal first, decimal second)
        {
            return first / second;
        }
    }
}
