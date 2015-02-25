using System;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;
using iDKCMS.Library.WebBase;

namespace iDKCMS.BackEnd.UserControls.Core
{
    public partial class UserProfile : AdminControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtAddress.Text = CurrentAdminInfo.User_Address;
                txtBirthDay.Text = CurrentAdminInfo.User_Birthday;
                txtEmail.Text = CurrentAdminInfo.User_Email;
                txtFullName.Text = CurrentAdminInfo.User_FullName;
                txtPhone.Text = CurrentAdminInfo.User_Phone;
                dropGender.SelectedIndex = -1;
                MiscUtility.SetSelected(dropGender.Items, Convert.ToInt32(CurrentAdminInfo.User_Gender).ToString());
            }
        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            CurrentAdminInfo.User_Email = txtEmail.Text.Trim();
            CurrentAdminInfo.User_FullName = txtFullName.Text;
            CurrentAdminInfo.User_Gender = (dropGender.SelectedValue == "1") ? true : false;
            CurrentAdminInfo.User_Address = txtAddress.Text;
            CurrentAdminInfo.User_Birthday = txtBirthDay.Text;
            CurrentAdminInfo.User_Phone = txtPhone.Text;
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