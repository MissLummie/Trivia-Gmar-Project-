using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace triviaService {
    [DataContract]
    public class Score {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int user_id { get; set; }

        [DataMember]
        public int highest_score { get; set; }

        [DataMember]
        public int score { get; set; }

        [DataMember]
        public int late_score { get; set; }

        [DataMember]
        public int longest_strike { get; set; }

        [DataMember]
        public float fastest_time { get; set; }

        public Score(int user_id, int highest_score, int score, int late_score, int longest_strike, float fastest_time)
        {
            this.user_id = user_id;
            this.highest_score = highest_score;
            this.score = score;
            this.late_score = late_score;
            this.longest_strike = longest_strike;
            this.fastest_time = fastest_time;
        }

        public Score()
        {
        }

    }
}
