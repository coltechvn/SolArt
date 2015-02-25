using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;
using iDKCMS.Library.WebBase;
using Image = System.Web.UI.WebControls.Image;

namespace iDKCMS.BackEnd.UserControls.Modules.CMS
{
    public partial class EditContent_Images : AdminControl
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

            var strSQL = "SELECT CMS_ContentImage.*, CMS_Images.* FROM CMS_ContentImage ";
            strSQL += " INNER JOIN CMS_Images ON CMS_ContentImage.Image_ID = CMS_Images.Image_ID ";
            strSQL += " WHERE 1=1 ";

            strSQL += " AND CMS_ContentImage.Content_ID=" + _contentId + " ";

            if (dtgPix.SortBy == "") dtgPix.SortBy = "CMS_ContentImage.Priority";
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
            var info = ImageDB.GetInfo(ConvertUtility.ToInt32(txtID.Text));

            info.Image_Name = ConvertUtility.ToString(txtName.Text);
            info.Image_Description = txtTeaser.Text;
            info.Image_Visible = chkVisible.Checked;


            try
            {
                ImageDB.Update(info);

                lblStatusUpdate.Text = lblStatusUpdate2.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch
            {
                lblStatusUpdate.Text = lblStatusUpdate2.Text = MiscUtility.UPDATE_ERROR;
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            var dirAvatarOriginal = AppEnv.UploadImagesOriginalDir;
            const string dirAvatarNormal = AppEnv.UploadImagesNormalDir;
            const string dirAvatarThumb = AppEnv.UploadImagesThumbDir;
            var imgWidth = 0;
            var imgHeight = 0;
            double filesize = 0;

            string fileAvatarPath = "", newfileAvatarName = "";
            var info = new ImageInfo();

            var imageCount = ContentImageDB.GetQuantityImageOfContent(_contentId);

            if (txtFile.PostedFile.FileName.Length > 0)
            {
                //string fileAvatarName = Path.GetFileNameWithoutExtension(txtFile.PostedFile.FileName).Replace(" ", "_").Replace("#", "_");
                newfileAvatarName = "image_" + _contentId + "_" + imageCount + txtFile.PostedFile.FileName.Substring(txtFile.PostedFile.FileName.LastIndexOf('.'));
                
                var file4 = new FileInfo(Server.MapPath(AppEnv.UploadImagesNormalDir) + newfileAvatarName);
                if (file4.Exists)
                {
                    newfileAvatarName = "image_" + _contentId + "_" + imageCount + "_" + DateTime.Now.ToString("mmss") + txtFile.PostedFile.FileName.Substring(txtFile.PostedFile.FileName.LastIndexOf('.'));
                }
                txtFile.PostedFile.SaveAs(Server.MapPath(dirAvatarOriginal) + newfileAvatarName);
                double filesizeb = txtFile.PostedFile.ContentLength;
                filesize = filesizeb / 1024;

                //thumbnail creation starts
                //                try
                //                {
                // dinh dang width height mac dinh de scale
                int smallWidth = ConvertUtility.ToInt32(AppEnv.ThumbWidth); ;
                int smallHeight = ConvertUtility.ToInt32(AppEnv.ThumbHeight);
                int normalWidth = ConvertUtility.ToInt32(AppEnv.NormalWidth);
                int normalHeight = ConvertUtility.ToInt32(AppEnv.NormalHeight);
                double scalesmall = 0;
                double scalenormal = 0;

                string imageUrl = Server.MapPath(dirAvatarOriginal + newfileAvatarName); // xac dinh anh chuan bi thumbnail

                Bitmap InputBitmap = new Bitmap(imageUrl); // tao anh bitmap

                // xac dinh % de resize
                imgWidth = InputBitmap.Width;
                imgHeight = InputBitmap.Height;
                if (smallHeight == 0)//InputBitmap.Height < InputBitmap.Width)
                {
                    scalesmall = ((double)smallWidth) / InputBitmap.Width;
                    scalenormal = ((double)normalWidth) / InputBitmap.Width;
                }

                int newSmallWidth = 0;
                int newSmallHeight = 0;
                int newNormalWidth = 0;
                int newNormalHeight = 0;
                if (smallHeight == 0)
                {
                    newSmallWidth = (int)(scalesmall * InputBitmap.Width);
                    newSmallHeight = (int)(scalesmall * InputBitmap.Height);

                    if (normalWidth < imgWidth)
                    {
                        newNormalWidth = (int)(scalenormal * InputBitmap.Width);
                        newNormalHeight = (int)(scalenormal * InputBitmap.Height);
                    }
                    else
                    {
                        newNormalWidth = imgWidth;
                        newNormalHeight = imgHeight;
                    }
                }
                else
                {
                    newSmallWidth = smallWidth;
                    newSmallHeight = smallHeight;
                    newNormalWidth = normalWidth;
                    newNormalHeight = normalHeight;
                }

                Bitmap OutputBitmapSmall = new Bitmap(InputBitmap, newSmallWidth, newSmallHeight); // tao anh bitmap voi size small moi
                Bitmap OutputBitmapNormal = new Bitmap(InputBitmap, newNormalWidth, newNormalHeight); // tao anh bitmap voi size normal moi

                // xac dinh mime type
                //Response.Clear();
                //Response.ContentType="image/Jpeg";

                //moi
                ImageCodecInfo[] Info = ImageCodecInfo.GetImageEncoders();
                EncoderParameters Params = new EncoderParameters(1);
                Params.Param[0] = new EncoderParameter(Encoder.Quality, 100L);
                //Response.ContentType = Info[1].MimeType;
                //thumbnail.Save(Response.OutputStream,Info[1],Params);
                InputBitmap.Dispose();

                OutputBitmapSmall.Save(Server.MapPath(dirAvatarThumb) + newfileAvatarName, Info[1], Params);
                OutputBitmapNormal.Save(Server.MapPath(dirAvatarNormal) + newfileAvatarName, Info[1], Params);

                // thuc hien
                OutputBitmapSmall.Dispose();
                OutputBitmapNormal.Dispose();
                
                //				}
                //				catch(Exception ex)
                //				{
                //					Response.Write("An error occurred - " + ex.ToString());
                //				}

                //MultimediaUtility.SetThumbnail(Server.MapPath(dirLarge + newfileoutsidename), Server.MapPath(dirThumb), ConvertUtility.ToInt32(Constants.ThumbWidth), ConvertUtility.ToInt32(Constants.ThumbHeight));
                //ImageDB.CreateThumbnail(dirThumb, dirLarge + newfileoutsidename);


                fileAvatarPath = dirAvatarThumb + newfileAvatarName;
                //fileAvatarPath = dirAvatarOriginal + newfileAvatarName;

                //MultimediaUtility.SetAvatarThumbnail(Server.MapPath(fileAvatarPath), 250, 0);
            }
            else
            {
                fileAvatarPath = "";
            }


            if (fileAvatarPath.Length > 0)
            {
                if (txtName.Text.Length > 0)
                    info.Image_Name = ConvertUtility.ToString(txtName.Text);
                else info.Image_Name = newfileAvatarName;
                info.Image_Description = txtTeaser.Text;
                info.Image_File = fileAvatarPath;
                info.Image_CreateDate = DateTime.Now;
                info.Image_FileSize = ConvertUtility.ToDouble(filesize.ToString("#0.00"));
                info.Image_Width = imgWidth;
                info.Image_Height = imgHeight;
                info.Image_View = 0;
                info.User_ID = ConvertUtility.ToInt32(ckid);
                info.Image_Visible = chkVisible.Checked;

                try
                {
                    var imgId = ImageDB.Insert(info);

                    var contentImgInfo = new ContentImageInfo();
                    contentImgInfo.Content_ID = _contentId;
                    contentImgInfo.Image_ID = imgId;
                    if (imageCount == 0)
                        contentImgInfo.IsCover = true;
                    else
                        contentImgInfo.IsCover = false;
                    contentImgInfo.Priority = imageCount;

                    ContentImageDB.Insert(contentImgInfo);

                    Response.Redirect(Request.RawUrl + "#idTab2");

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
                DataRowView curData = (DataRowView)e.Item.DataItem;

                e.Item.Cells[2].Text = ConvertUtility.ToString(e.Item.DataSetIndex + 1);

                TextBox txtUrl = (TextBox)e.Item.FindControl("txtUrl");
                Image imgAvatar = (Image)e.Item.FindControl("imgAvatar");
                Label lblDatetime = (Label)e.Item.FindControl("lblDatetime");
                TextBox txtPriority = (TextBox)e.Item.FindControl("txtPriority");
                Image imgUser = (Image)e.Item.FindControl("imgUser");
                var chkCover = (CheckBox)e.Item.FindControl("chkCover");

                txtUrl.Text = "http://" + Request.Url.Host + curData["Image_File"];
                string tooltip = "<b>" + curData["Image_Name"] + "</b><br />" + "FileSize: " + curData["Image_FileSize"] + " KB" + "\n" + "Dimension: " + curData["Image_Width"] + " x " + curData["Image_Height"] + "\n\n" + curData["Image_Description"];
                string avatar = ConvertUtility.ToString(curData["Image_File"]);
                if (string.IsNullOrEmpty(avatar))
                    imgAvatar.Visible = false;
                else
                {
                    imgAvatar.Visible = true;
                    imgAvatar.ImageUrl = avatar;
                    imgAvatar.AlternateText = tooltip;
                }
                lblDatetime.Text = ConvertUtility.ToDateTime(curData["Image_CreateDate"]).ToString("dd/MM/yyyy HH:mm");
                txtPriority.Text = curData["Priority"].ToString();
                chkCover.Checked = ConvertUtility.ToBoolean(curData["IsCover"]);
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
                ImageInfo info = ImageDB.GetInfo(id);
                try
                {
                    string avatarsource = info.Image_File;
                    if (avatarsource.Length > 0)
                    {
                        int lengUploadString3 = AppEnv.UploadImagesThumbDir.Length;
                        string filename3 = avatarsource.Substring(lengUploadString3);
                        FileInfo file3 = new FileInfo(Server.MapPath(AppEnv.UploadImagesThumbDir) + filename3);
                        if (file3.Exists)
                        {
                            file3.Delete();
                        }
                        FileInfo file4 = new FileInfo(Server.MapPath(AppEnv.UploadImagesNormalDir) + filename3);
                        if (file4.Exists)
                        {
                            file4.Delete();
                        }
                        FileInfo file5 = new FileInfo(Server.MapPath(AppEnv.UploadImagesOriginalDir) + filename3);
                        if (file5.Exists)
                        {
                            file5.Delete();
                        }
                    }

                    ContentImageDB.Delete(_contentId, id);

                    ImageDB.Delete(id);

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
                    ImageInfo info = ImageDB.GetInfo(id);

                    TextBox txtPriority = (TextBox)e.Item.FindControl("txtPriority");
                    CheckBox chkVisible = (CheckBox)e.Item.FindControl("chkVisible");
                    CheckBox chkCover = (CheckBox)e.Item.FindControl("chkCover");

                    info.Image_Visible = ConvertUtility.ToBoolean(chkVisible.Checked);

                    ImageDB.Update(info);

                    ContentImageInfo ctinfo = ContentImageDB.GetInfo(_contentId, id);

                    ctinfo.Priority = ConvertUtility.ToInt32(txtPriority.Text);
                    ctinfo.IsCover = ConvertUtility.ToBoolean(chkCover.Checked);

                    ContentImageDB.Update(ctinfo);

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
                var info = ImageDB.GetInfo(id);

                chkVisible.Checked = info.Image_Visible;
                txtName.Text = info.Image_Name;
                txtTeaser.Text = info.Image_Description;
                txtID.Text = id.ToString();
            }
        }
    }
}