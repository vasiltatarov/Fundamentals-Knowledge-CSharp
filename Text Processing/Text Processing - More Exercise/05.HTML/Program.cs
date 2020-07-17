using System;
using System.Text;

namespace Text_Processing___More_Exercise
{
    class Program
    {
        static void Main()
        {
            var htmlFile = new StringBuilder();

            var title = Console.ReadLine();
            var content = Console.ReadLine();

            htmlFile.AppendLine("<h1>");
            htmlFile.AppendLine("    " + title);
            htmlFile.AppendLine("</h1>");

            htmlFile.AppendLine("<article>");
            htmlFile.AppendLine("    " + content);
            htmlFile.AppendLine("</article>");

            while (true)
            {
                var comments = Console.ReadLine();

                if (comments == "end of comments")
                {
                    break;
                }

                htmlFile.AppendLine("<div>");
                htmlFile.AppendLine("    " + comments);
                htmlFile.AppendLine("</div>");
            }

            Console.WriteLine(htmlFile);
        }
    }
}
