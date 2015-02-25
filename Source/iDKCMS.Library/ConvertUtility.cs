using System;
using System.Text.RegularExpressions;

namespace iDKCMS.Library
{
    public class ConvertUtility
    {
        public static string FormatTimeVn(DateTime dt, string defaultText)
        {
            if (ToDateTime(dt) != new DateTime(1900, 1, 1))
                return dt.ToString("dd-mm-yy");
            else
                return defaultText;
        }

        public static Int64 ToInt64(object obj)
        {
            Int64 retVal;

            try
            {
                retVal = Convert.ToInt64(obj);
            }
            catch
            {
                retVal = 0;
            }

            return retVal;
        }

        public static int ToInt32(object obj)
        {
            int retVal;

            try
            {
                retVal = Convert.ToInt32(obj);
            }
            catch
            {
                retVal = 0;
            }

            return retVal;
        }


        public static int ToInt32(object obj, int defaultValue)
        {
            int retVal;

            try
            {
                retVal = Convert.ToInt32(obj);
            }
            catch
            {
                retVal = defaultValue;
            }

            return retVal;
        }

        public static Int64 ToInt64(object obj, int defaultValue)
        {
            Int64 retVal;

            try
            {
                retVal = Convert.ToInt64(obj);
            }
            catch
            {
                retVal = defaultValue;
            }

            return retVal;
        }

        public static string ToString(object obj)
        {
            string retVal;

            try
            {
                retVal = Convert.ToString(obj);
            }
            catch
            {
                retVal = String.Empty;
            }

            return retVal;
        }

        public static DateTime ToDateTime(object obj)
        {
            DateTime retVal;
            try
            {
                retVal = Convert.ToDateTime(obj);
            }
            catch
            {
                retVal = DateTime.Now;
            }
            if (retVal == new DateTime(1, 1, 1)) return DateTime.Now;

            return retVal;
        }

        public static DateTime ToDateTime(object obj, DateTime defaultValue)
        {
            DateTime retVal;
            try
            {
                retVal = Convert.ToDateTime(obj);
            }
            catch
            {
                retVal = DateTime.Now;
            }
            if (retVal == new DateTime(1, 1, 1)) return defaultValue;

            return retVal;
        }

        public static bool ToBoolean(object obj)
        {
            bool retVal;

            try
            {
                retVal = Convert.ToBoolean(obj);
            }
            catch
            {
                retVal = false;
            }

            return retVal;
        }

        public static double ToDouble(object obj)
        {
            double retVal;

            try
            {
                retVal = Convert.ToDouble(obj);
            }
            catch
            {
                retVal = 0;
            }

            return retVal;
        }

        public static double ToDouble(object obj, double defaultValue)
        {
            double retVal;

            try
            {
                retVal = Convert.ToDouble(obj);
            }
            catch
            {
                retVal = defaultValue;
            }

            return retVal;
        }

        public static string ToStringDdmmyyyy(string date)
        {
            date = date.Replace(" ", "");

            var regex = new Regex(@"^\s*\d{1,2}/\d{1,2}/\d{4}\s*$");

            if (!regex.IsMatch(date)) return "";
            else
            {
                try
                {
                    if (Convert.ToInt32(date.Substring(date.LastIndexOf("/") + 1)) < 1900 || Convert.ToInt32(date.Substring(date.LastIndexOf("/") + 1)) > 9999) return "";

                    return (date.Substring(date.IndexOf("/") + 1, date.LastIndexOf("/") - date.IndexOf("/") - 1) + "/" + date.Substring(0, date.IndexOf("/")) + "/" + date.Substring(date.LastIndexOf("/") + 1));
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }
    }
}