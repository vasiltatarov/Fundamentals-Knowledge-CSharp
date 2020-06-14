using System;
using System.Linq;

namespace _03._Inbox_Manager
{
    class Program
    {
        static void Main()
        {
            string lines;

            while ((lines = Console.ReadLine()) != "Statistics")
            {
                string[] emails = lines.Split("->", StringSplitOptions.RemoveEmptyEntries);

                if (emails[0] == "Add")
                {
                    var match = Users.UsersList.Find(x => x.UserName == emails[1]);

                    if (match != null)
                    {
                        Console.WriteLine($"{match.UserName} is already registered");
                    }
                    else
                    {
                        User user = new User(emails[1]);
                        Users.UsersList.Add(user);
                    }
                }
                else if (emails[0] == "Send")
                {
                    string username = emails[1];
                    string email = emails[2];

                    var match = Users.UsersList.Find(x => x.UserName == username);

                    if (match != null)
                    {
                        match.Emails.Add(email);
                    }
                }
                else if (emails[0] == "Delete")
                {
                    string username = emails[1];

                    var match = Users.UsersList.Find(x => x.UserName == username);

                    if (match != null)
                    {
                        Users.UsersList.Remove(match);
                    }
                    else
                    {
                        Console.WriteLine($"{username} not found!");
                    }
                }
            }

            Console.WriteLine($"Users count: {Users.UsersList.Count}");

            foreach (var user in Users.UsersList.OrderByDescending(x => x.Emails.Count).ThenBy(x => x.UserName))
            {
                Console.WriteLine(user.UserName);

                foreach (var item in user.Emails)
                {
                    Console.WriteLine(" - " + item);
                }
            }
        }
    }
}
