using System;

namespace _01.Valid_Usernames
{
    class Program
    {
        static void Main()
        {
            var names = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var name in names)
            {
                bool isValid = true;

                if (name.Length >= 3 && name.Length <= 16)
                {
                    for (int i = 0; i < name.Length; i++)
                    {
                        if (!char.IsLetterOrDigit(name[i]) && name[i] != '-' && name[i] != '_')
                        {
                            isValid = false;
                        }
                    }

                    if (isValid)
                    {
                        Console.WriteLine(name);
                    }
                }
            }
        }
    }
}
