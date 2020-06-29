using System;
using System.Globalization;

namespace Exercises_Objects_and_Classes
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime Date { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }

        public Book(string title, string author, string publisher, DateTime date, string ISBN, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Publisher = publisher;
            this.Date = date;
            this.ISBN = ISBN;
            this.Price = price;
        }

        public static Book ReadBook(string[] input)
        {
            string title = input[0];
            string author = input[1];
            string publisher = input[2];
            DateTime date = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            string ISBN = input[4];
            decimal price = decimal.Parse(input[5]);

            Book newBook = new Book(title, author, publisher, date, ISBN, price);

            return newBook;
        }
    }
}
