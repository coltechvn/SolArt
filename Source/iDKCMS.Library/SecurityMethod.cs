using System;
using System.Security.Cryptography;
using System.Text;

namespace iDKCMS.Library
{
    public class SecurityMethod
    {
        public static string RandomString(int length)
        {
            const string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var strlen = str.Length;
            var rnd = new Random();
            var retVal = String.Empty;

            for (int i = 0; i < length; i++)
                retVal += str[rnd.Next(strlen)];

            return retVal;
        }

        public static string MD5Encrypt(string plainText)
        {
            var encoder = new UTF8Encoding();
            var hasher = new MD5CryptoServiceProvider();

            var data = encoder.GetBytes(plainText);
            var output = hasher.ComputeHash(data);

            return BitConverter.ToString(output).Replace("-", "").ToLower();
        }

        public static string RandomPassword()
        {
            var retVal = String.Empty;
            var rd = new Random(DateTime.Now.Millisecond);
            for (int i = 1; i < 10; i++)
            {
                retVal += rd.Next(0, 9);
            }
            return retVal;
        }

        public static string ReplaceHTMLString(string _content)
        {
            string retVal = _content.Replace("&acute;", "'");
            retVal = retVal.Replace("&quot;", "\"");
            retVal = retVal.Replace("&lt;", "&amp;lt;");
            retVal = retVal.Replace("&gt;", "&amp;gt;");
            retVal = retVal.Replace("<", "&lt;");
            retVal = retVal.Replace(">", "&gt;");

            return retVal;
        }
    }
}