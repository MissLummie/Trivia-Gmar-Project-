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
    public class Question
    {
        [PrimaryKey, AutoIncrement]
        public int question_ID { get; set; }
        public string question { get; set; }

        public string trueAnswer { get; set; }
        public string answer_2 { get; set; }
        public string answer_3 { get; set; }
        public string answer_4 { get; set; }

        public int level { get; set; } // there is level from 1 to 3
        public string type { get; set; } // computer science, math, general

        public Question(){}

        public Question(string question, string trueAnswer, string answer_2, string answer_3, string answer_4, int level, string type)
        {
            this.question = question;
            this.trueAnswer = trueAnswer;
            this.answer_2 = answer_2;
            this.answer_3 = answer_3;
            this.answer_4 = answer_4;
            this.level = level;
            this.type = type;
            QuestionManager.Insert(this);
        }
    }
}
