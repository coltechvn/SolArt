using System;
using System.IO;
using iDKCMS.Library;

namespace iDKCMS.BackEnd.UserControls.Controls
{
    public partial class Editor : System.Web.UI.UserControl
    {

        public string HtmlValue
        {
            set { CKEditor1.Text = value; }
            get
            {
                string imgHost = "http://" + Request.Url.Host;
                if (!Request.Url.IsDefaultPort) imgHost += ":" + Request.Url.Port;
                return CKEditor1.Text.Replace(imgHost, string.Empty);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //RadEditor1.ImageManager.MaxUploadFileSize = AppEnv.ImageMaxSize;
            //RadEditor1.MediaManager.MaxUploadFileSize = AppEnv.MediahMaxSize;
            //RadEditor1.FlashManager.MaxUploadFileSize = AppEnv.FlashMaxSize;

            CKEditor1.config.toolbar = new object[]
			{
				new object[] { "Source", "-", "NewPage", "Preview", "-", "Templates" },
				new object[] { "Cut", "Copy", "Paste", "PasteText", "PasteFromWord" },
				new object[] { "Undo", "Redo", "-", "Find", "Replace", "-", "SelectAll", "RemoveFormat" },
				"/",
				new object[] { "Bold", "Italic", "Underline", "Strike", "-", "Subscript", "Superscript" },
				new object[] { "NumberedList", "BulletedList", "-", "Outdent", "Indent", "CreateDiv" },
				new object[] { "JustifyLeft", "JustifyCenter", "JustifyRight", "JustifyBlock" },
				new object[] { "Link", "Unlink", "Anchor" },
				new object[] { "Image", "Flash", "Table", "HorizontalRule", "SpecialChar", "Iframe" },
				"/",
				new object[] { "Styles", "Format", "Font", "FontSize" },
				new object[] { "TextColor", "BGColor" },
				new object[] { "Maximize", "ShowBlocks"}
			};
        }
    }
}