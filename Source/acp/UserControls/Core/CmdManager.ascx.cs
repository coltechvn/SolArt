using System;
using System.Data;
using System.Web.UI.WebControls;
using ComponentArt.Web.UI;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;
using iDKCMS.Library.WebBase;
namespace iDKCMS.BackEnd.UserControls.Core
{
    public partial class CmdManager : AdminControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentAdminInfo.User_Email != AppEnv.ADMIN_EMAIL) Response.Redirect(AppEnv.ADMIN_ACCESSDENY);
            lblUpdateStatus.Text = string.Empty;
            cmdDelete.Attributes.Add("onclick", MiscUtility.DELETE_CONFIRM);
        }

        private string nodePath;

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            CmdDB.FillToListBox(dropParent.Items);
            dropParent.Items.Insert(0, new ListItem("Root", "0"));

            if (txtID.Text != string.Empty)
            {
                CmdInfo info = CmdDB.GetInfo(ConvertUtility.ToInt32(txtID.Text));
                if (info != null)
                {
                    dropParent.SelectedIndex = -1;
                    MiscUtility.SetSelected(dropParent.Items, info.Cmd_ParentID.ToString());
                }
            }

            nodePath = "|";
            TreeViewNode focusNode = tvwCmds.SelectedNode;
            if (focusNode != null)
            {
                while (true)
                {
                    if (focusNode.ParentNode == null) break;
                    else
                    {
                        focusNode = focusNode.ParentNode;
                        nodePath += focusNode.ID + "|";
                    }
                }
            }

            tvwCmds.Nodes.Clear();
            TreeViewNode topRoot = new TreeViewNode();
            topRoot.Text = "Root";
            topRoot.ID = "0";
            tvwCmds.Nodes.Add(topRoot);

            DataTable dtRoot = CmdDB.GetByParentID(0);
            foreach (DataRow row in dtRoot.Rows)
            {
                TreeViewNode rootNode = new TreeViewNode();
                rootNode.Text = row["Cmd_Name"].ToString();
                rootNode.ID = row["Cmd_ID"].ToString();

                if (nodePath.IndexOf("|" + rootNode.ID + "|") >= 0) rootNode.Expanded = true;
                tvwCmds.Nodes.Add(rootNode);
                LoadCmdItem(rootNode);
            }
        }

        private void LoadCmdItem(TreeViewNode curNode)
        {
            int curID = Convert.ToInt32(curNode.ID);
            DataTable dtChild = CmdDB.GetByParentID(curID);
            TreeViewNode childNode;
            foreach (DataRow row in dtChild.Rows)
            {
                childNode = new TreeViewNode();
                childNode.Text = row["Cmd_Name"].ToString();
                childNode.ID = row["Cmd_ID"].ToString();

                if (nodePath.IndexOf("|" + childNode.ID + "|") >= 0) childNode.Expanded = true;
                curNode.Nodes.Add(childNode);
                LoadCmdItem(childNode);
            }
        }

        protected void cmdAddNew_Click(object sender, EventArgs e)
        {
            if ((txtCmd.Text != string.Empty) && (CmdDB.GetIDByCmd(txtCmd.Text) != 0))
            {
                lblUpdateStatus.Text = "<font color='red'> Đã tồn tại chức năng này! </font>";
                return;
            }
            CmdInfo info = new CmdInfo();
            info.Cmd_Name = txtName.Text.Trim();
            info.Cmd_Value = txtCmd.Text.Trim();
            info.Cmd_Params = txtParams.Text.Trim();
            info.Cmd_Url = txtUrl.Text.Trim();
            info.Cmd_Path = txtPath.Text.Trim();

            info.Cmd_Enable = chkEnable.Checked;
            info.Cmd_Visible = chkVisble.Checked;
            info.Cmd_ParentID = ConvertUtility.ToInt32(dropParent.SelectedValue);

            try
            {
                txtID.Text = CmdDB.Insert(info).ToString();
                lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
            }
        }

        protected void tvwCmds_NodeSelected(object sender, TreeViewNodeEventArgs e)
        {
            int curID = ConvertUtility.ToInt32(e.Node.ID);
            CmdInfo info = CmdDB.GetInfo(curID);
            if (info == null)
            {
                cmdEmpty_Click(null, null);
                return;
            }

            txtID.Text = info.Cmd_ID.ToString();
            txtName.Text = info.Cmd_Name;
            txtCmd.Text = info.Cmd_Value;
            txtParams.Text = info.Cmd_Params;
            txtPath.Text = info.Cmd_Path;
            txtUrl.Text = info.Cmd_Url;

            int maxIndex = CmdDB.GetChildCount(info.Cmd_ParentID);
            MiscUtility.FillIndex(dropIndex, maxIndex, info.Cmd_Index);
            chkEnable.Checked = info.Cmd_Enable;
            chkVisble.Checked = info.Cmd_Visible;
        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            CmdInfo info = CmdDB.GetInfo(ConvertUtility.ToInt32(txtID.Text));
            if (info == null) return;

            int cmdID = CmdDB.GetIDByCmd(txtCmd.Text);
            if ((txtCmd.Text != string.Empty) && (cmdID != 0) && (cmdID != info.Cmd_ID))
            {
                lblUpdateStatus.Text = "<font color='red'> Đã tồn tại chức năng này! </font>";
                return;
            }

            info.Cmd_Name = txtName.Text.Trim();
            info.Cmd_Value = txtCmd.Text.Trim();
            info.Cmd_Params = txtParams.Text.Trim();
            info.Cmd_Url = txtUrl.Text.Trim();
            info.Cmd_Path = txtPath.Text.Trim();

            info.Cmd_Enable = chkEnable.Checked;
            info.Cmd_Visible = chkVisble.Checked;

            info.Cmd_Index = ConvertUtility.ToInt32(dropIndex.SelectedValue);
            info.Cmd_ParentID = ConvertUtility.ToInt32(dropParent.SelectedValue);

            if (info.Cmd_ID == info.Cmd_ParentID)
            {
                lblUpdateStatus.Text = "<font color='red'> Trùng mục cha, chọn mục cha khác! </font>";
                return;
            }
            try
            {
                CmdDB.Update(info);
                lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch (Exception eex)
            {
                string t = eex.Message;
                lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
            }
        }

        protected void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                CmdDB.Delete(ConvertUtility.ToInt32(txtID.Text));
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
            txtName.Text = string.Empty;
            txtCmd.Text = string.Empty;
            txtParams.Text = string.Empty;
            txtPath.Text = string.Empty;
            txtUrl.Text = string.Empty;
            chkEnable.Checked = true;
            chkVisble.Checked = true;
            dropParent.SelectedIndex = -1;
        }
    }
}