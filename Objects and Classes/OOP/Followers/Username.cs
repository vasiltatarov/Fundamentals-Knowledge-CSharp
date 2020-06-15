using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Followers
{
    class Username
    {
        public string User { get; set; }
        public int Likes { get; set; }
        public int Comments { get; set; }

        public Username(string user)
        {
            this.User = user;
            this.Likes = 0;
            this.Comments = 0;
        }

        public static Username Add(string username)
        {
            Username user = new Username(username);

            return user;
        }

        public static Username AddLike(string username, int like)
        {
            Username user = new Username(username);
            user.Likes = like;

            return user;
        }

        public static Username AddComment(string username, int comment)
        {
            Username user = new Username(username);
            user.Comments = 1;

            return user;
        }
    }
}
