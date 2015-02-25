using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;
using iDKCMS.Library.WebBase;

namespace iDKCMS.BackEnd.UserControls.Modules.CMS
{
    public partial class EditContent_Box : AdminControl
    {
        private ContentInfo contentInfo;
        private bool isManager, isDeployer, isCreater;

        protected void Page_Load(object sender, EventArgs e)
        {
            contentInfo = ContentDB.GetInfo(ConvertUtility.ToInt32(Request.QueryString["contentid"]));
            if (contentInfo == null) Response.Redirect(AppEnv.ADMIN_ACCESSDENY);

            isManager = RoleDB.CheckRole(CurrentAdminInfo.User_ID, (int)AppEnv.CMSRole.Manager);
            isDeployer = RoleDB.CheckRole(CurrentAdminInfo.User_ID, (int)AppEnv.CMSRole.Deployer);
            isCreater = RoleDB.CheckRole(CurrentAdminInfo.User_ID, (int)AppEnv.CMSRole.Creater);

            lblStatusUpdate.Text = string.Empty;

            if (!IsPostBack) LoadZones();
        }

        private void LoadZones()
        {
            lstZones.Enabled = false;

            if (isManager || isDeployer)
            {
                lstZones.DataSource = ZoneDB.GetStandAloneBox();
                lstZones.DataValueField = "Zone_ID";
                lstZones.DataTextField = "Zone_Name";
                lstZones.DataBind();
            }

            if (isManager || isDeployer) lstZones.Enabled = true;
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (!IsPostBack)
            {
                string zoneDeployed = "|";
                DataTable dtZoneDeployed = DistributionDB.GetZoneDeployed(contentInfo.Content_ID);
                foreach (DataRow row in dtZoneDeployed.Rows) zoneDeployed += row["Distribution_ZoneID"] + "|";

                foreach (ListItem item in lstZones.Items)
                    if (zoneDeployed.IndexOf("|" + item.Value + "|") >= 0) item.Selected = true;
                    else item.Selected = false;
            }
        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            if (isManager || isDeployer)
            {
                //try
                //{

                lblStatusUpdate.Text = AppEnv.MSG_Deploy + "<br /> ";
                //lstZones.Items.FindByValue(dropZones.SelectedValue).Selected = true;
                foreach (ListItem item in lstZones.Items)
                    if (item.Selected)
                    {
                        if (!DistributionDB.CheckContentExist(contentInfo.Content_ID, Convert.ToInt32(item.Value)))
                        {
                            //DistributionDB.RemoverInZoneID(contentInfo.Content_ID, Convert.ToInt32(item.Value));
                            int zoneID = ConvertUtility.ToInt32(item.Value);
                            var newDist = new DistributionInfo();
                            newDist.Distribution_ContentID = contentInfo.Content_ID;
                            newDist.Distribution_ZoneID = zoneID;
                            newDist.Distribution_CreateDate = DateTime.Now;
                            newDist.Distribution_Rank = ConvertUtility.ToInt32(AppEnv.CMSContentRank.Default);
                            newDist.Distribution_Layout = "zone";
                            newDist.Distribution_DisableTeaser = false;
                            newDist.Distribution_DisableAvatar = false;
                            DistributionDB.Insert(newDist);
                        }
                        lblStatusUpdate.Text += item.Text + ",<br>";
                    }
                    else
                        DistributionDB.RemoverInZoneID(contentInfo.Content_ID, Convert.ToInt32(item.Value));



                lblStatusUpdate.Text = lblStatusUpdate.Text.Substring(0, lblStatusUpdate.Text.Length - 5) + "</font>";
                lblStatusUpdate2.Text = MiscUtility.UPDATE_SUCCESS;
                //cmdHuy_Click(null, null);
                //}
                //catch
                //{
                //    lblStatusUpdate.Text = MiscUtility.UPDATE_ERROR;
                //}
            }
        }
    }
}