using System;
using System.Text.RegularExpressions;

namespace _06.ExtractEmails
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();

            var emailPattern = @" [A-Za-z0-9]+[\.-A-Za-z0-9]*@[A-Za-z0-9]+([.-][A-Za-z0-9]+)+";

            var matchedEmails = Regex.Matches(input, emailPattern);

            foreach (Match email in matchedEmails)
            {
                Console.WriteLine(email.ToString().TrimStart());
            }
        }
    }
}
