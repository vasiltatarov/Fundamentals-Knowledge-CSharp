using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercises_Objects_and_Classes
{
    class Student
    {
        public string Name { get; set; }
        public double[] Grades { get; set; }
        public double AverageGrade { get; set; }

        public Student(string name, double[] grades, double avgGrades)
        {
            this.Name = name;
            this.Grades = grades;
            this.AverageGrade = avgGrades;
        }

        public static Student NewStudent(string[] studentGrades)
        {
            string name = studentGrades[0];
            var grades = new double[studentGrades.Length - 1];

            for (int k = 0; k < grades.Length; k++)
            {
                grades[k] = double.Parse(studentGrades[k + 1]);
            }

            double avgGrades = grades.Average();

            Student student = new Student(name, grades, avgGrades);

            return student;
        }
    }
}
