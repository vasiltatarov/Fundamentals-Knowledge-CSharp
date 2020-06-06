using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        List<string> childrens = new List<string>();

        int key = int.Parse(Console.ReadLine());

        string regex = @"@(?<name>[A-Za-z]+)[^@\-!:>]+?![G]!";

        string message = Console.ReadLine();
        while (message != "end")
        {
            string encrypted = Encrypted(message, key);

            Match match = Regex.Match(encrypted, regex);

            if (match.Success)
            {
                childrens.Add(match.Groups["name"].Value);
            }

            message = Console.ReadLine();
        }

        foreach (var item in childrens)
        {
            Console.WriteLine(item);
        }
    }


    public static string Encrypted(string message, int key)
    {
        string result = "";

        foreach (var item in message)
        {
            result += (char)(item - key);
        }

        return result;
    }
}
