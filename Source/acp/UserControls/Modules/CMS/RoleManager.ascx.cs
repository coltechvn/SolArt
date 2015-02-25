using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.BackEnd.UserControls.Modules.CMS
{
    public partial class RoleManager : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dtgUsers.DataSource = UserDB.GetAll();
            dtgUsers.DataBind();
            if (!IsPostBack)
            {
                ZoneUtility.LoadZones(lstCMSRoles.Items);
            }
        }

        protected void dtgUsers_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "roles")
            {
                lblUserEmail.Text = e.Item.Cells[1].Text;
                UserInfo info = UserDB.GetInfoByEmail(lblUserEmail.Text);

                string roles = "|";
                DataTable dtRoles = RoleDB.GetByUserID(info.User_ID);
                foreach (DataRow row in dtRoles.Rows) roles += row["User_Role"] + "|";

                foreach (ListItem item in chkRoles.Items)
                    if (roles.IndexOf("|" + item.Value + "|") >= 0) item.Selected = true;
                    else item.Selected = false;

                string cmsRoles = "|" + RoleDB.GetUserCMSRoles(info.User_ID, AppEnv.GetLanguage());
                foreach (ListItem item in lstCMSRoles.Items)
                    if (cmsRoles.IndexOf("|" + item.Value + "|") >= 0) item.Selected = true;
                    else item.Selected = false;
            }
        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            if (lblUserEmail.Text == string.Empty) return;
            UserInfo info = UserDB.GetInfoByEmail(lblUserEmail.Text);

            try
            {
                foreach (ListItem item in chkRoles.Items)
                    if (item.Selected) RoleDB.AddUserRole(info.User_ID, Convert.ToInt32(item.Value));
                    else
                        RoleDB.RemoverUserRole(info.User_ID, Convert.ToInt32(item.Value));


                string cmsRoles = string.Empty;
                foreach (ListItem item in lstCMSRoles.Items)
                    if (item.Selected) cmsRoles += item.Value + "|";
                if (cmsRoles.Length > 0) cmsRoles = "|" + cmsRoles;

                if (cmsRoles != string.Empty) RoleDB.SetUserCMSRoles(info.User_ID, AppEnv.GetLanguage(), cmsRoles);

                lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch
            {
                lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
            }
        }
    }
}