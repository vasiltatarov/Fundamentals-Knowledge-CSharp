using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises_Objects_and_Classes
{
    public class Library
    {
        public static List<Book> Books { get; set; } = new List<Book>();

        public static void AddBook(string[] input)
        {
            string author = input[1];
            decimal price = decimal.Parse(input[5]);

            var matchAuthor = Library.Books.Find(x => x.Author == author);

            if (matchAuthor != null)
            {
                matchAuthor.Price += price;
            }
            else
            {
                var newBook = Book.ReadBook(input);
                Library.Books.Add(newBook);
            }
        }

        public static void Print()
        {
            foreach (var author in Library.Books.OrderByDescending(x => x.Price).ThenBy(x => x.Author))
            {
                Console.WriteLine($"{author.Author} -> {author.Price:F2}");
            }
        }
    }
}
