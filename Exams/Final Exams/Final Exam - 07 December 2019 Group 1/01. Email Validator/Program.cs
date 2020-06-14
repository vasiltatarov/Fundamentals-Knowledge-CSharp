using System;

namespace _01._Email_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();
            string command;

            while ((command = Console.ReadLine()) != "Complete")
            {
                string[] lines = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (lines[0] == "Make")
                {
                    email = GetLowerOrUpperCase(lines, email);
                }
                else if (lines[0] == "GetDomain")
                {
                    GetDomein(lines, email);
                }
                else if (lines[0] == "GetUsername")
                {
                    GetUsername(lines, email);
                }
                else if (lines[0] == "Replace")
                {
                    email = Replace(lines, email);
                }
                else if (lines[0] == "Encrypt")
                {
                    Encrypt(lines, email);
                }
            }
        }

        static string Replace(string[] lines, string email)
        {
            string result = string.Empty;

            result = email.Replace(char.Parse(lines[1]), '-');

            Console.WriteLine(result);
            return result;
        }

        static void Encrypt(string[] lines, string email)
        {
            for (int i = 0; i < email.Length; i++)
            {
                Console.Write((int)email[i] + " ");
            }

            Console.WriteLine();
        }

        static void GetUsername(string[] lines, string email)
        {
            if (email.Contains('@'))
            {
                for (int i = 0; i < email.Length; i++)
                {
                    if (email[i] == '@')
                    {
                        Console.WriteLine();
                        return;
                    }

                    Console.Write(email[i]);
                }
            }
            else
            {
                Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
            }
        }

        static void GetDomein(string[] lines, string email)
        {
            int count = int.Parse(lines[1]);

            if (count >= 0 && count < email.Length)
            {
                for (int i = email.Length - count; i < email.Length; i++)
                {
                    Console.Write(email[i]);
                }

                Console.WriteLine();
            }
        }

        static string GetLowerOrUpperCase(string[] lines, string email)
        {
            string result = string.Empty;

            if (lines[1] == "Upper")
            {
                result = email.ToUpper();
            }
            else if (lines[1] == "Lower")
            {
                result = email.ToLower();
            }

            Console.WriteLine(result);
            return result;
        }
    }
}
