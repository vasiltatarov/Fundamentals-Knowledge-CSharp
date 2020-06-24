using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _10._Student_Groups
{
    class Program
    {
        static void Main()
        {
            List<Town> towns = new List<Town>();
            List<Group> groups = new List<Group>();
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                ReadTownsAndStudents(input, towns);
            }

            ReadGroups(towns, groups);

            PrintGroups(towns, groups);
        }

        public static void PrintGroups(List<Town> towns, List<Group> groups)
        {
            Console.WriteLine($"Created {groups.Count} groups in {towns.Count} towns:");

            foreach (var group in groups.OrderBy(x => x.Town.Name))
            {
                var emails = new List<string>();

                foreach (var student in group.Students)
                {
                    emails.Add(student.Email);
                }

                Console.WriteLine($"{group.Town.Name} => {string.Join(", ", emails)}");
            }
        }

        public static void ReadGroups(List<Town> towns, List<Group> groups)
        {
            foreach (var town in towns)
            {
                IEnumerable<Student> students = town.Students.OrderBy(x => x.RegistrationDate).ThenBy(x => x.Name).ThenBy(x => x.Email);

                while (students.Any())
                {
                    Group group = new Group();
                    group.Town = town;
                    group.Students = students.Take(group.Town.SeatsCount).ToList();
                    students = students.Skip(group.Town.SeatsCount);
                    groups.Add(group);
                }
            }
        }

        public static void ReadTownsAndStudents(string input, List<Town> towns)
        {
            if (input.Contains('='))
            {
                string[] townArgs = input.Split(new[] { " => " }, StringSplitOptions.RemoveEmptyEntries);
                string[] seatsArgs = townArgs[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string townName = townArgs[0];
                int seatsOfTown = int.Parse(seatsArgs[0]);

                Town town = new Town(townName, seatsOfTown);
                towns.Add(town);
            }
            else
            {
                string[] studentArgs = input.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string name = studentArgs[0].Trim();
                string email = studentArgs[1].Trim();
                DateTime registrationDate = DateTime.ParseExact(studentArgs[2].Trim(), "d-MMM-yyyy", CultureInfo.InvariantCulture);

                Student student = new Student(name, email, registrationDate);
                towns[towns.Count - 1].Students.Add(student);
            }
        }
    }
}
