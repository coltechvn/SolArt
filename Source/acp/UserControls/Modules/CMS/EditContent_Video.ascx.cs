using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;
using iDKCMS.Library.WebBase;

namespace iDKCMS.BackEnd.UserControls.Modules.CMS
{
    public partial class EditContent_Video : AdminControl
    {
        int ckid;
        private int _contentId;

        protected void Page_Load(object sender, EventArgs e)
        {
            ckid = ConvertUtility.ToInt32(CurrentAdminInfo.User_ID);

            _contentId = ConvertUtility.ToInt32(Request.QueryString["contentid"]);

            if (!IsPostBack)
            {
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            var strSQL = "SELECT CMS_ContentVideo.*, CMS_Videos.* FROM CMS_ContentVideo ";
            strSQL += " INNER JOIN CMS_Videos ON CMS_ContentVideo.Video_ID = CMS_Videos.Video_ID ";
            strSQL += " WHERE 1=1 ";

            strSQL += " AND CMS_ContentVideo.Content_ID=" + _contentId + " ";

            if (dtgData.SortBy == "") dtgData.SortBy = "CMS_ContentVideo.Priority";
            strSQL += " ORDER BY " + dtgData.SortBy + " " + dtgData.OrderBy;

            var source = DataHelper.GetDataFromTable(strSQL);

            var curPage = dtgData.GetCurrentPageIndex() + 1;
            if (curPage > source.Rows.Count / dtgData.PageSize + ConvertUtility.ToInt32(source.Rows.Count % dtgData.PageSize > 0) && curPage > 1)
                dtgData.CurrentPageIndex = 0;

            dtgData.DataSource = source;
            dtgData.DataBind();
            lblTotal.Text = "Total: " + source.Rows.Count;

        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            var info = new VideoInfo();

            info.Video_Name = ConvertUtility.ToString(txtName.Text);
            info.Video_Description = txtTeaser.Text;
            info.Video_Type = dropType.SelectedValue;
            info.Video_File = txtFile.Text;
            info.Video_YouTube = txtYoutube.Text;
            info.Video_Width = ConvertUtility.ToInt32(AppEnv.VideoWidth);
            info.Video_Height = ConvertUtility.ToInt32(AppEnv.VideoHeight);
            info.Video_CreateDate = DateTime.Now;
            info.Video_View = 0;
            info.User_ID = ConvertUtility.ToInt32(ckid);
            info.Video_Visible = chkVisible.Checked;

            try
            {
                var videoId = VideoDB.Insert(info);

                var contentVideoInfo = new ContentVideoInfo();
                contentVideoInfo.Content_ID = _contentId;
                contentVideoInfo.Video_ID = videoId;
                contentVideoInfo.Priority = 0;

                ContentVideoDB.Insert(contentVideoInfo);

                //Response.Redirect(Request.RawUrl + "#idTab4");

                lblStatusUpdate.Text = lblStatusUpdate2.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch
            {
                lblStatusUpdate.Text = lblStatusUpdate2.Text = MiscUtility.UPDATE_ERROR;
            }
        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            var info = VideoDB.GetInfo(ConvertUtility.ToInt32(txtID.Text));

            info.Video_Name = ConvertUtility.ToString(txtName.Text);
            info.Video_Description = txtTeaser.Text;
            info.Video_Type = dropType.SelectedValue;
            info.Video_File = txtFile.Text;
            info.Video_YouTube = txtYoutube.Text;
            info.Video_Visible = chkVisible.Checked;


            try
            {
                VideoDB.Update(info);

                lblStatusUpdate.Text = lblStatusUpdate2.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch
            {
                lblStatusUpdate.Text = lblStatusUpdate2.Text = MiscUtility.UPDATE_ERROR;
            }
        }

        protected void dtgData_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                var id = ConvertUtility.ToInt32(e.Item.Cells[0].Text);
                try
                {
                    ContentVideoDB.Delete(_contentId, id);

                    VideoDB.Delete(id);

                    lblStatusUpdate.Text = MiscUtility.UPDATE_SUCCESS;
                }
                catch
                {
                    lblStatusUpdate.Text = MiscUtility.UPDATE_ERROR;
                }
            }
            if (e.CommandName == "updaterow")
            {
                try
                {
                    var id = ConvertUtility.ToInt32(e.Item.Cells[0].Text);
                    var info = VideoDB.GetInfo(id);

                    var txtPriority = (TextBox)e.Item.FindControl("txtPriority");
                    var chkVisible = (CheckBox)e.Item.FindControl("chkVisible");

                    info.Video_Visible = ConvertUtility.ToBoolean(chkVisible.Checked);

                    VideoDB.Update(info);

                    var ctinfo = ContentVideoDB.GetInfo(_contentId, id);

                    ctinfo.Priority = ConvertUtility.ToInt32(txtPriority.Text);

                    ContentVideoDB.Update(ctinfo);

                    lblStatusUpdate.Text = MiscUtility.UPDATE_SUCCESS;
                }
                catch
                {
                    lblStatusUpdate.Text = MiscUtility.UPDATE_ERROR; //ex.ToString();
                }
            }
            if (e.CommandName == "editrow")
            {
                lblStatusUpdate.Text = lblStatusUpdate2.Text = string.Empty;

                var id = ConvertUtility.ToInt32(e.Item.Cells[0].Text);
                var info = VideoDB.GetInfo(id);

                dropType.ClearSelection();
                MiscUtility.SetSelected(dropType.Items, info.Video_Type);
                chkVisible.Checked = info.Video_Visible;
                txtFile.Text = info.Video_File;
                txtYoutube.Text = info.Video_YouTube;
                txtName.Text = info.Video_Name;
                txtTeaser.Text = info.Video_Description;
                txtID.Text = id.ToString();

            }
        }

        protected void dtgData_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var curData = (DataRowView)e.Item.DataItem;

                e.Item.Cells[1].Text = ConvertUtility.ToString(e.Item.DataSetIndex + 1);

                var lnkName = (HyperLink)e.Item.FindControl("lnkVideo");
                var txtUrl = (TextBox)e.Item.FindControl("txtUrl");
                var lblDatetime = (Label)e.Item.FindControl("lblDatetime");
                var txtPriority = (TextBox)e.Item.FindControl("txtPriority");
                var imgUser = (Image)e.Item.FindControl("imgUser");

                lnkName.Text = curData["Video_Name"].ToString();

                if (curData["Video_Type"].ToString() == "youtube")
                    txtUrl.Text = curData["Video_YouTube"].ToString();
                else
                    txtUrl.Text = "http://" + Request.Url.Host + curData["Video_File"];

                lblDatetime.Text = ConvertUtility.ToDateTime(curData["Video_CreateDate"]).ToString("dd/MM/yyyy HH:mm");
                txtPriority.Text = curData["Priority"].ToString();
                
                string userEmail = ConvertUtility.ToString(UserDB.GetEmailByID(ConvertUtility.ToInt32(curData["User_ID"])));
                if (string.IsNullOrEmpty(userEmail))
                    imgUser.Visible = false;
                else
                {
                    imgUser.Visible = true;
                    imgUser.ToolTip = userEmail;
                }

                var btn_delete = (WebControl)e.Item.FindControl("btn_delete");
                btn_delete.Attributes.Add("onclick", MiscUtility.DELETE_CONFIRM);

                e.Item.Attributes.Add("onmouseover", "this.className='Hoverrow';");
                if (e.Item.ItemType == ListItemType.AlternatingItem)
                    e.Item.Attributes.Add("onmouseout", "this.className='DarkRow';");
                else
                    e.Item.Attributes.Add("onmouseout", "this.className='LightRow';");
            }
        }
    }
}