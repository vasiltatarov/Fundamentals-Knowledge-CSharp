using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string[] tickets = Console.ReadLine().Split(new [] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        string regex = @"(\@{6,}|\${6,}|\^{6,}|\#{6,})";

        for (int i = 0; i < tickets.Length; i++)
        {
            if (tickets[i].Length == 20)
            {
                var leftSide = tickets[i].Substring(0, 10);
                var rightSide = tickets[i].Substring(10);

                Match matchLeftSide = Regex.Match(leftSide, regex);
                Match matchRightSide = Regex.Match(rightSide, regex);

                if (matchLeftSide.Success && matchRightSide.Success)
                {
                    var ticketChar = matchLeftSide.Value[0];

                    if (matchLeftSide.Length == matchRightSide.Length)
                    {
                        if (matchLeftSide.Length >= 6 && matchLeftSide.Length <= 9)
                        {
                            Console.WriteLine($"ticket {'"' + tickets[i] + '"'} - {matchLeftSide.Length}{ticketChar}");
                        }
                        else if (matchLeftSide.Length == 10)
                        {
                            Console.WriteLine($"ticket {'"' + tickets[i] + '"'} - {matchLeftSide.Length}{ticketChar} Jackpot!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"ticket {'"' + tickets[i] + '"'} - no match");
                }
            }
            else
            {
                Console.WriteLine("invalid ticket");
            }
        }
    }
}