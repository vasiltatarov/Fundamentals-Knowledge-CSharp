using System;
using System.Collections.Generic;
using System.Text;

namespace _10._Student_Groups
{
    public class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }

        public Student(string name, string email, DateTime registrationDate)
        {
            this.Name = name;
            this.Email = email;
            this.RegistrationDate = registrationDate;
        }
    }
}
