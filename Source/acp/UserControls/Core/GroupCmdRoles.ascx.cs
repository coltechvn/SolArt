using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;
using iDKCMS.Library.WebBase;

namespace iDKCMS.BackEnd.UserControls.Core
{
    public partial class GroupCmdRoles : AdminControl
    {
        private GroupInfo groupInfo;

        protected void Page_Load(object sender, EventArgs e)
        {
            groupInfo = GroupDB.GetInfo(ConvertUtility.ToInt32(Request.QueryString["groupid"]));
            if (groupInfo == null) Response.Redirect(AppEnv.ADMIN_PATH);

            txtGroupName.Text = groupInfo.Group_Name;
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

            lstGroupRoles.Items.Clear();
            CmdDB.FillToListBox(lstGroupRoles.Items);

            DataTable dtGroupRoles = CmdRoleDB.GetGroupRoles(groupInfo.Group_ID);
            string roles = "|";
            foreach (DataRow row in dtGroupRoles.Rows) roles += row["Cmd_ID"] + "|";

            int i = 0;
            while (i < lstGroupRoles.Items.Count)
            {
                if (roles.IndexOf("|" + lstGroupRoles.Items[i].Value + "|") < 0) lstGroupRoles.Items.RemoveAt(i);
                else i += 1;
            }
        }

        protected void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListItem item in lstRoles.Items)
                    if (item.Selected) CmdRoleDB.GroupAddRole(groupInfo.Group_ID, Convert.ToInt32(item.Value));
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
                foreach (ListItem item in lstGroupRoles.Items)
                    if (item.Selected) CmdRoleDB.GroupRemoverRole(groupInfo.Group_ID, Convert.ToInt32(item.Value));
                lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch
            {
                lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
            }
        }
    }
}