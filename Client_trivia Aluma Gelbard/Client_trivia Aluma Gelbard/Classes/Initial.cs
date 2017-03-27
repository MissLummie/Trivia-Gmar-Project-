using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_trivia_Aluma_Gelbard.Classes
{
    static class Initial
    {
        public static void InitialDatabases()
        {
            User new_user = new User("Lummie", "violetaluma@hotmail.com", "Aa1234", false); // debug user
            new_user = new User("Aluma", "me@lummie.tk", "Aa1234", true); // admin debug user
            new_user = new User("admin", "violetaluma@hotmail.com", "Aa1234", true); // admin debug user

            /* Level 1 questions */
            // General, level 1:
            Question new_question = new Question("Abraham Lincoln was assassinated in what year?", "1865", "1965", "1862", "1852", 1, "General");
            new_question = new Question("The taste that allows us to taste savory foods is called what?", "Umami", "Kariko", "Spicino", "Lorels", 1, "General");
            new_question = new Question("What later \"Star Wars\" actress had an early role in the movie \"Léon: The Professional\"?", "Natalie Portman", "Aluma Gelbard", "Justin Bieber", "Augoelita Gonzales", 1, "General");
            new_question = new Question("Who role the world?", "All answers are true", "Aluma Gelbard", "Lummisun", "Lummie the first for her name", 1, "General");
            new_question = new Question("Who was the first First Lady to be elected to public office?", "Hillary Rodham Clinton", "Ada Lovelace", "Amelia Earhart Bloomer", "Audre Lorde", 1, "General");

            // Computer Science, level 1:
            new_question = new Question("What does \"GUI\" stand for?", "Graphical user interface", "Geografical udp infection", "Galactic uniqe integer", "Gorilla useable initialize", 1, "Computer Science");
            new_question = new Question("Who is Ada Lovelace?", "The first programmer", "a Feminist", "Greatest philosopher of math", "The inventor of Python 2.7", 1, "Computer Science");
            new_question = new Question("In what year was the first Apple computer released?", "1976", "1980", "1985", "1994", 1, "Computer Science");
            new_question = new Question("In a website browser address bar what does \"www\" stand for?", "World Wide Web", "Wibly Wobly Wably", "Worst West World", "W.I.P.E Wake Wikipedia", 1, "Computer Science");
            new_question = new Question("In database programming, SQL is an acronym for what?", "Structured Query Language", "Sexy Quiet Lepricon", "Standart Query Lizard", "Sensitive Quality Lamborginy", 1, "Computer Science");

            // Math, level 1:
            new_question = new Question("3 + 5 = ", "8", "3.5", "9", "7", 1, "Math");
            new_question = new Question("6 * 8 = ", "48", "52", "46", "68", 1, "Math");
            new_question = new Question("If well mult 6 by even number..", "The Unity digit will be the even number", "The XOR of the numbers will be odd", "The NOR of the number will be parity ever", "Log base 6 of the number will be e", 1, "Math");
            new_question = new Question("3 / 3 = ", "1", "2.35", "3 / 2", "6", 1, "Math");
            new_question = new Question("3 - 5 = ", "-2", "5.43", "3", "8", 1, "Math");

            /* Level 2 questions */
            // General, level 2:
            new_question = new Question("What is the Spanish word for money?", "Dinero", "Sheklino", "Spain Euro", "Zild", 2, "General");
            new_question = new Question("What was the first ever series to air on the Disney Channel?", "Good Morning, Mickey", "Mulan", "Moana", "Barn", 2, "General");
            new_question = new Question("What is the largest organ of the human body?", "Skin", "Heart", "Brain", "Lorem Ipusom", 2, "General");
            new_question = new Question("Which shark is the biggest?", "The whale shark", "The Black shark", "WireShark", "The dolor sit amet shark", 2, "General");
            new_question = new Question("1,024 Gigabytes is equal to one what?", "Terabyte", "Dollar", "512 Shekels", "64 Bit", 2, "General");




        }
    }
}
