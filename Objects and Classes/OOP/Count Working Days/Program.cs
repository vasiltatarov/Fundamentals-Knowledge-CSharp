using System;
using System.Collections.Generic;
using System.Globalization;

namespace Exercises_Objects_and_Classes
{
    class Program
    {
        static void Main()
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateTime startDate = DateTime.ParseExact(firstDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(secondDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var holidays = new List<DateTime>()
            {
                new DateTime(4, 01, 01),
                new DateTime(4, 03, 03),
                new DateTime(4, 05, 01),
                new DateTime(4, 05, 06),
                new DateTime(4, 05, 24),
                new DateTime(4, 09, 06),
                new DateTime(4, 09, 22),
                new DateTime(4, 11, 01),
                new DateTime(4, 12, 24),
                new DateTime(4, 12, 25),
                new DateTime(4, 12, 26),
            };

            int workingdDaysCount = 0;

            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                DateTime temp = new DateTime(4, date.Month, date.Day);

                if ((date.DayOfWeek != DayOfWeek.Saturday) && (date.DayOfWeek != DayOfWeek.Sunday) && !holidays.Contains(temp))
                {
                    workingdDaysCount++;
                }
            }

            Console.WriteLine(workingdDaysCount);
        }
    }
}
