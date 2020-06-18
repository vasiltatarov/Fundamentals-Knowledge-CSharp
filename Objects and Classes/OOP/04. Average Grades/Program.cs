using System;
using System.Linq;

namespace Exercises_Objects_and_Classes
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] studentGrades = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var student = Student.NewStudent(studentGrades);

                Students.StudentList.Add(student);
            }

            var orderedStudentList = Students.StudentList.Where(x => x.AverageGrade >= 5.00).OrderBy(x => x.Name).ThenByDescending(x => x.AverageGrade);

            foreach (var student in orderedStudentList)
            {
                Console.WriteLine($"{student.Name} -> {student.AverageGrade:F2}");
            }
        }
    }
}
