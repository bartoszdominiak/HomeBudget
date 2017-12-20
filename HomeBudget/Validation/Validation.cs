using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeBudget.Validation
{
    public class Validation
    {
        public static bool IsGreaterOrEqualThenZero(decimal value)
        {
            if (value >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsDecimal(string text)
        {
            decimal value;
            return decimal.TryParse(text, out value);
        }

        public static bool IsValidDateFormat(string dateFormat)
        {
            try
            {
                String dts = DateTime.Now.ToString(dateFormat);
                DateTime.ParseExact(dts, dateFormat, CultureInfo.InvariantCulture);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool IsDate(string text)
        {
            try
            {
                int test = 0;
                test = Convert.ToInt16(text[0]); if (test < 0 | test > 9) return false;
                test = Convert.ToInt16(text[1]); if (test < 0 | test > 9) return false;
                test = Convert.ToInt16(text[2]); if (test < 0 | test > 9) return false;
                test = Convert.ToInt16(text[3]); if (test < 0 | test > 9) return false;
                if (text[4] != '-') return false;
                test = Convert.ToInt16(text[5]); if (test < 0 | test > 9) return false;
                test = Convert.ToInt16(text[6]); if (test < 0 | test > 9) return false;
                if (text[7] != '-') return false;
                test = Convert.ToInt16(text[8]); if (test < 0 | test > 9) return false;
                test = Convert.ToInt16(text[9]); if (test < 0 | test > 9) return false;

                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public static bool IsDay(string day)
        {
            try
            {
                int x = 0;

                Int32.TryParse(day, out x);
                x=Int32.Parse(day);
                if (x<=31&&x>=1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool StringNotNull(string text)
        {
            if(text.Count()==0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool TwoStringsEquals(string text1, string text2)
        {
            if(text1==""||text2=="")
            {
                return false;
            }
            else if(text1!=text2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static string GetNumberWithDot(string text)
        {
            int test = text.IndexOf('.');
            if (test == 0)
            {
                 test = text.IndexOf(',');
                if (test == 0)
                {
                    text = text + ".0";
                }
            }
            if (!Regex.IsMatch(text, @"^[0-9]{1,10}([,][0-9]{1,2})?$"))
            {
                if (!Regex.IsMatch(text, @"^[0-9]{1,10}([.][0-9]{1,2})?$"))
                {
                    return "0,0";
                }
                else
                {
                    char[] delimiterChars = { '.' };
                    string[] words = text.Split(delimiterChars);
                    text = words[0] + ',' + words[1];
                    return text;
                }
               
            }
            else
            {
                return text;
            }
        }
        public static string GetNumberTwoZero(string text)
        {
            try
            {
                int dot = text.IndexOf(',');
                text = text.Remove(dot + 3);
                return text;
            }
            catch
            {
                return text;
            }
            
        }
        public static string GetShortDate(string text)
        {
            int dot = text.IndexOf(' ');
            text = text.Remove(dot);
            return text;
        }
        public static string GetReverseDate(string text)
        {
            text = GetShortDate(text);
            Char delimiter = '.';
            String[] substrings = text.Split(delimiter);
            text = substrings[2] + "." + substrings[1] + "." + substrings[0];
            return text;
        }

        public static decimal GetDecimal(string value)
        {
            return Decimal.Parse(value);
        }
        public static bool NotLongerThen(string text, int value)
        {
            if(text.Count()>value)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static string GetGoodDate(string date)
        {
            string GoodDate="";
            Char delimiter = '.';
            String[] substrings = date.Split(delimiter);
            GoodDate = substrings[2] + '-' + substrings[1] + '-' + substrings[0];
            return GoodDate;

        }
        public static string GetDayInMonth(string date)
        {
            if (date == "01") return "31";
            else if (date == "02") return "28";
            else if (date == "03") return "31";
            else if (date == "04") return "30";
            else if (date == "05") return "31";
            else if (date == "06") return "30";
            else if (date == "07") return "31";
            else if (date == "08") return "31";
            else if (date == "09") return "30";
            else if (date == "10") return "31";
            else if (date == "11") return "30";
            else if (date == "12") return "31";
            else return "28";
        }
        public static int GetMonthFromDate(string date)
        {
            date=Validation.GetShortDate(date);
            string GoodDate = "";
            Char delimiter = '.';
            String[] substrings = date.Split(delimiter);
            GoodDate =substrings[1];
            return Convert.ToInt16(GoodDate);

        }
        public static int GetYearFromDate(string date)
        {
            date=Validation.GetShortDate(date);
            string GoodDate = "";
            Char delimiter = '.';
            String[] substrings = date.Split(delimiter);
            GoodDate = substrings[2];
            return Convert.ToInt16(GoodDate);

        }
        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

    }
}
