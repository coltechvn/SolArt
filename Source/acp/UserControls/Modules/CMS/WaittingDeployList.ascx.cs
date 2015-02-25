using System;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;
using iDKCMS.Library.WebBase;

namespace iDKCMS.BackEnd.UserControls.Modules.CMS
{
    public partial class WaittingDeployList : AdminControl
    {
        private bool isManager, isDeployer;

        protected void Page_Load(object sender, EventArgs e)
        {
            isManager = RoleDB.CheckRole(CurrentAdminInfo.User_ID, (int)AppEnv.CMSRole.Manager);
            isDeployer = RoleDB.CheckRole(CurrentAdminInfo.User_ID, (int)AppEnv.CMSRole.Deployer);
            if (!IsPostBack) LoadZones();
            lblStatusUpdate.Text = string.Empty;
        }

        private void LoadZones()
        {
            if (isManager)
                ZoneUtility.LoadZones(dropZones.Items);
            else
                ZoneUtility.LoadZones(dropZones.Items, CurrentAdminInfo.User_ID);

            MiscUtility.SetSelected(dropZones.Items, AppEnv.ZoneSelected.ToString());
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            int zoneID = ConvertUtility.ToInt32(dropZones.SelectedValue);
            AppEnv.ZoneSelected = zoneID;
            if (!isManager && !isDeployer)
                dtgWaitingDeployList.DataSource = ContentDB.GetContentsByUserID(zoneID, (int)AppEnv.CMSWorkFlow.Waiting, CurrentAdminInfo.User_ID);
            else
                dtgWaitingDeployList.DataSource = ContentDB.GetContents(zoneID, (int)AppEnv.CMSWorkFlow.Waiting);
            dtgWaitingDeployList.DataBind();
        }

        protected void dtgWaitingDeployList_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "return")
            {
                try
                {
                    ContentDB.SetStatus(ConvertUtility.ToInt32(e.Item.Cells[0].Text), (int)AppEnv.CMSWorkFlow.Return);
                    ContentDB.SetComment(ConvertUtility.ToInt32(e.Item.Cells[0].Text), Convert.ToChar(34) + txtComment.Text + Convert.ToChar(34) + "\r\n Trả lại bởi : " + CurrentAdminInfo.User_FullName);
                    lblStatusUpdate.Text = AppEnv.MSG_Return + dropZones.SelectedItem.Text;
                    txtComment.Text = string.Empty;
                }
                catch
                {
                    lblStatusUpdate.Text = MiscUtility.UPDATE_ERROR;
                }
            }
            if (e.CommandName == "deploy")
            {
                try
                {
                    ContentDB.SetStatus(ConvertUtility.ToInt32(e.Item.Cells[0].Text), (int)AppEnv.CMSWorkFlow.Deploy);
                    lblStatusUpdate.Text = AppEnv.MSG_Deploy + dropZones.SelectedItem.Text;
                    DistributionInfo info = new DistributionInfo();
                    info.Distribution_ContentID = ConvertUtility.ToInt32(e.Item.Cells[0].Text);
                    info.Distribution_ZoneID = ConvertUtility.ToInt32(dropZones.SelectedValue);
                    info.Distribution_Rank = (int)AppEnv.CMSContentRank.Default;
                    DistributionDB.Insert(info);
                }
                catch
                {
                    lblStatusUpdate.Text = MiscUtility.UPDATE_ERROR;
                }
            }
        }

        protected void dtgWaitingDeployList_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            //DataRowView rowData = (DataRowView)e.Item.DataItem;
            HyperLink lnkHeadline = (HyperLink)e.Item.FindControl("lnkHeadline");
            int contentid = ConvertUtility.ToInt32(e.Item.Cells[0].Text);
            lnkHeadline.Text = ContentDB.GetName(contentid);
            lnkHeadline.NavigateUrl = AppEnv.ADMIN_CMD + "cmsviewcontent&contentid=" + e.Item.Cells[0].Text;
            lnkHeadline.ToolTip = ContentDB.GetAuthorInfoByContentID(contentid);
            Button cmdDeploy = (Button)e.Item.FindControl("cmdDeploy");
            Button cmdReturn = (Button)e.Item.FindControl("cmdReturn");
            if (!isManager && !isDeployer)
            {
                cmdDeploy.Enabled = false;
                cmdReturn.Enabled = false;
            }
        }
    }
}