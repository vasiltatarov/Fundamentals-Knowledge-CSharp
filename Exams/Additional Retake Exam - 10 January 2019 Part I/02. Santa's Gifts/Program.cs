using System;
using System.Linq;

namespace _02._Santa_s_Gifts
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var houses = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int currentIndex = 0;

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Forward")
                {
                    int numberOfSteps = int.Parse(command[1]);
                    int direction = currentIndex + numberOfSteps;

                    if (direction >= 0 && direction < houses.Count)
                    {
                        houses.RemoveAt(direction);
                        currentIndex = direction;
                    }
                }
                else if (command[0] == "Back")
                {
                    int numberOfSteps = int.Parse(command[1]);
                    int direction = currentIndex - numberOfSteps;

                    if (direction >= 0 && direction < houses.Count)
                    {
                        houses.RemoveAt(direction);
                        currentIndex = direction;
                    }
                }
                else if (command[0] == "Gift")
                {
                    int index = int.Parse(command[1]);
                    int houseNumber = int.Parse(command[2]);

                    if (index >= 0 && index < houses.Count)
                    {
                        houses.Insert(index, houseNumber);
                        currentIndex = index;
                    }
                }
                else if (command[0] == "Swap")
                {
                    int firstHouse = int.Parse(command[1]);
                    int secondHouse = int.Parse(command[2]);

                    if ((houses.Contains(firstHouse)) && (houses.Contains(secondHouse)))
                    {
                        int indexOfFirst = houses.IndexOf(firstHouse);
                        int indexOfSecond = houses.IndexOf(secondHouse);

                        houses[indexOfFirst] = secondHouse;
                        houses[indexOfSecond] = firstHouse;
                    }
                }
            }

            Console.WriteLine($"Position: {currentIndex}");
            Console.WriteLine(string.Join(", ", houses));
        }
    }
}
