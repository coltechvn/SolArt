using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iDKCMS.Library
{
    public class AuthenticateUtility
    {
        public const string ADMIN_PREFIX = "iDK_Administrator_";

        public static string GetUserEmail()
        {
            return HttpContext.Current.User.Identity.Name.Replace(ADMIN_PREFIX, string.Empty);
        }

        public static bool IsAuthenticated()
        {
            HttpContext context = HttpContext.Current;
            return
                context.User.Identity.IsAuthenticated && (context.User.Identity.Name.IndexOf(ADMIN_PREFIX) != -1);
        }

        public static void LoginMember(string _email, bool _rememberAccount)
        {
            LogoutMember();
            if (_rememberAccount)
            {
                CookieUtility.SetCookieNoExpire("Member_Email", _email);
            }
            else
            {
                CookieUtility.SetCookie("Member_Email", _email, 1);
            }
        }

        public static void LogoutMember()
        {
            //HttpContext.Current.Items.Remove("ADMIN_INFO");
            //HttpContext.Current.Session.Abandon();
            //FormsAuthentication.SignOut();

            if (CookieUtility.GetCookie("Member_Email") != null)
            {
                CookieUtility.SetCookie("Member_Email", CookieUtility.GetCookie("Member_Email"), -360);
            }
        }

        public static void LoginUser(string _email, bool _rememberAccount)
        {
            //LogoutUser();
            //FormsAuthentication.Initialize();
            //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, ADMIN_PREFIX + _email, DateTime.Now, DateTime.Now.AddMinutes(45), _rememberAccount, "", FormsAuthentication.FormsCookiePath);
            //Trace.Write(FormsAuthentication.FormsCookiePath + FormsAuthentication.FormsCookieName);
            //HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
            //HttpContext.Current.Response.SetCookie(cookie);

            LogoutUser();
            if (_rememberAccount)
            {
                CookieUtility.SetCookieNoExpire("User_Email", _email);
            }
            else
            {
                CookieUtility.SetCookie("User_Email", _email, 1);
            }
        }

        public static void LogoutUser()
        {
            //HttpContext.Current.Items.Remove("ADMIN_INFO");
            //HttpContext.Current.Session.Abandon();
            //FormsAuthentication.SignOut();

            if (CookieUtility.GetCookie("User_Email") != null)
            {
                CookieUtility.SetCookie("User_Email", CookieUtility.GetCookie("User_Email"), -360);
            }
        }
    }
}