using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prof_Registration
{
    internal class error_handling
    {
        public bool notNull(string a)
        {

            if (string.IsNullOrEmpty(a))
            {
                return false;
            }
            else
                return true;
        }
        public bool notNull(string a, string b, string c)
        {

            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b) || string.IsNullOrEmpty(c))
            {
                return false;
            }
            else
                return true;
        }

        // method overloading 
        public bool notNull(string a, string b, string c, string d, string e)
        {

            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b) || string.IsNullOrEmpty(c) || string.IsNullOrEmpty(d) || string.IsNullOrEmpty(e))
            {
                return false;
            }
            else
                return true;
        }




        public bool emailChecker(string email)
        {
            if (email.EndsWith("@gmail.com"))
            {
                return true;
            }
            else return false;
        }



        public bool namesChecker(string name)
        {
            int countNC = 0;

            foreach (char a in name)
            {
                if (char.IsDigit(a))
                {
                    countNC++;
                }
            }
            if (countNC == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public bool contactNumChecker(string number)
        {
            int countCN = 0;

            foreach (char a in number)
            {
                if (char.IsDigit(a))
                {
                    countCN++;
                }
            }
            if (countCN > 0) return true;
            else return false;
        }


        //validation of time 
        public bool endAndStartTime(string startTime, string endTime)
        {
            TimeSpan start = TimeSpan.Parse(startTime);
            TimeSpan end = TimeSpan.Parse(endTime);

            // Compare the TimeSpan objects

            if (start >= end)
            {
                return false;
            }
            else
                return true;
        }

        // validation of the string matches the nn:nn format
        public bool IsValidNumberFormat(string input)
        {

            if (input.Length == 5 &&
                char.IsDigit(input[0]) &&
                char.IsDigit(input[1]) &&
                input[2] == ':' &&
                char.IsDigit(input[3]) &&
                char.IsDigit(input[4]))
            {
                return true;
            }
            else return false;

        }

        public bool userNameLengthCheck(string name)
        {
            int countChar = 0;

            foreach (char a in name)
            {
                countChar++;
            }

            if (countChar >= 5 && countChar <=16) return true;
            else return false;
        }

        public bool passwordLengthCheck(string pass)
        {
            int countChar = 0;

            foreach (char a in pass)
            {
                countChar++;
            }

            if (countChar >= 8) return true;
            else return false;
        }

        public bool NoTwentyFourHourFormat(string time)
        {
            string wrongTime = "24:00";
            if(time == wrongTime)
            {
                return false;
            }else return true;
        }


    }
}
