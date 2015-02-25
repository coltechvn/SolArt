using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.BackEnd
{
    public partial class Login : System.Web.UI.Page
    {
        protected void PageLoad(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
        }

        protected void BtLoginClick(object sender, EventArgs e)
        {
            string returnurl = ConvertUtility.ToString(Request.QueryString["returnurl"]);

            if (UserDB.CheckAccount(txtEmail.Text, txtPassword.Text))
            {
                AuthenticateUtility.LoginUser(txtEmail.Text, chkRememberPwd.Checked);
                if (returnurl != "")
                    Response.Redirect(returnurl);
                else
                    Response.Redirect(AppEnv.ADMIN_PATH);
            }
            else lblMessage.Visible = true;
        }
    }
}