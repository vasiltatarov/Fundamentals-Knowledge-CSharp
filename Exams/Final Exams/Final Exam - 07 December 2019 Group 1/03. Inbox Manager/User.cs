using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Inbox_Manager
{
    class User
    {
        public string UserName { get; set; }
        public List<string> Emails { get; set; }

        public User(string user)
        {
            this.UserName = user;
            this.Emails = new List<string>();
        }
    }
}
