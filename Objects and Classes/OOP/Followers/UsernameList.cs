using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Followers
{
    class UsernameList
    {
        public static List<Username> Users { get; set; } = new List<Username>();

        public static void Add(string[] command)
        {
            var user = Username.Add(command[1]);

            if (UsernameList.Users.Find(x => x.User == user.User) == null)
            {
                UsernameList.Users.Add(user);
            }
        }

        public static void Like(string[] command)
        {
            string username = command[1];
            int count = int.Parse(command[2]);

            var user = UsernameList.Users.Find(x => x.User == username);

            if (user == null)
            {
                var newUser = Username.AddLike(username, count);
                UsernameList.Users.Add(newUser);
            }
            else
            {
                user.Likes += count;
            }
        }

        public static void Comment(string[] command)
        {
            string username = command[1];

            var user = UsernameList.Users.Find(x => x.User == username);

            if (user == null)
            {
                var newUser = Username.AddComment(username, 1);
                UsernameList.Users.Add(newUser);
            }
            else
            {
                user.Comments += 1;
            }
        }

        public static void Blocked(string[] command)
        {
            string username = command[1];

            var user = UsernameList.Users.Find(x => x.User == username);

            if (user == null)
            {
                Console.WriteLine($"{username} doesn't exist.");
            }
            else
            {
                UsernameList.Users.Remove(user);
            }
        }
    }
}
