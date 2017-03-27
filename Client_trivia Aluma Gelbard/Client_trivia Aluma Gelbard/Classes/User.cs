using SQLite.Net;
using SQLite.Net.Attributes;
using SQLite.Net.Platform.WinRT;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_trivia_Aluma_Gelbard.Classes
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int user_ID { get; set; }
        public string username { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public bool isAdmin { get; set; }

        public User(){ }

        public User(string username, string mail, string password)
        {
            this.username = username;
            this.mail = mail;
            this.password = password;
            this.isAdmin = false;
            UserManager.Insert(this);
        }

        public User(string username, string mail, string password, bool isAdmin)
        {
            this.username = username;
            this.mail = mail;
            this.password = password;
            this.isAdmin = isAdmin;
            UserManager.Insert(this);
        }

    }
}
