using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Text_Processing___More_Exercise
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var patternName = @"\@(?<name>\w+)\|";
            var patternAge = @"\#(?<age>\d+)\*";

            for (int i = 0; i < n; i++)
            {
                var text = Console.ReadLine();

                var matchName = Regex.Match(text, patternName);
                var matchAge = Regex.Match(text, patternAge);

                //var name = "";
                //var age = "";

                //var nameIndexBegin = text.IndexOf('@');
                //var nameIndexEnd = text.IndexOf('|');

                //var ageIndexBegin = text.IndexOf('#');
                //var ageIndexEnd = text.IndexOf('*');

                //if (nameIndexBegin != -1)
                //{
                //    name = text.Substring(nameIndexBegin + 1, nameIndexEnd - nameIndexBegin - 1);
                //    age = text.Substring(ageIndexBegin + 1, ageIndexEnd - ageIndexBegin - 1);
                //}

                Console.WriteLine($"{matchName.Groups["name"].Value} is {matchAge.Groups["age"].Value} years old.");
            }
        }
    }
}
