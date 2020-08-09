using System;

namespace P01
{
    class Program
    {
        static void Main()
        {
            var destination = Console.ReadLine();
            var initialStr = destination;

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "Travel")
                {
                    break;
                }

                var args = command.Split(':');

                if (args[0] == "Add Stop")
                {
                    var index = int.Parse(args[1]);
                    var str = args[2];

                    if (index >= 0 && index < destination.Length)
                    {
                        destination = destination.Insert(index, str);

                        //Console.WriteLine(destination);
                    }
                }
                else if (args[0] == "Remove Stop")
                {
                    var startIndex = int.Parse(args[1]);
                    var endIndex = int.Parse(args[2]);

                    if (startIndex >= 0 && startIndex < destination.Length && endIndex >= 0 && endIndex < destination.Length)
                    {
                        //var substring = destination.Substring(startIndex, endIndex);
                        destination = destination.Remove(startIndex, endIndex - startIndex + 1);

                        //Console.WriteLine(destination);
                    }
                }
                else if (args[0] == "Switch")
                {
                    var oldString = args[1];
                    var newString = args[2];

                    if (initialStr.Contains(oldString))
                    {
                        destination = destination.Replace(oldString, newString);

                        //Console.WriteLine(destination);
                    }
                }

                Console.WriteLine(destination);
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {destination}");
        }
    }
}
