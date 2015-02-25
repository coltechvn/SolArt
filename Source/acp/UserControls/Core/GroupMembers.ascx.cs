using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;
using iDKCMS.Library.WebBase;

namespace iDKCMS.BackEnd.UserControls.Core
{
    public partial class GroupMembers : AdminControl
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
                lstUsers.DataSource = UserDB.GetAll();
                lstUsers.DataTextField = "User_Email";
                lstUsers.DataValueField = "User_ID";
                lstUsers.DataBind();
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            lstGroupMembers.DataSource = UserDB.GetAll();
            lstGroupMembers.DataTextField = "User_Email";
            lstGroupMembers.DataValueField = "User_ID";
            lstGroupMembers.DataBind();

            DataTable dtGroupMembers = GroupMemberDB.GetGroupMembers(groupInfo.Group_ID);
            string members = "|";
            foreach (DataRow row in dtGroupMembers.Rows) members += row["User_ID"] + "|";

            int i = 0;
            while (i < lstGroupMembers.Items.Count)
            {
                if (members.IndexOf("|" + lstGroupMembers.Items[i].Value + "|") < 0) lstGroupMembers.Items.RemoveAt(i);
                else i += 1;
            }
        }

        protected void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListItem item in lstUsers.Items)
                    if (item.Selected)
                        GroupMemberDB.AddUser(Convert.ToInt32(item.Value), groupInfo.Group_ID);
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
                foreach (ListItem item in lstGroupMembers.Items)
                    if (item.Selected)
                        GroupMemberDB.RemoverUser(Convert.ToInt32(item.Value), groupInfo.Group_ID);
                lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch
            {
                lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
            }
        }
    }
}