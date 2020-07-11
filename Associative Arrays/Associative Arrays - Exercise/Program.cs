using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_01
{
    class Program
    {
        /*
Write a program that keeps information about courses. Each course has a name and registered students.
You will be receiving a course name and a student name, until you receive the command "end". Check if such course already exists,
and if not, add the course. Register the user into the course. When you receive the command "end",
print the courses with their names and total registered users, ordered by the count of registered users in descending order.
For each contest print the registered users ordered by name in ascending order.
Input
Until the "end" command is received, you will be receiving input in the format: "{courseName} : {studentName}".
The product data is always delimited by " : ".
Algorithms : Jay Moore
Programming Basics : Martin Taylor
Python Fundamentals : John Anderson
Python Fundamentals : Andrew Robinson
Algorithms : Bob Jackson
Python Fundamentals : Clark Lewis
end
Output
Print the information about each course in the following the format: "{courseName}: {registeredStudents}"
Print the information about each student, in the following the format: "-- {studentName}"
Python Fundamentals: 3
-- Andrew Robinson
-- Clark Lewis
-- John Anderson
Algorithms: 2
-- Bob Jackson
-- Jay Moore
Programming Basics: 1
-- Martin Taylor
         */
        static void Main()
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] courseInfo = command.Split(" : ");
                string courseName = courseInfo[0];
                string studentName = courseInfo[1];

                if (courses.ContainsKey(courseName))
                {
                    courses[courseName].Add(studentName);
                }
                else
                {
                    courses.Add(courseName, new List<string>());
                    courses[courseName].Add(studentName);
                }

                command = Console.ReadLine();
            }

            //var orderCourses = courses.OrderByDescending(x => x.Value.Count);

            foreach (var course in courses.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                foreach (var names in course.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {names}");
                }
            }
        }
    }
}
