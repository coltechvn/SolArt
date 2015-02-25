using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;
using iDKCMS.Library.WebBase;

namespace iDKCMS.BackEnd.UserControls.Modules.CMS
{
    public partial class DeployBoxList : AdminControl
    {
        private bool isManager, isDeployer;
        private const int MAX_PRIORITY = 20;

        protected void Page_Load(object sender, EventArgs e)
        {
            isManager = RoleDB.CheckRole(CurrentAdminInfo.User_ID, (int)AppEnv.CMSRole.Manager);
            isDeployer = RoleDB.CheckRole(CurrentAdminInfo.User_ID, (int)AppEnv.CMSRole.Deployer);
            if (!IsPostBack) LoadZones();
            lblStatusUpdate.Text = string.Empty;
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            int zoneID = ConvertUtility.ToInt32(dropZones.SelectedValue);
            AppEnv.ZoneSelected = zoneID;
            if (!isManager && !isDeployer)
                dtgDeployList.DataSource = DistributionDB.GetDeployByZoneID(zoneID, CurrentAdminInfo.User_ID);
            else
            {
                int totalRecord;
                dtgDeployList.DataSource = DistributionDB.GetDeployByZoneID(zoneID, dtgDeployList.PageSize, dtgDeployList.CurrentPageIndex, out totalRecord);
                dtgDeployList.VirtualItemCount = totalRecord;
            }
            dtgDeployList.DataBind();

        }

        private void LoadZones()
        {
            if (isManager || isDeployer)
            {
                dropZones.DataSource = ZoneDB.GetStandAloneBox();
                dropZones.DataValueField = "Zone_ID";
                dropZones.DataTextField = "Zone_Name";
                dropZones.DataBind();
                dropZones.Items.Insert(0, new ListItem("Root", "0"));
            }

            MiscUtility.SetSelected(dropZones.Items, AppEnv.ZoneSelected.ToString());

        }

        protected void dtgDeployList_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView rowData = (DataRowView)e.Item.DataItem;

            DropDownList dropContentRank = (DropDownList)e.Item.FindControl("dropContentRank");
            dropContentRank.Items.FindByValue(rowData["Distribution_Rank"].ToString()).Selected = true;

            DropDownList dropIndex = (DropDownList)e.Item.FindControl("dropIndex");
            MiscUtility.FillIndex(dropIndex, MAX_PRIORITY, ConvertUtility.ToInt32(rowData["Distribution_Priority"]));

            HyperLink lnkHeadline = (HyperLink)e.Item.FindControl("lnkHeadline");
            lnkHeadline.Text = DistributionDB.GetNameByDistID(ConvertUtility.ToInt32(e.Item.Cells[0].Text));
            lnkHeadline.NavigateUrl = AppEnv.ADMIN_CMD + "cmsviewcontent&contentID=" + e.Item.Cells[1].Text;

            lnkHeadline.ToolTip = ContentDB.GetAuthorInfoByContentID(Convert.ToInt32(e.Item.Cells[1].Text));

            Button cmdRemove = (Button)e.Item.FindControl("cmdRemove");
            Button cmdDel = (Button)e.Item.FindControl("cmdDel");
            Button cmdEdit = (Button)e.Item.FindControl("cmdEdit");

            if (!isManager && !isDeployer)
            {
                cmdDel.Enabled = false;
                cmdEdit.Enabled = false;
                cmdRemove.Enabled = false;
                dropContentRank.Enabled = false;
                dropIndex.Enabled = false;
            }
            else
            {
                cmdRemove.Attributes.Add("onclick", MiscUtility.DELETE_CONFIRM);
                cmdDel.Attributes.Add("onclick", MiscUtility.DELETE_CONFIRM);
            }
        }

        protected void dtgDeployList_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "updaterank":
                        if (isManager || isDeployer)
                        {
                            foreach (DataGridItem item in dtgDeployList.Items)
                            {
                                DropDownList dropContentRank = (DropDownList)item.FindControl("dropContentRank");
                                DistributionDB.SetRank(ConvertUtility.ToInt32(item.Cells[0].Text), ConvertUtility.ToInt32(dropContentRank.SelectedValue));
                            }

                        }
                        break;
                    case "updatepriority":
                        if (isManager || isDeployer)
                        {
                            foreach (DataGridItem item in dtgDeployList.Items)
                            {
                                DropDownList dropIndex = (DropDownList)item.FindControl("dropIndex");
                                DistributionDB.SetPriority(ConvertUtility.ToInt32(item.Cells[0].Text), ConvertUtility.ToInt32(dropIndex.SelectedValue));
                            }
                        }
                        break;
                    case "remover":
                        DistributionDB.Delete(ConvertUtility.ToInt32(e.Item.Cells[0].Text));
                        break;
                    case "delete":
                        // xoa anh?
                        ContentDB.Delete(ConvertUtility.ToInt32(e.Item.Cells[1].Text));
                        break;
                    case "edit":
                        Response.Redirect(AppEnv.ADMIN_CMD + "cmseditcontent&contentid=" + ConvertUtility.ToInt32(e.Item.Cells[1].Text));
                        break;
                }
                lblStatusUpdate.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch
            {
                lblStatusUpdate.Text = MiscUtility.UPDATE_ERROR;
            }
        }
    }
}