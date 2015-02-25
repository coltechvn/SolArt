using System;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;
using iDKCMS.Library.WebBase;

namespace iDKCMS.BackEnd.UserControls.Modules.CMS
{
    public partial class CreateContent : AdminControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                ContentDB.DeleteTemp();
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi trong quá trình dọn Temp");
                throw;
            }

            var info = GetContent();

            var newContentId = ContentDB.Insert(info);

            if(newContentId > 0)
                Response.Redirect(AppEnv.ADMIN_CMD + "cmseditcontent" + "&contentid=" + newContentId);
            else
            {
                MessageBox.Show("Không tạo được ID mới");
                return;
            }
        }

        private ContentInfo GetContent()
        {
            var contentInfo = new ContentInfo
                {
                    Content_Name = "",
                    Content_Teaser = "",
                    Content_Body = "",
                    Content_CreateDate = DateTime.Now,
                    Content_ModifiedDate = DateTime.Now,
                    Content_Status = 0,
                    Content_OriginalZoneID = 0,
                    Content_UserID = CurrentAdminInfo.User_ID,
                    Content_ModifiedUserID = CurrentAdminInfo.User_ID,
                    Content_Author = "",
                    Content_EventDate = DateTime.Now,
                    Content_FriendlyUrl = "",
                    Content_Comment = "",
                    Content_Visible = false,
                    Content_IsTemp = true
                };

            return contentInfo;
        }
    }
}