using System;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;
using iDKCMS.Library.WebBase;

namespace iDKCMS.BackEnd.UserControls.Modules.CMS
{
    public partial class DocList : AdminControl
    {
        private bool isManager, isDeployer, isCreater;

        protected void Page_Load(object sender, EventArgs e)
        {
            isManager = RoleDB.CheckRole(CurrentAdminInfo.User_ID, (int)AppEnv.CMSRole.Manager);
            isDeployer = RoleDB.CheckRole(CurrentAdminInfo.User_ID, (int)AppEnv.CMSRole.Deployer);
            isCreater = RoleDB.CheckRole(CurrentAdminInfo.User_ID, (int)AppEnv.CMSRole.Creater);
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
            if (isManager)
                dtgReturnList.DataSource = ContentDB.GetDocuments(zoneID);
            else
                dtgReturnList.DataSource = ContentDB.GetDocumentsByUserID(zoneID, CurrentAdminInfo.User_ID);
            dtgReturnList.DataBind();
        }

        protected void dtgReturnList_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                int contentID = ConvertUtility.ToInt32(e.Item.Cells[0].Text);
                switch (e.CommandName)
                {
                    case "deploy":
                        {
                            if (isManager || isDeployer)
                            {
                                ContentDB.SetStatus(contentID, (int)AppEnv.CMSWorkFlow.Deploy);
                                DistributionInfo newDist = new DistributionInfo();
                                newDist.Distribution_ContentID = contentID;
                                newDist.Distribution_ZoneID = ConvertUtility.ToInt32(dropZones.SelectedValue);
                                newDist.Distribution_Rank = (int)AppEnv.CMSContentRank.Default;
                                DistributionDB.Insert(newDist);
                                lblStatusUpdate.Text = AppEnv.MSG_Deploy + dropZones.SelectedItem.Text;
                            }
                            else
                                if (isCreater)
                                {
                                    ContentDB.SetStatus(contentID, (int)AppEnv.CMSWorkFlow.Waiting);
                                    lblStatusUpdate.Text = AppEnv.MSG_Waiting + dropZones.SelectedItem.Text;
                                }
                            break;
                        }
                    case "delete":
                        ContentDB.Delete(contentID);
                        lblStatusUpdate.Text = MiscUtility.UPDATE_SUCCESS;
                        break;
                    case "edit":
                        Response.Redirect(AppEnv.ADMIN_CMD + "cmseditcontent&contentid=" + contentID);
                        break;
                }
            }
            catch
            {
                lblStatusUpdate.Text = MiscUtility.UPDATE_ERROR;
            }
        }

        protected void dtgReturnList_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            HyperLink lnkHeadline = (HyperLink)e.Item.FindControl("lnkHeadline");
            lnkHeadline.Text = ContentDB.GetName(Convert.ToInt32(e.Item.Cells[0].Text));
            lnkHeadline.NavigateUrl = AppEnv.ADMIN_CMD + "cmsviewcontent&contentid=" + e.Item.Cells[0].Text;
            lnkHeadline.ToolTip = ContentDB.GetAuthorInfoByContentID(Convert.ToInt32(e.Item.Cells[0].Text));
            Button cmdDel = (Button)e.Item.FindControl("cmdDel");
            cmdDel.Attributes.Add("onclick", MiscUtility.DELETE_CONFIRM);
        }
    }
}