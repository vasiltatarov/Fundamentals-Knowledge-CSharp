using System;
using System.Linq;
using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main()
    {
        int sizeOfField = int.Parse(Console.ReadLine());
        int[] ladybugsIndexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        var result = new int[sizeOfField];

        for (int i = 0; i < ladybugsIndexes.Length; i++)
        {
            if (ladybugsIndexes[i] >= 0 && ladybugsIndexes[i] < sizeOfField)
            {
                result[ladybugsIndexes[i]] = 1;
            }
        }

        string command = string.Empty;

        while ((command = Console.ReadLine()) != "end")
        {
            string[] ladybugFly = command.Split(" ");

            int ladybugIndex = int.Parse(ladybugFly[0]);
            string direction = ladybugFly[1];
            int flyLength = int.Parse(ladybugFly[2]);

            if (ladybugIndex < 0 || ladybugIndex > result.Length - 1 || result[ladybugIndex] == 0)
            {
                continue;
            }

            result[ladybugIndex] = 0;

            if (direction == "right")
            {
                int flyIndex = ladybugIndex + flyLength;

                while (flyIndex >= 0 && flyIndex < result.Length)
                {
                    if (result[flyIndex] == 0)
                    {
                        result[flyIndex] = 1;
                        break;
                    }
                    else
                    {
                        flyIndex += flyLength;
                    }
                }
            }
            else if (direction == "left")
            {
                int flyIndex = ladybugIndex - flyLength;

                while (flyIndex >= 0 && flyIndex < result.Length)
                {
                    if (result[flyIndex] == 0)
                    {
                        result[flyIndex] = 1;
                        break;
                    }
                    else
                    {
                        flyIndex -= flyLength;
                    }
                }
            }
        }

        Console.WriteLine(string.Join(" ", result));
    }
}
