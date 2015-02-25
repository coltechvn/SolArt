using System;
using iDKCMS.Library;

namespace iDKCMS.BackEnd.UserControls.Core
{
    public partial class SettingManager : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblStatusUpdate.Text = string.Empty;
            txtWebTitle.Text = AppEnv.WebTitle;
            txtMailServer.Text = AppEnv.MailServer;
            txtDefaultCacheExpire.Text = AppEnv.DefaultCacheExpire.ToString();
            txtMetaSearch.Text = AppEnv.MetaSearch;
            txtContactEmail.Text = AppEnv.ContactEmail;
            txtMailUsername.Text = AppEnv.MailUsername;
            txtMailPassword.Text = AppEnv.MailPassword;
            txtMailServerPort.Text = AppEnv.MailServerPort;
            txtBrochureFile.Text = AppEnv.DownloadBrochure;
            txtSound.Text = AppEnv.BackgroundMusic;
            txtHotline.Text = AppEnv.HotLine;
            txtYM1.Text = AppEnv.YahooID1;
            txtYM2.Text = AppEnv.YahooID2;
            txtMetaDescription.Text = AppEnv.MetaDescription;
        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            //try
            //{
            AppEnv.WebTitle = txtWebTitle.Text;
            AppEnv.MailServer = txtMailServer.Text;
            AppEnv.MailServerPort = txtMailServerPort.Text;
            AppEnv.DefaultCacheExpire = ConvertUtility.ToDouble(txtDefaultCacheExpire.Text);
            AppEnv.MetaSearch = txtMetaSearch.Text;
            AppEnv.ContactEmail = txtContactEmail.Text;
            AppEnv.MailUsername = txtMailUsername.Text;
            AppEnv.MailPassword = txtMailPassword.Text;
            AppEnv.DownloadBrochure = txtBrochureFile.Text;
            AppEnv.BackgroundMusic = txtSound.Text;
            AppEnv.HotLine = txtHotline.Text;
            AppEnv.YahooID1 = txtYM1.Text;
            AppEnv.YahooID2 = txtYM2.Text;
            AppEnv.MetaDescription = txtMetaDescription.Text;

            lblStatusUpdate.Text = MiscUtility.UPDATE_SUCCESS;
            //}
            //catch
            //{
            //    lblStatusUpdate.Text = MiscUtility.UPDATE_ERROR;
            //}
        }
    }
}