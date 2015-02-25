using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;
using iDKCMS.Library.WebBase;

namespace iDKCMS.BackEnd.UserControls.Modules.CMS
{
    public partial class EditContent_Basic : AdminControl
    {
        private ContentInfo contentInfo;
        private bool isManager, isDeployer, isCreater;
        //private string curDateString;

        protected void Page_Load(object sender, EventArgs e)
        {
            contentInfo = ContentDB.GetInfo(ConvertUtility.ToInt32(Request.QueryString["contentid"]));
            if (contentInfo == null) Response.Redirect(AppEnv.ADMIN_ACCESSDENY);
            //curDateString = contentInfo.Content_CreateDate.Year + "_" + contentInfo.Content_CreateDate.Month + "_" + contentInfo.Content_CreateDate.Day;

            isManager = RoleDB.CheckRole(CurrentAdminInfo.User_ID, (int)AppEnv.CMSRole.Manager);
            isDeployer = RoleDB.CheckRole(CurrentAdminInfo.User_ID, (int)AppEnv.CMSRole.Deployer);
            isCreater = RoleDB.CheckRole(CurrentAdminInfo.User_ID, (int)AppEnv.CMSRole.Creater);

            //string userUploadPath = Constants.UploadPath + contentInfo.Content_UserID + "/" + curDateString;
            //Editor1.UploadDir = userUploadPath;
            //txtAttachFile.fpUploadDir = userUploadPath;
            //txtAvatar.fpUploadDir = userUploadPath;

            //Editor1.UploadDir = Constants.UploadContent;
            //txtAttachFile.fpUploadDir = Constants.UploadAvatar;
            //txtAvatar.fpUploadDir = Constants.UploadAvatar;

            if (!IsPostBack) LoadZones();
            lblStatusUpdate.Text = string.Empty;
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (!IsPostBack)
            {
                var isTemp = contentInfo.Content_IsTemp;

                if (!isTemp)
                {
                    trRank.Visible = false;
                    spanDisableHeader.Visible = false;
                    chkVisible.Checked = contentInfo.Content_Visible;
                }
                else
                {
                    chkVisible.Checked = true;
                }

                txtName.Text = contentInfo.Content_Name;
                txtTeaser.Text = contentInfo.Content_Teaser;
                Editor1.HtmlValue = contentInfo.Content_Body;
                txtCreateDate.Text = contentInfo.Content_CreateDate.ToString();
                MiscUtility.SetSelected(dropZones.Items, contentInfo.Content_OriginalZoneID.ToString());
                txtAuthor.Text = contentInfo.Content_Author;
                txtEventDate.Text = contentInfo.Content_EventDate.ToShortDateString();
                Calendar1.SelectedDate = ConvertUtility.ToDateTime(contentInfo.Content_EventDate.ToShortDateString());
                txtFriendlyUrl.Text = contentInfo.Content_FriendlyUrl;
                chkExcludeFromSearch.Checked = contentInfo.Content_ExcludeFromSearch;
                chkIsPhoto.Checked = contentInfo.Content_IsPhoto;
                chkIsDownload.Checked = contentInfo.Content_IsDownload;
                chkIsVideo.Checked = contentInfo.Content_IsVideo;
                chkIsPoll.Checked = contentInfo.Content_IsPoll;
                chkIsProduct.Checked = contentInfo.Content_IsProduct;

                string zoneDeployed = "|";
                DataTable dtZoneDeployed = DistributionDB.GetZoneDeployed(contentInfo.Content_ID);
                foreach (DataRow row in dtZoneDeployed.Rows) zoneDeployed += row["Distribution_ZoneID"] + "|";

                foreach (ListItem item in lstZones.Items)
                    if (zoneDeployed.IndexOf("|" + item.Value + "|") >= 0) item.Selected = true;
                    else item.Selected = false;
            }
        }

        private void LoadZones()
        {
            lstZones.Enabled = false;

            if (isManager) ZoneUtility.LoadZones(dropZones.Items);
            else ZoneUtility.LoadZones(dropZones.Items, CurrentAdminInfo.User_ID);
            if (isManager || isDeployer) lstZones.Enabled = true;
            lstZones.Items.Clear();
            foreach (ListItem item in dropZones.Items) lstZones.Items.Add(new ListItem(item.Text, item.Value));

        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            contentInfo.Content_Name = txtName.Text;
            contentInfo.Content_Teaser = txtTeaser.Text;
            contentInfo.Content_Body = Editor1.HtmlValue;
            contentInfo.Content_CreateDate = ConvertUtility.ToDateTime(txtCreateDate.Text);
            contentInfo.Content_ModifiedDate = DateTime.Now;
            contentInfo.Content_OriginalZoneID = ConvertUtility.ToInt32(dropZones.SelectedValue);
            contentInfo.Content_ModifiedUserID = CurrentAdminInfo.User_ID;
            contentInfo.Content_Author = txtAuthor.Text;
            contentInfo.Content_EventDate = ConvertUtility.ToDateTime(txtEventDate.Text);
            contentInfo.Content_FriendlyUrl = UnicodeUtility.UnicodeToFriendlyUrl(txtName.Text);
            contentInfo.Content_ExcludeFromSearch = chkExcludeFromSearch.Checked;
            contentInfo.Content_IsPhoto = chkIsPhoto.Checked;
            contentInfo.Content_IsDownload = chkIsDownload.Checked;
            contentInfo.Content_IsVideo = chkIsVideo.Checked;
            contentInfo.Content_IsPoll = chkIsPoll.Checked;
            contentInfo.Content_IsProduct = chkIsProduct.Checked;
            contentInfo.Content_Visible = chkVisible.Checked;
            contentInfo.Content_IsTemp = false;

            if (isManager || isDeployer)
            {
                //try
                //{
                contentInfo.Content_Status = (int)AppEnv.CMSWorkFlow.Deploy;
                ContentDB.Update(contentInfo);

                lblStatusUpdate.Text = AppEnv.MSG_Deploy + "<br /> ";
                lstZones.Items.FindByValue(dropZones.SelectedValue).Selected = true;
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
                            newDist.Distribution_Rank = ConvertUtility.ToInt32(rdoContentRanks.SelectedValue);
                            newDist.Distribution_Layout = dropLayout.SelectedValue;
                            newDist.Distribution_DisableTeaser = chkDisableTeaser.Checked;
                            newDist.Distribution_DisableAvatar = chkDisableAvatar.Checked;
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
            else
            {
                //try
                //{
                ContentDB.Update(contentInfo);

                lblStatusUpdate.Text = lblStatusUpdate2.Text = MiscUtility.UPDATE_SUCCESS;
                //}
                //catch
                //{
                //    lblStatusUpdate.Text = MiscUtility.UPDATE_ERROR;
                //}
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtEventDate.Text = Calendar1.SelectedDate.ToShortDateString();
        }
    }
}