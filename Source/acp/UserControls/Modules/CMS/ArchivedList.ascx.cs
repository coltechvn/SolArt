using System;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;
using iDKCMS.Library.WebBase;

namespace iDKCMS.BackEnd.UserControls.Modules.CMS
{
    public partial class ArchivedList : AdminControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadZones();
            lblStatusUpdate.Text = string.Empty;
        }

        private void LoadZones()
        {
            ZoneUtility.LoadZones(dropZones.Items, CurrentAdminInfo.User_ID);
            MiscUtility.SetSelected(dropZones.Items, AppEnv.ZoneSelected.ToString());
            dropZones_SelectedIndexChanged(null, null);
        }

        protected void dtgWaitingDeployList_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            int contentID = ConvertUtility.ToInt32(e.Item.Cells[0].Text);

            if (e.CommandName == "deploywaiting")
            {
                try
                {
                    ContentDB.SetStatus(contentID, (int)AppEnv.CMSWorkFlow.Waiting);
                    lblStatusUpdate.Text = "<font color='blue'>Bài đã được gửi lên mục chờ đăng '" + dropZones.SelectedItem.Text + "'</font>";
                }
                catch
                {
                    lblStatusUpdate.Text = MiscUtility.UPDATE_ERROR;
                }

            }
            if (e.CommandName == "delete")
            {
                try
                {
                    ContentDB.Delete(contentID);
                    lblStatusUpdate.Text = MiscUtility.UPDATE_SUCCESS;
                }
                catch
                {
                    lblStatusUpdate.Text = MiscUtility.UPDATE_ERROR;
                }
            }
            if (e.CommandName == "edit")
            {
                Response.Redirect(AppEnv.ADMIN_CMD + "cmseditcontent&contentid=" + contentID);
            }
            dropZones_SelectedIndexChanged(null, null);
        }

        protected void dropZones_SelectedIndexChanged(object sender, EventArgs e)
        {
            int zoneID = ConvertUtility.ToInt32(dropZones.SelectedValue);
            AppEnv.ZoneSelected = zoneID;
            dtgWaitingDeployList.DataSource = ContentDB.GetContentsByUserID(zoneID, (int)AppEnv.CMSWorkFlow.Archive, CurrentAdminInfo.User_ID);
            dtgWaitingDeployList.DataBind();
        }

        protected void dtgWaitingDeployList_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            HyperLink lnkHeadline = (HyperLink)e.Item.FindControl("lnkHeadline");
            lnkHeadline.Text = ContentDB.GetName(ConvertUtility.ToInt32(e.Item.Cells[0].Text));
            lnkHeadline.NavigateUrl = AppEnv.ADMIN_CMD + "cmsviewcontent&contentid=" + e.Item.Cells[0].Text;

            Button cmdDel = (Button)e.Item.FindControl("cmdDel");
            cmdDel.Attributes.Add("onclick", MiscUtility.DELETE_CONFIRM);
        }
    }
}