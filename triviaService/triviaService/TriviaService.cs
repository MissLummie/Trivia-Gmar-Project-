using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triviaService {
    public class TriviaService : ITriviaService {

        /* Delete a score according to ID */
        public bool DeleteScore(int user_id) {
            string ConnectionString = @"Data Source = HP-15\SQLEXPRESS; Initial Catalog = trivia_database; Integrated Security = True";
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = string.Format("DELETE FROM score WHERE user_id = {0}", user_id);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            if (result != 0)
                return true;
            return false;
        }

        /* Get top 10 */
        public List<Score> GetTop10Score()
        {
            string ConnectionString = @"Data Source = HP-15\SQLEXPRESS; Initial Catalog = trivia_database; Integrated Security = True";
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM score ORDER BY score DESC ", connection);
            connection.Open();
            SqlDataReader SqlReader = cmd.ExecuteReader();
            Score score;
            List<Score> list = new List<Score>();
            while (SqlReader.Read()) {
                score = new Score();
                score.id = (int)SqlReader["id"];
                score.user_id = (int)SqlReader["user_id"];
                score.highest_score = (int)SqlReader["highest_score"];
                score.score = (int)SqlReader["score"];
                score.late_score = (int)SqlReader["late_score"];
                score.longest_strike = (int)SqlReader["longest_strike"];
                score.fastest_time = (float)Convert.ToDouble(SqlReader["fastest_time"]);
                list.Add(score);
            }
            connection.Close();
            return list;
        }


        /* Get the user score by user id or null */
        public Score GetUserScore(int user_id) {
            string ConnectionString = @"Data Source = HP-15\SQLEXPRESS; Initial Catalog = trivia_database; Integrated Security = True";
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = string.Format("SELECT * FROM score WHERE user_id = '{0}'", user_id);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader SqlReader = cmd.ExecuteReader();
            Score score;
            List<Score> list = new List<Score>();
            while (SqlReader.Read()) {
                score = new Score();
                score.id = (int)SqlReader["id"];
                score.user_id = (int)SqlReader["user_id"];
                score.highest_score = (int)SqlReader["highest_score"];
                score.score = (int)SqlReader["score"];
                score.late_score = (int)SqlReader["late_score"];
                score.longest_strike = (int)SqlReader["longest_strike"];
                score.fastest_time = (float)Convert.ToDouble(SqlReader["fastest_time"]);
                list.Add(score);
            }
            connection.Close();
            return list.Count > 0 ? list[0] : null ;
        }


        /* Insert a score to the databse */
        public bool SaveScore(Score score) {
            //  string ConnectionString = " HP - 450\\SQLEXPRESS; Initial Catalog = ClientDb; Integrated Security = True";
            string ConnectionString = @"Data Source = HP-15\SQLEXPRESS; Initial Catalog = trivia_database; Integrated Security = True";
            SqlConnection connection = new SqlConnection(ConnectionString);

            string query = string.Format("INSERT INTO score VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
               score.id, score.user_id, score.highest_score, score.score, score.late_score, score.longest_strike, score.fastest_time);

            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            if (result != 0)
                return true;
            else
                return false;
        }

        /* Return all the scores in database */
        public List<Score> SelectAll() {
            string ConnectionString = @"Data Source = HP-15\SQLEXPRESS; Initial Catalog = trivia_database; Integrated Security = True";
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM score", connection);
            connection.Open();
            SqlDataReader SqlReader = cmd.ExecuteReader();
            Score score;
            List<Score> list = new List<Score>();
            while (SqlReader.Read()) {
                score = new Score();
                score.id = (int)SqlReader["id"];
                score.user_id = (int)SqlReader["id"];
                score.highest_score = (int)SqlReader["highest_score"];
                score.score = (int)SqlReader["score"];
                score.late_score = (int)SqlReader["late_score"];
                score.longest_strike = (int)SqlReader["longest_strike"];
                score.fastest_time = (float)Convert.ToDouble(SqlReader["fastest_time"]);
                list.Add(score);
            }
            connection.Close();
            return list;
        }

        public bool UpdateScore(Score score) {
            string ConnectionString = @"Data Source = HP-15\SQLEXPRESS; Initial Catalog = trivia_database; Integrated Security = True";
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = string.Format("UPDATE score SET id='{0}', user_id='{1}', highest_score='{2}', score='{3}', late_score='{4}', longest_strike='{5}', fastest_time='{6}' WHERE user_id='{7}'",
                score.id, score.user_id, score.highest_score, score.score, score.late_score,
                score.longest_strike, score.fastest_time, score.user_id);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            return true;
        }
    }
}
