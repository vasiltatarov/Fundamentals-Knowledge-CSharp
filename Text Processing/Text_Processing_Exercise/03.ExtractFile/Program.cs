using System;
using System.Linq;

namespace _03.ExtractFile
{
    class Program
    {
        static void Main()
        {
            var path = Console.ReadLine();

            var fileInfo = path.Split(@"\", StringSplitOptions.RemoveEmptyEntries).ToArray();

            var file = fileInfo[fileInfo.Length - 1];

            var splittedFile = file.Split('.');

            var fileName = splittedFile[0];
            var fileextension = splittedFile[1];

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileextension}");
        }
    }
}
