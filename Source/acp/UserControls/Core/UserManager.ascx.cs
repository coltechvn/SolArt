using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;
using iDKCMS.Library.WebBase;

namespace iDKCMS.BackEnd.UserControls.Core
{
    public partial class UserManager : AdminControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUpdateStatus.Text = string.Empty;
            if (!IsPostBack)
            {
                lstGroups.DataSource = GroupDB.GetAll();
                lstGroups.DataTextField = "Group_Name";
                lstGroups.DataValueField = "Group_ID";
                lstGroups.DataBind();
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            dtgUsers.DataSource = UserDB.GetAll();
            dtgUsers.DataBind();
        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            int userID = ConvertUtility.ToInt32(txtID.Text);
            UserInfo info = UserDB.GetInfo(userID);
            if (info == null) return;

            info.User_Email = txtEmail.Text.Trim();
            info.User_FullName = txtFullName.Text;
            if (txtPassword.Text.Trim() != string.Empty)
                info.User_Password = SecurityMethod.MD5Encrypt(txtPassword.Text.Trim());

            info.User_Gender = (dropGender.SelectedValue == "1") ? true : false;
            info.User_Address = txtAddress.Text;
            info.User_Birthday = txtBirthDay.Text;
            info.User_Phone = txtPhone.Text;

            info.User_SuperAdmin = chkIsSuperAdmin.Checked;
            try
            {
                UserDB.Update(info);
                foreach (ListItem item in lstGroups.Items)
                    if (item.Selected) GroupMemberDB.AddUser(info.User_ID, Convert.ToInt32(item.Value));
                    else GroupMemberDB.RemoverUser(info.User_ID, Convert.ToInt32(item.Value));
                lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch
            {
                lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
            }
        }

        protected void cmdAddNew_Click(object sender, EventArgs e)
        {
            UserInfo info = new UserInfo();
            info.User_Email = txtEmail.Text.Trim();
            info.User_FullName = txtFullName.Text;
            info.User_Password = SecurityMethod.MD5Encrypt(txtPassword.Text.Trim());

            info.User_Gender = (dropGender.SelectedValue == "1") ? true : false;
            info.User_Address = txtAddress.Text;
            info.User_Birthday = txtBirthDay.Text;
            info.User_Phone = txtPhone.Text;

            info.User_SuperAdmin = chkIsSuperAdmin.Checked;
            try
            {
                txtID.Text = UserDB.Insert(info).ToString();

                foreach (ListItem item in lstGroups.Items)
                    if (item.Selected) GroupMemberDB.AddUser(Convert.ToInt32(txtID.Text), Convert.ToInt32(item.Value));
                    else GroupMemberDB.RemoverUser(Convert.ToInt32(txtID.Text), Convert.ToInt32(item.Value));

                //Response.Write(FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "md5"));
                //Response.Write("<br />");
                //Response.Write(SecurityMethod.MD5Encrypt(txtPassword.Text.Trim()));

                lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch
            {
                lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
            }
        }

        protected void cmdEmpty_Click(object sender, EventArgs e)
        {
            txtID.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFullName.Text = string.Empty;
            txtBirthDay.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
        }

        protected void dtgUsers_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;

            Button cmdDel = (Button)e.Item.FindControl("cmdDel");
            Button Button1 = (Button)e.Item.FindControl("Button1");

            if (cmdDel != null) cmdDel.Attributes.Add("onclick", MiscUtility.DELETE_CONFIRM);
            if ((e.Item.Cells[0].Text == "1") || (e.Item.Cells[1].Text == AppEnv.ADMIN_EMAIL)) cmdDel.Visible = false;

            if ((e.Item.Cells[0].Text == "1") || (e.Item.Cells[1].Text == AppEnv.ADMIN_EMAIL))
            {
                if (e.Item.Cells[1].Text == CurrentAdminInfo.User_Email)
                {
                    Button1.Visible = true;
                }
                else
                {
                    Button1.Visible = false;
                }
            }

            e.Item.Attributes.Add("onmouseover", "this.className='Hoverrow';");
            if (e.Item.ItemType == ListItemType.AlternatingItem)
                e.Item.Attributes.Add("onmouseout", "this.className='DarkRow';");
            else
                e.Item.Attributes.Add("onmouseout", "this.className='LightRow';");
        }

        protected void dtgUsers_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                UserInfo user = UserDB.GetInfo(Convert.ToInt32(e.Item.Cells[0].Text));
                if (user == null)
                {
                    cmdEmpty_Click(null, null);
                    return;
                }
                txtID.Text = user.User_ID.ToString();
                txtFullName.Text = user.User_FullName;
                txtEmail.Text = user.User_Email;
                txtBirthDay.Text = user.User_Birthday;
                txtPhone.Text = user.User_Phone;
                txtAddress.Text = user.User_Address;

                chkIsSuperAdmin.Checked = user.User_SuperAdmin;

                dropGender.SelectedIndex = -1;
                MiscUtility.SetSelected(dropGender.Items, Convert.ToInt32(user.User_Gender).ToString());

                string groups = "|";

                DataTable dtGroups = GroupMemberDB.GetUserGroups(user.User_ID);
                foreach (DataRow row in dtGroups.Rows) groups += row["Group_ID"] + "|";
                foreach (ListItem item in lstGroups.Items)
                    if (groups.IndexOf("|" + item.Value + "|") >= 0) item.Selected = true;
                    else item.Selected = false;

            }
            if (e.CommandName == "del")
            {
                try
                {
                    UserDB.Delete(Convert.ToInt32(e.Item.Cells[0].Text));
                    lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
                    cmdEmpty_Click(null, null);
                }
                catch
                {
                    lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
                }
            }
            if (e.CommandName == "roles")
            {
                Response.Redirect(AppEnv.ADMIN_CMD + "mainusercmdroles&userid=" + e.Item.Cells[0].Text);
            }
            if (e.CommandName == "stores")
            {
                Response.Redirect(AppEnv.ADMIN_CMD + "cmduserstoremanagement&userid=" + e.Item.Cells[0].Text);
            }
        }
    }
}