using System;
using System.Linq;

namespace _02._Santa_s_Gifts
{
    class Program
    {
        static void Main()
        {
            string[] timeToLeaves = Console.ReadLine().Split(":");
            int numberOfSteps = int.Parse(Console.ReadLine());
            int timeInSecondForEachStep = int.Parse(Console.ReadLine());

            int currentHours = int.Parse(timeToLeaves[0]);
            int currentMinutes = int.Parse(timeToLeaves[1]);
            int currentSeconds = int.Parse(timeToLeaves[2]);
            int timeToLeaveInSeconds = (currentHours * 60 * 60) + (currentMinutes * 60) + (currentSeconds);
            int walkTimeInSeconds = numberOfSteps * timeInSecondForEachStep;
            int allTimeInSeconds = timeToLeaveInSeconds + walkTimeInSeconds;

            int seconds = allTimeInSeconds % 60;
            int minutes = (allTimeInSeconds / 60)  % 60;
            int hours = allTimeInSeconds / 60 / 60;

            if (hours >= 24)
            {
                hours -= 24;
            }

            Console.WriteLine($"Time Arrival: {hours:D2}:{minutes:D2}:{seconds:D2}");
        }
    }
}
