using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_trivia_Aluma_Gelbard.Classes
{
    class Validator
    {
        public static string check_password(string pass)
        {
            // Legal password shell include:
            // 6 chars, at least one digit and at least one capital letter
            string valid = "";
            bool capital = false, digit = false;

            if (pass.Length < 6)
                valid += "Password Error: password length must be at least 6 chars";

            foreach (char ch in pass)
            {
                if (ch >= '0' && ch <= '9')
                    digit = true;
                if (ch >= 'A' && ch <= 'Z')
                    capital = true;
            }

            if (!capital)
                valid += valid == "" ? "Password Error: password must contain at least 1 capital letter" : " ,password must contain at least 1 capital letter";

            if(!digit)
                valid += valid == "" ? "Password Error: password must contain at least 1 digit" : " ,password must contain at least 1 digit";

            return valid == "" ? "" : valid + "\n";
        }

        public static string check_username(string username)
        {
            // Username must contain at least 4 chars
            if (username.Length >= 4)
                return "";
            else
                return "Username Error: Username must contain at least 4 letters\n";
        }

        public static bool isnt_void(string input)
        {
            return (input != "");
        }

        public static string check_mail(string mail)
        { // check if the mail is available
            if (!(new EmailAddressAttribute().IsValid(mail)))
                return "Mail Error: mail is not valid\n";
            else
                return "";
        }
    }
}
