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
    static class UserManager
    {
        // Path of the data base: C:\Users\User\AppData\Local\Packages\95aad623-914b-4326-a644-487cce2a9d68_4sdaedqydyjdm\LocalState

        public static User myUser = null;
        public static void Insert(User user)
        {
            CreateDatabase();
            var sqlpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "UsersDB.sqlite");
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), sqlpath))
            {
                if(Select(user.username) == null)
                {
                    conn.RunInTransaction(() =>
                    {
                        conn.Insert(user);
                    });
                }
            }
        }

        public static User Select(int userID)
        {
            if (SelectAll() == null)
                return null;
            var sqlpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "UsersDB.sqlite");
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), sqlpath))
            {
                var Users = conn.Query<User>("select * from User where user_ID='" + userID +"'").FirstOrDefault();
                return Users;
            }
        }

        public static User Select(string username)
        {
            if (SelectAll() == null)
                return null;
            var sqlpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "UsersDB.sqlite");
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), sqlpath))
            {
                var Users = conn.Query<User>("select * from User where username='" + username +"'").FirstOrDefault();
                return Users;
            }
        }

        public static int FindUser(string username, string password)
        {
            var sqlpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "UsersDB.sqlite");
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), sqlpath))
            {
                var Users = conn.Query<User>("select * from User where username='" + username + "' and password='" + password + "'").FirstOrDefault();
                if (Users != null)
                    return Users.user_ID;
                return -1;
            }
        }

        public static ObservableCollection<User> SelectAll()
        {
            var sqlpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "UsersDB.sqlite");
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), sqlpath))
            {
                List<User> userList = conn.Table<User>().ToList<User>();
                ObservableCollection<User> users = new ObservableCollection<User>(userList);
                return users;
            }
        }

        public static void Update(int id, string username, string mail, string password, bool isAdmin)
        {
            var sqlpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "UsersDB.sqlite");
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), sqlpath))
            {
                var existingconact = conn.Query<User>("select * from User where user_ID =" + id).FirstOrDefault();
                if (existingconact != null)
                {
                    existingconact.username = username;
                    existingconact.mail = mail;
                    existingconact.password = password;
                    existingconact.isAdmin = isAdmin;
                    conn.RunInTransaction(() =>
                    {
                        conn.Update(existingconact);
                    });
                }
            }
        }

        public static void Delete(int id)
        {
            var sqlpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "UsersDB.sqlite");
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), sqlpath))
            {
                var existingconact = conn.Query<User>("select * from User where user_ID =" + id).FirstOrDefault();
                if (existingconact != null)
                {
                    conn.RunInTransaction(() =>
                    {
                        conn.Delete(existingconact);
                    });
                }
            }
        }

        public static void DeleteAll()
        {
            var sqlpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "UsersDB.sqlite");
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), sqlpath))
            {
                conn.DropTable<User>();
                conn.CreateTable<User>();
                conn.Dispose();
                conn.Close();
            }
        }

        public static void CreateDatabase()
        {
            var sqlpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "UsersDB.sqlite");
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), sqlpath))
            {
                conn.CreateTable<User>();
            }
        }
    }
}
