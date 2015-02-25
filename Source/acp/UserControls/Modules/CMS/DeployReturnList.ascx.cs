using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;
using iDKCMS.Library.WebBase;

namespace iDKCMS.BackEnd.UserControls.Modules.CMS
{
    public partial class DeployReturnList : AdminControl
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
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            int zoneID = ConvertUtility.ToInt32(dropZones.SelectedValue);
            AppEnv.ZoneSelected = zoneID;
            dtgReturnList.DataSource = ContentDB.GetContentsByUserID(zoneID, (int)AppEnv.CMSWorkFlow.Return, CurrentAdminInfo.User_ID);
            dtgReturnList.DataBind();
        }

        protected void dtgReturnList_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "deploywaiting":
                        ContentDB.SetStatus(ConvertUtility.ToInt32(e.Item.Cells[0].Text), (int)AppEnv.CMSWorkFlow.Waiting);
                        lblStatusUpdate.Text = AppEnv.MSG_Waiting + dropZones.SelectedItem.Text;
                        break;
                    case "delete":
                        ContentDB.Delete(ConvertUtility.ToInt32(e.Item.Cells[0].Text));
                        lblStatusUpdate.Text = MiscUtility.UPDATE_SUCCESS;
                        break;
                    case "edit":
                        Response.Redirect(AppEnv.ADMIN_CMD + "cmseditcontent&contentid=" + ConvertUtility.ToInt32(e.Item.Cells[0].Text));
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
            DataRowView rowData = (DataRowView)e.Item.DataItem;
            HyperLink lnkHeadline = (HyperLink)e.Item.FindControl("lnkHeadline");
            lnkHeadline.Text = ContentDB.GetInfo(ConvertUtility.ToInt32(e.Item.Cells[0].Text)).Content_Name;
            lnkHeadline.NavigateUrl = AppEnv.ADMIN_CMD + "cmsviewcontent&contentid=" + e.Item.Cells[0].Text;
            lnkHeadline.ToolTip = rowData["Content_Comment"].ToString();

            Button cmdDel = (Button)e.Item.FindControl("cmdDel");
            cmdDel.Attributes.Add("onclick", MiscUtility.DELETE_CONFIRM);
        }
    }
}