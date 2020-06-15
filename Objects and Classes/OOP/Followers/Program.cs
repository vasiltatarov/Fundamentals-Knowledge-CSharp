using System;
using System.Linq;

namespace _03._Followers
{
    class Program
    {
        static void Main()
        {
            string lines;

            while ((lines = Console.ReadLine()) != "Log out")
            {
                string[] command = lines.Split(": ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "New follower")
                {
                    UsernameList.Add(command);
                }
                else if (command[0] == "Like")
                {
                    UsernameList.Like(command);
                }
                else if (command[0] == "Comment")
                {
                    UsernameList.Comment(command);
                }
                else if (command[0] == "Blocked")
                {
                    UsernameList.Blocked(command);
                }
            }

            Console.WriteLine($"{UsernameList.Users.Count} followers");

            foreach (var item in UsernameList.Users.OrderByDescending(x => x.Likes).ThenBy(x => x.User))
            {
                Console.WriteLine($"{item.User}: {item.Likes + item.Comments}");
            }
        }
    }
}
