using System;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;
using iDKCMS.Library.WebBase;

namespace iDKCMS.BackEnd.UserControls.Core
{
    public partial class UserChangePassword : AdminControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            if (SecurityMethod.MD5Encrypt(txtCurPwd.Text) != CurrentAdminInfo.User_Password)
            {
                lblUpdateStatus.Text = "<font color='red'>Mật khẩu cũ không đúng !</font>";
                return;
            }
            CurrentAdminInfo.User_Password = SecurityMethod.MD5Encrypt(txtNewPwd.Text);
            try
            {
                UserDB.Update(CurrentAdminInfo);
                lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch
            {
                lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
            }
        }
    }
}