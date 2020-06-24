using System;
using System.Collections.Generic;
using System.Text;

namespace _10._Student_Groups
{
    public class Town
    {
        public string Name { get; set; }
        public int SeatsCount { get; set; }
        public List<Student> Students { get; set; }

        public Town(string name, int seats)
        {
            this.Name = name;
            this.SeatsCount = seats;
            this.Students = new List<Student>();
        }
    }
}
