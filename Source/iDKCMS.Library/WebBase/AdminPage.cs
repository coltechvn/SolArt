using System;
using System.Web.UI;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.Library.WebBase
{
	public class AdminPage : Page
	{
		#region Title

		private string _title;

		public new string Title
		{
			get { return _title; }
			set { _title = value; }
		}

		#endregion

		public UserInfo CurrentAdminInfo
		{
			get
			{
				if (Context.Items["ADMIN_INFO"] != null)
					return (UserInfo) Context.Items["ADMIN_INFO"];
				else return null;
			}
			set
			{
				Context.Items.Remove("ADMIN_INFO");
				Context.Items.Add("ADMIN_INFO", value);
			}
		}

		protected override void OnInit(EventArgs e)
		{
            //base.OnInit(e);
            //string returnUrl = Server.UrlEncode(Request.RawUrl);
            //if (AuthenticateUtility.IsAuthenticated())
            //{
            //    if (UserDB.GetIDByEmail(AuthenticateUtility.GetUserEmail()) != 0)
            //    {
            //        if (CurrentAdminInfo == null) CurrentAdminInfo = UserDB.GetInfoByEmail(AuthenticateUtility.GetUserEmail());
            //    }
            //    else Response.Redirect(AppEnv.ADMIN_PATH + "Login.aspx?returnurl=" + returnUrl);
            //}
            //else Response.Redirect(AppEnv.ADMIN_PATH + "Login.aspx?returnurl=" + returnUrl);

            base.OnInit(e);
            string returnUrl = Server.UrlEncode(Request.RawUrl);
            if (CookieUtility.GetCookie("User_Email") != null)
            {
                if (UserDB.GetIDByEmail(CookieUtility.GetCookie("User_Email")) != 0)
                {
                    if (CurrentAdminInfo == null) CurrentAdminInfo = UserDB.GetInfoByEmail(CookieUtility.GetCookie("User_Email"));
                }
                else Response.Redirect(AppEnv.ADMIN_PATH + "Login.aspx?returnurl=" + returnUrl);
            }
            else Response.Redirect(AppEnv.ADMIN_PATH + "Login.aspx?returnurl=" + returnUrl);
		}


	}
}