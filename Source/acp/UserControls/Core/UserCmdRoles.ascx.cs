using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;
using iDKCMS.Library.WebBase;

namespace iDKCMS.BackEnd.UserControls.Core
{
    public partial class UserCmdRoles : AdminControl
    {
        private UserInfo userInfo;

        protected void Page_Load(object sender, EventArgs e)
        {
            userInfo = UserDB.GetInfo(ConvertUtility.ToInt32(Request.QueryString["userid"]));
            if (userInfo == null) Response.Redirect(AppEnv.ADMIN_PATH);

            lblUserEmail.Text = userInfo.User_Email;
            lblUpdateStatus.Text = string.Empty;
            if (!IsPostBack)
            {
                lstRoles.Items.Clear();
                CmdDB.FillToListBox(lstRoles.Items);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            lstUserRoles.Items.Clear();
            CmdDB.FillToListBox(lstUserRoles.Items);

            DataTable dtUserRoles = CmdRoleDB.GetUserRoles(userInfo.User_ID);
            string roles = "|";
            foreach (DataRow row in dtUserRoles.Rows) roles += row["Cmd_ID"] + "|";

            int i = 0;
            while (i < lstUserRoles.Items.Count)
            {
                if (roles.IndexOf("|" + lstUserRoles.Items[i].Value + "|") < 0) lstUserRoles.Items.RemoveAt(i);
                else i += 1;
            }

        }

        protected void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListItem item in lstRoles.Items)
                    if (item.Selected) CmdRoleDB.UserAddRole(userInfo.User_ID, Convert.ToInt32(item.Value));
                lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch
            {
                lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
            }
        }

        protected void cmdRemover_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListItem item in lstUserRoles.Items)
                    if (item.Selected) CmdRoleDB.UserRemoverRole(userInfo.User_ID, Convert.ToInt32(item.Value));
                lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch
            {
                lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
            }
        }
    }
}