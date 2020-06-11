using System;

namespace FinalExams
{
    class Program
    {
        static void Main()
        {
            string activationKey = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Generate")
            {
                string[] line = command.Split(">>>", StringSplitOptions.RemoveEmptyEntries);
                string newKey = string.Empty;

                if (line[0] == "Contains")
                {
                    IsHavingSubstring(line, activationKey);
                }
                else if (line[0] == "Flip")
                {
                    activationKey = SliceUpperOtLower(line, activationKey);

                    Console.WriteLine(activationKey);
                }
                else if (line[0] == "Slice")
                {
                    activationKey = Slice(line, activationKey);

                    Console.WriteLine(activationKey);
                }
            }

            Console.WriteLine($"Your activation key is: {activationKey}");
        }

        static string SliceUpperOtLower(string[] line, string activationKey)
        {
            string newKey = string.Empty;
            int startIndex = int.Parse(line[2]);
            int endIndex = int.Parse(line[3]);
            string partForUpperOrLowerCase = string.Empty;

            if (line[1] == "Upper")
            {
                for (int i = startIndex; i < endIndex; i++)
                {
                    partForUpperOrLowerCase += activationKey[i].ToString().ToUpper();
                }
            }
            else if (line[1] == "Lower")
            {
                for (int i = startIndex; i < endIndex; i++)
                {
                    partForUpperOrLowerCase += activationKey[i].ToString().ToLower();
                }
            }

            newKey = activationKey.Remove(startIndex, endIndex - startIndex).Insert(startIndex, partForUpperOrLowerCase);
            return newKey;
        }

        static string Slice(string[] line, string activationKey)
        {
            string newKey = string.Empty;
            int startIndex = int.Parse(line[1]);
            int endIndex = int.Parse(line[2]);

            newKey = activationKey.Remove(startIndex, endIndex - startIndex);

            return newKey;
        }

        static void IsHavingSubstring(string[] line, string activationKey)
        {
            string substring = line[1];

            if (activationKey.Contains(substring))
            {
                Console.WriteLine($"{activationKey} contains {substring}");
            }
            else
            {
                Console.WriteLine("Substring not found!");
            }
        }
    }
}
