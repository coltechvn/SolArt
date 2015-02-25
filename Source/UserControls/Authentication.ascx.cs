using System;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.UserControls
{
    public partial class Authentication : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnLogin.Visible = true;
            pnUserInfo.Visible = false;

            if (CookieUtility.GetCookie("Member_Email") != null)
            {
                if (MemberDB.GetIDByEmail(CookieUtility.GetCookie("Member_Email")) != 0)
                {
                    MemberInfo info = MemberDB.GetInfoByEmail(CookieUtility.GetCookie("Member_Email"));
                    if (info != null)
                    {
                        pnLogin.Visible = false;
                        pnUserInfo.Visible = true;

                        lnkMemberInfo.Text = info.Member_Fullname;
                        lnkMemberInfo.NavigateUrl = lnkUserCP.NavigateUrl = AppEnv.WEB_CMD + "memberinfo&id=" + info.Member_ID;
                    }
                }
            }
        }

        protected void butSubmit_Click(object sender, EventArgs e)
        {
            if (MemberDB.CheckAccount(txtEmail.Text, txtPassword.Text))
            {
                AuthenticateUtility.LoginMember(txtEmail.Text, chkRemember.Checked);
                var tab = Request.QueryString["tab"];
                if(tab == "cart")
                    Response.Redirect(Request.RawUrl + "&jl=1");
                else
                    Response.Redirect(Request.RawUrl);
            }
            else
            {
                MessageBox.Show("Thông tin đăng nhập không chính xác");
            }
        }

        protected void butLogout_Click(object sender, EventArgs e)
        {
            AuthenticateUtility.LogoutMember();
            Response.Redirect("/");
        }
    }
}