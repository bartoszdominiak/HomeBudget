using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeBudget.Validation
{
    public class Validation
    {
        public static bool IsDecimal(string text)
        {
            decimal value;
            return decimal.TryParse(text, out value);
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
