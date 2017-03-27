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
    static class QuestionManager
    {
        // Path of the data base: C:\Users\User\AppData\Local\Packages\95aad623-914b-4326-a644-487cce2a9d68_4sdaedqydyjdm\LocalState

        public static void Insert(Question question)
        {
            CreateDatabase();
            var sqlpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "QuestionsDB.sqlite");
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), sqlpath))
            {
                if(Select(question.question) == null)
                {
                    conn.RunInTransaction(() =>
                    {
                        conn.Insert(question);
                    });
                }
            }
        }

        public static List<Question> RandQuestions(int range, string subject, int level)
        {
            var sqlpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "QuestionsDB.sqlite");
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), sqlpath))
            {
                string query = "select * from Question where type='" + subject + "' and level=" + level + " ORDER BY RANDOM() LIMIT " + range;
                List<Question> QuestionsList = conn.Query<Question>(query).ToList<Question>();
                return QuestionsList;
            }
        }

        public static Question Select(int question_ID)
        {
            if (SelectAll() == null)
                return null;
            var sqlpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "QuestionsDB.sqlite");
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), sqlpath))
            {
                var Questions = conn.Query<Question>("select * from Question where question_ID=" + question_ID).FirstOrDefault();
                return Questions;
            }
        }

        public static Question Select(string question)
        {
            if (SelectAll() == null)
                return null;
            var sqlpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "QuestionsDB.sqlite");
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), sqlpath))
            {
                string query = "select * from Question where question='" + question + "'";
                var Questions = conn.Query<Question>(query).FirstOrDefault();
                return Questions;
            }
        }

        public static ObservableCollection<Question> SelectAll()
        {
            var sqlpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "QuestionsDB.sqlite");
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), sqlpath))
            {
                List<Question> QuestionsList = conn.Table<Question>().ToList<Question>();
                ObservableCollection<Question> Questions = new ObservableCollection<Question>(QuestionsList);
                return Questions;
            }
        }

        public static void Update(int question_ID, string question, string trueAnswer, string answer_2, string answer_3, string answer_4, int level, string type)
        {
            var sqlpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "QuestionsDB.sqlite");
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), sqlpath))
            {
                var existingconact = conn.Query<Question>("select * from Question where question_ID =" + question_ID).FirstOrDefault();
                if (existingconact != null)
                {
                    existingconact.question = question;
                    existingconact.trueAnswer = trueAnswer;
                    existingconact.answer_2 = answer_2;
                    existingconact.answer_3 = answer_3;
                    existingconact.answer_4 = answer_4;
                    existingconact.level = level;
                    existingconact.type = type;
                    conn.RunInTransaction(() =>
                    {
                        conn.Update(existingconact);
                    });
                }
            }
        }

        public static void Delete(int question_ID)
        {
            var sqlpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "QuestionsDB.sqlite");
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), sqlpath))
            {
                var existingconact = conn.Query<Question>("select * from Question where question_ID =" + question_ID).FirstOrDefault();
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
            var sqlpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "QuestionsDB.sqlite");
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), sqlpath))
            {
                conn.DropTable<Question>();
                conn.CreateTable<Question>();
                conn.Dispose();
                conn.Close();
            }
        }

        public static void CreateDatabase()
        {
            var sqlpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "QuestionsDB.sqlite");
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), sqlpath))
            {
                conn.CreateTable<Question>();
            }
        }
    }
}
