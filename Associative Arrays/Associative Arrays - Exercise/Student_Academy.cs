﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_01
{
    class Program
    {
        /*
Write a program that keeps information about students and their grades.
You will receive n pair of rows. First you will receive the student's name, after that you will receive his grade.
Check if the student already exists and if not, add him. Keep track of all grades for each student.
When you finish reading the data, keep the students with average grade higher than or equal to 4.50.
Order the filtered students by average grade in descending order.
Print sudents and their average grade in the following format:{name} –> {averageGrade} Format average grade to the 2nd decimal place.
         */
        static void Main()
        {
            var students = new Dictionary<string, List<double>>();

            int countStudent = int.Parse(Console.ReadLine());

            for (int i = 0; i < countStudent; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (students.ContainsKey(name))
                {
                    students[name].Add(grade);
                }
                else
                {
                    students.Add(name, new List<double>());
                    students[name].Add(grade);
                }
            }

            var orderStudents = students.AsEnumerable().OrderByDescending(x => x.Value.Average());

            foreach (var item in orderStudents)
            {
                double currentGrade = item.Value.Average();

                if (currentGrade >= 4.50)
                {
                    Console.WriteLine($"{item.Key} -> {currentGrade:F2}");
                }
            }
        }
    }
}
