using System;

namespace Problem_01
{
    class Program
    {
        static void Main()
        {
            int firstEmployeeEfficiency = int.Parse(Console.ReadLine());
            int secondEmployeeEfficiency = int.Parse(Console.ReadLine());
            int thirdEmployeeEfficiency = int.Parse(Console.ReadLine());
            int totalStudentsCount = int.Parse(Console.ReadLine());

            int allEmloyeesCanHelpOnCountStudents = firstEmployeeEfficiency + secondEmployeeEfficiency + thirdEmployeeEfficiency;
            int allTime = 0;

            while (totalStudentsCount > 0)
            {
                totalStudentsCount -= allEmloyeesCanHelpOnCountStudents;
                allTime++;
            }

            for (int i = 1; i <= allTime; i++)
            {
                if (i % 4 == 0)
                {
                    allTime++;
                }
            }

            Console.WriteLine($"Time needed: {allTime}h.");
        }
    }
}
