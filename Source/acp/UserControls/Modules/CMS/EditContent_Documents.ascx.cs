using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;
using iDKCMS.Library.WebBase;

namespace iDKCMS.BackEnd.UserControls.Modules.CMS
{
    public partial class EditContent_Documents : AdminControl
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

            var strSQL = "SELECT CMS_ContentDownload.*, CMS_Download.* FROM CMS_ContentDownload ";
            strSQL += " INNER JOIN CMS_Download ON CMS_ContentDownload.Download_ID = CMS_Download.Download_ID ";
            strSQL += " WHERE 1=1 ";

            strSQL += " AND CMS_ContentDownload.Content_ID=" + _contentId + " ";

            if (dtgPix.SortBy == "") dtgPix.SortBy = "CMS_ContentDownload.Priority";
            strSQL += " ORDER BY " + dtgPix.SortBy + " " + dtgPix.OrderBy;

            var source = DataHelper.GetDataFromTable(strSQL);

            var curPage = dtgPix.GetCurrentPageIndex() + 1;
            if (curPage > source.Rows.Count / dtgPix.PageSize + ConvertUtility.ToInt32(source.Rows.Count % dtgPix.PageSize > 0) && curPage > 1)
                dtgPix.CurrentPageIndex = 0;

            dtgPix.DataSource = source;
            dtgPix.DataBind();
            lblTotal.Text = "Total: " + source.Rows.Count;

        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            var info = DownloadDB.GetInfo(ConvertUtility.ToInt32(txtID.Text));

            info.Download_Name = ConvertUtility.ToString(txtName.Text);
            info.Download_Description = txtTeaser.Text;
            info.Download_Visible = chkVisible.Checked;


            try
            {
                DownloadDB.Update(info);

                lblStatusUpdate.Text = lblStatusUpdate2.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch
            {
                lblStatusUpdate.Text = lblStatusUpdate2.Text = MiscUtility.UPDATE_ERROR;
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            var dirUpload = AppEnv.UploadDocument;
            double filesize = 0;
            string extension = "";

            string fileAvatarPath = "", newfileAvatarName = "";
            var info = new DownloadInfo();

            if (txtFile.PostedFile.FileName.Length > 0)
            {
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(txtFile.PostedFile.FileName);
                if (fileNameWithoutExtension != null)
                {
                    string filename = fileNameWithoutExtension.Replace(" ", "_").Replace("#", "_");
                    var s = Path.GetExtension(txtFile.PostedFile.FileName);
                    if (s != null)
                        extension = s.ToLower();

                    newfileAvatarName = filename + "_" + DateTime.Now.ToString("mmss") + txtFile.PostedFile.FileName.Substring(txtFile.PostedFile.FileName.LastIndexOf('.'));
                }
                txtFile.PostedFile.SaveAs(Server.MapPath(dirUpload) + newfileAvatarName);
                double filesizeb = txtFile.PostedFile.ContentLength;
                filesize = filesizeb / (1024 * 1024);

                fileAvatarPath = dirUpload + newfileAvatarName;
            }
            else
            {
                fileAvatarPath = "";
            }


            if (fileAvatarPath.Length > 0)
            {
                if (txtName.Text.Length > 0)
                    info.Download_Name = ConvertUtility.ToString(txtName.Text);
                else info.Download_Name = newfileAvatarName;
                info.Download_Description = txtTeaser.Text;
                info.Download_File = fileAvatarPath;
                info.Download_Extension = extension;
                info.Download_Visible = chkVisible.Checked;
                info.Download_CreateDate = DateTime.Now;
                info.Download_FileSize = ConvertUtility.ToDouble(filesize.ToString("#0.00"));
                info.Download_View = 0;
                info.User_ID = ConvertUtility.ToInt32(ckid);
                

                try
                {
                    var fileId = DownloadDB.Insert(info);

                    var contentDownloadInfo = new ContentDownloadInfo();
                    contentDownloadInfo.Content_ID = _contentId;
                    contentDownloadInfo.Download_ID = fileId;
                    contentDownloadInfo.Priority = 0;

                    ContentDownloadDB.Insert(contentDownloadInfo);

                    Response.Redirect(Request.RawUrl + "#idTab3");

                    lblStatusUpdate.Text = lblStatusUpdate2.Text = MiscUtility.UPDATE_SUCCESS;
                }
                catch
                {
                    lblStatusUpdate.Text = lblStatusUpdate2.Text = MiscUtility.UPDATE_ERROR;
                }
            }
        }

        protected void dtgPix_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var curData = (DataRowView)e.Item.DataItem;

                e.Item.Cells[1].Text = ConvertUtility.ToString(e.Item.DataSetIndex + 1);

                var txtUrl = (TextBox)e.Item.FindControl("txtUrl");
                var lnkName = (HyperLink)e.Item.FindControl("lnkName");
                var lblDatetime = (Label)e.Item.FindControl("lblDatetime");
                var txtPriority = (TextBox)e.Item.FindControl("txtPriority");
                var imgUser = (Image)e.Item.FindControl("imgUser");

                txtUrl.Text = "http://" + Request.Url.Host + curData["Download_File"];
                string tooltip = "<b>" + curData["Download_Name"] + "</b><br />" + "FileSize: " + curData["Download_FileSize"] + " KB" + "\n\n" + curData["Download_Description"];

                lnkName.Text = curData["Download_Name"].ToString();
                lnkName.ToolTip = tooltip;
                lblDatetime.Text = ConvertUtility.ToDateTime(curData["Download_CreateDate"]).ToString("dd/MM/yyyy HH:mm");
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

        protected void dtgPix_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                int id = ConvertUtility.ToInt32(e.Item.Cells[0].Text);
                DownloadInfo info = DownloadDB.GetInfo(id);
                try
                {
                    string file = info.Download_File;
                    if (file.Length > 0)
                    {
                        int lengUploadFile = AppEnv.UploadDocument.Length;
                        string filenameVideo = file.Substring(lengUploadFile);
                        FileInfo file5 = new FileInfo(Server.MapPath(AppEnv.UploadDocument) + filenameVideo);
                        if (file5.Exists)
                        {
                            file5.Delete();
                        }
                    }

                    ContentDownloadDB.Delete(_contentId, id);

                    DownloadDB.Delete(id);

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
                    int id = ConvertUtility.ToInt32(e.Item.Cells[0].Text);
                    DownloadInfo info = DownloadDB.GetInfo(id);

                    TextBox txtPriority = (TextBox)e.Item.FindControl("txtPriority");
                    CheckBox chkVisible = (CheckBox)e.Item.FindControl("chkVisible");

                    info.Download_Visible = ConvertUtility.ToBoolean(chkVisible.Checked);

                    DownloadDB.Update(info);

                    var ctinfo = ContentDownloadDB.GetInfo(_contentId, id);

                    ctinfo.Priority = ConvertUtility.ToInt32(txtPriority.Text);

                    ContentDownloadDB.Update(ctinfo);

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
                var info = DownloadDB.GetInfo(id);

                chkVisible.Checked = info.Download_Visible;
                txtName.Text = info.Download_Name;
                txtTeaser.Text = info.Download_Description;
                txtID.Text = id.ToString();
            }
        }
    }
}