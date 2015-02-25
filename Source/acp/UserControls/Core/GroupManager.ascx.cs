using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.BackEnd.UserControls.Core
{
    public partial class GroupManager : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUpdateStatus.Text = string.Empty;
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            dtgGroups.DataSource = GroupDB.GetAll();
            dtgGroups.DataBind();
        }

        protected void dtgGroups_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            Button cmdDel = (Button)e.Item.FindControl("cmdDel");
            if (cmdDel != null) cmdDel.Attributes.Add("onclick", MiscUtility.DELETE_CONFIRM);
        }

        protected void dtgGroups_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                GroupInfo group = GroupDB.GetInfo(Convert.ToInt32(e.Item.Cells[0].Text));
                if (group == null)
                {
                    cmdEmpty_Click(null, null);
                    return;
                }
                txtID.Text = group.Group_ID.ToString();
                txtName.Text = group.Group_Name;
                txtDes.Text = group.Group_Description;
            }
            if (e.CommandName == "del")
            {
                try
                {
                    GroupDB.Delete(Convert.ToInt32(e.Item.Cells[0].Text));
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
                Response.Redirect(AppEnv.ADMIN_CMD + "maingroupcmdroles&groupid=" + e.Item.Cells[0].Text);
            }
            if (e.CommandName == "members")
            {
                Response.Redirect(AppEnv.ADMIN_CMD + "maingroupmembers&groupid=" + e.Item.Cells[0].Text);
            }
            if (e.CommandName == "stores")
            {
                Response.Redirect(AppEnv.ADMIN_CMD + "cmdusergroupstoremanagement&groupid=" + e.Item.Cells[0].Text);
            }
        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            GroupInfo info = GroupDB.GetInfo(ConvertUtility.ToInt32(txtID.Text));
            if (info == null) return;

            info.Group_Name = txtName.Text.Trim();
            info.Group_Description = txtDes.Text;
            try
            {
                GroupDB.Update(info);
                lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch
            {
                lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
            }
        }

        protected void cmdAddNew_Click(object sender, EventArgs e)
        {
            GroupInfo info = new GroupInfo();
            info.Group_Name = txtName.Text.Trim();
            info.Group_Description = txtDes.Text;
            //try
            //{
            txtID.Text = GroupDB.Insert(info).ToString();
            lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
            //}
            //catch
            //{
            //    lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
            //}
        }

        protected void cmdEmpty_Click(object sender, EventArgs e)
        {
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtDes.Text = string.Empty;
        }
    }
}