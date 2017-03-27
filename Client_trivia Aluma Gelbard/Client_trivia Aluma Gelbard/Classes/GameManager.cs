using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Client_trivia_Aluma_Gelbard.RemoteDatabaseService;

namespace Client_trivia_Aluma_Gelbard.Classes {
    static class GameManager {
        public static List<Question> _questions_array { get; set; }
        public static string _subject { get; set; }
        public static int _level { get; set; }
        public static int _amount { get; set; }
        public static int _timer { get; set; }
        public static int _counter { get; set; }


        // Score
        public static int strike { get; set; }
        public static int currStrike { get; set; }
        public static int score { get; set; }
        public static double avg_time { get; set; }
        public static double best_time { get; set; }

        public static void InitailGame(string subject, int level, int amount, int timer) {
            // init
            _subject = subject;
            _level = level;
            _amount = amount;
            _timer = timer;
            _counter = 0;

            // rand questions
            _questions_array = Classes.QuestionManager.RandQuestions(_amount, _subject, _level);

            strike = 0;
            currStrike = 0;
            score = 0;
            avg_time = 0;
            best_time = 0;
        }

        public static void UpdateStats(bool success, int currScore, double time) { // update the stats of the user
            currStrike += success ? 1 : strike * -1;
            strike = currStrike > strike ? currStrike : strike;
            score += currScore;
            avg_time += time / _amount;
            best_time = best_time < time ? time : best_time;
        }

        public static async void SaveStats()
        {
            // TO-DO: Save the stats into stats table
            var dialog = new MessageDialog("Good Work!\nScore: " + score + "\nAvarage time: " + avg_time + " sec \nLongest Strike:" + strike);
            var res = dialog.ShowAsync();

            Client_trivia_Aluma_Gelbard.RemoteDatabaseService.TriviaServiceClient proxy = new Client_trivia_Aluma_Gelbard.RemoteDatabaseService.TriviaServiceClient();
            RemoteDatabaseService.Score prev_score = await proxy.GetUserScoreAsync(Classes.UserManager.myUser.user_ID);
            Score user_score = new Score();
            if (prev_score == null) {
                user_score.user_id = Classes.UserManager.myUser.user_ID;
                user_score.score = score;
                user_score.late_score = score;
                user_score.highest_score = score;
                user_score.longest_strike = strike;
                user_score.fastest_time = (float)best_time;
                await proxy.SaveScoreAsync(user_score);
            }
            else {
                user_score.user_id = Classes.UserManager.myUser.user_ID;
                user_score.late_score = score;
                user_score.score = score + prev_score.score;
                user_score.highest_score = prev_score.highest_score > score ? prev_score.highest_score : score;
                user_score.longest_strike = prev_score.longest_strike > strike ? prev_score.longest_strike : strike;
                user_score.fastest_time = prev_score.fastest_time > (float)best_time ? prev_score.fastest_time : (float)best_time;
                await proxy.UpdateScoreAsync(user_score);
            }

        }

        public static void ClearGame() { // Clear all fields
            _subject = "";
            _level = 0;
            _amount = 0;
            _timer = 0;
            _counter = 0;
            _questions_array = null;
        }

    }
}
