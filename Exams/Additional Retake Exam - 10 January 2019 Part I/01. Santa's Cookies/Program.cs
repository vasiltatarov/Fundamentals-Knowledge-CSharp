using System;

namespace _01._Santa_s_Cookies
{
    class Program
    {
        static void Main()
        {
            int batches = int.Parse(Console.ReadLine());
            int totalBoxes = 0;

            for (int i = 0; i < batches; i++)
            {
                int FlourInGrams = int.Parse(Console.ReadLine());
                int sugarInGrams = int.Parse(Console.ReadLine());
                int cocoaInGrams = int.Parse(Console.ReadLine());

                int flourCups = FlourInGrams / 140;
                int sugarSpoons = sugarInGrams / 20;
                int cocoaSpoons = cocoaInGrams / 10;

                if (flourCups <= 0 || sugarSpoons <= 0 || cocoaSpoons <= 0)
                {
                    Console.WriteLine("Ingredients are not enough for a box of cookies.");
                    continue;
                }

                int totalCookiePerBake = (140 + 10 + 20) * (Math.Min(flourCups, Math.Min(sugarSpoons, cocoaSpoons))) / 25;

                int boxesOfCookiesPerCurrentBake = totalCookiePerBake / 5;

                Console.WriteLine($"Boxes of cookies: {boxesOfCookiesPerCurrentBake}");

                totalBoxes += boxesOfCookiesPerCurrentBake;
            }

            Console.WriteLine($"Total boxes: {totalBoxes}");
        }
    }
}
