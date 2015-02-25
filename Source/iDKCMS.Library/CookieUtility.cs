using System;
using System.Web;

namespace iDKCMS.Library
{
    public class CookieUtility
    {
        public static void SetCookieNoExpire(string Name, string Value)
        {
            SetCookie(Name, Value, 360);
        }

        public static void SetCookie(string Name, string Value, int dayExpires)
        {
            HttpContext context = HttpContext.Current;

            HttpCookie ck;
            if (context.Request.Cookies[Name] == null)
            {
                ck = new HttpCookie(Name);
            }
            else
            {
                ck = context.Request.Cookies[Name];
            }
            context.Response.Cookies[Name].Value = Value;
            context.Response.Cookies[Name].Expires = DateTime.Now.AddDays(dayExpires);
        }

        public static string GetCookie(string Name)
        {
            HttpContext context = HttpContext.Current;

            if (context.Request.Cookies[Name] != null)
            {
                return context.Request.Cookies[Name].Value;
            }
            else
                return null;
        }
    }
}