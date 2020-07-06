using System;
using System.Linq;

namespace Problem_02
{
    class Program
    {
        static void Main()
        {
            var initialArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            while (true)
            {
                var command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "end")
                {
                    break;
                }

                if (command[0] == "swap")
                {
                    int index1 = int.Parse(command[1]);
                    int index2 = int.Parse(command[2]);

                    int elementAtIndex1 = initialArray[index1];

                    initialArray[index1] = initialArray[index2];
                    initialArray[index2] = elementAtIndex1;
                }
                else if (command[0] == "multiply")
                {
                    int index1 = int.Parse(command[1]);
                    int index2 = int.Parse(command[2]);

                    int elementAtFirstIndex = initialArray[index1];
                    elementAtFirstIndex *= initialArray[index2];

                    initialArray[index1] = elementAtFirstIndex;
                }
                else if (command[0] == "decrease")
                {
                    for (int i = 0; i < initialArray.Length; i++)
                    {
                        initialArray[i] -= 1;
                    }
                }
            }


            Console.WriteLine(string.Join(", ", initialArray));
        }
    }
}
