using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Xml;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.Library
{
    public class AppEnv
    {
        public static string ConnectionString
        {
            get { return GetAppSetting("ConnectionString"); }
        }


        public static SqlConnection GetConnection
        {
            get { return new SqlConnection(ConnectionString); }
        }

        public static string GetAppSetting(string key)
        {
            if (ConfigurationManager.AppSettings[key] != null) return ConfigurationManager.AppSettings[key];
            else return null;
        }

        public static bool WebsiteEnable
        {
            get { return Convert.ToBoolean(GetAppSetting("Website_Enable")); }
        }

        public static string GetAppSetting(string key, string configFileName)
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(HttpContext.Current.Server.MapPath(configFileName));
            XmlNode node = xd.DocumentElement.SelectSingleNode("/configuration/appSettings/add[@key=\"" + key + "\"]");
            if (node != null) return node.Attributes.GetNamedItem("value").Value;
            else return null;
        }

        public static string AdvInZone
        {
            get { return GetAppSetting("AdvInZone"); }
        }

        public static int ZoneSelected
        {
            get
            {
                if (HttpContext.Current.Session["ZoneSelected"] != null)
                    return (int)HttpContext.Current.Session["ZoneSelected"];
                else return 0;
            }
            set { HttpContext.Current.Session["ZoneSelected"] = value; }
        }

        public enum CMSRole
        {
            Manager = 2,
            Deployer = 1,
            Creater = 0,
        }

        public enum CMSWorkFlow
        {
            Archive = 1,
            Waiting = 2,
            Return = 3,
            Deploy = 4
        }

        public enum CMSContentRank
        {
            Default = 0,
            Focus = 1,
            Special = 2
        }

        public const string ADMIN_PATH = "/acp/";

        public const string ADMIN_CMD = "/acp/?cmd=";
        public const string ADMIN_EMAIL = "admin@idk.vn";
        public const string WEB_CMD = "/?tab=";
        public const string MODULE_PATH = "/acp/Usercontrols/Modules/";

        public const string ADMIN_ACCESSDENY = ADMIN_CMD + "accessdeny";

        private const string Main_LangCookieName = "Main.LangCookieName";
        private const string Main_FrontEndLangCookieName = "Main.FrontEndLangCookieName";
        private const string Main_WebTitle = "Main.WebTitle";
        private const string Main_MailServer = "Main.MailServer";
        private const string Main_MailServerPort = "Main.MailServerPort";
        private const string Main_MailUsername = "Main.MailUsername";
        private const string Main_MailPassword = "Main.MailPassword";
        private const string Main_ContactEmail = "Main.ContactEmail";
        private const string Main_DefaultCacheExpire = "Main.DefaultCacheExpire";
        private const string Main_MetaSearch = "Main.MetaSearch";
        private const string Main_MetaDescription = "Main.MetaDescription";
        private const string Download_Brochure = "Download.Brochure";
        private const string Background_Music = "Background.Music";
        private const string Hot_Line = "Hot.Line";
        private const string Yahoo_ID1 = "Yahoo.ID1";
        private const string Yahoo_ID2 = "Yahoo.ID2";
        public const string WEB_PATH = "/";

        public const string CMS_ZoneHome = "CMS.ZoneHome";
        public const string CMS_ZoneHomeFocus = "CMS.ZoneHomeFocus";
        public const string CMS_ZoneClassRegister = "CMS.ZoneClassRegister";
        public const string CMS_ZoneKhoaHoc = "CMS.ZoneKhoaHoc";
        public const string MSG_Deploy = "<font color='blue'>Bài đã được đăng trên mục </font> ";
        public const string MSG_Waiting = "<font color='blue'>Bài đang chờ đăng trên mục </font> ";
        public const string MSG_Return = "<font color='blue'>Bài đã được trả lại mục</font> ";
        public const string MSG_Archive = "<font color='blue'>Bài đã được lưu trữ trong mục</font> ";

        public const string UploadImagesOriginalDir = "/Upload/Images/Original/";
        public const string UploadImagesNormalDir = "/Upload/Images/Normal/";
        public const string UploadImagesThumbDir = "/Upload/Images/Thumb/";

        public const string UploadDocument = "/Upload/Download/";

        public const string UploadAdvertise = "/Upload/Advertise/";

        public const string ThumbWidth = "200";
        public const string ThumbHeight = "0";
        public const string NormalWidth = "500";
        public const string NormalHeight = "0";
        public const string VideoWidth = "320";
        public const string VideoHeight = "260";

        public const int ImageMaxSize = 5000000;

        public const int FlashMaxSize = 5000000;

        public const int MediahMaxSize = 5000000;


        private static DataCaching dataCaching = new DataCaching();

        public static double DefaultCacheExpire
        {
            get { return ConvertUtility.ToDouble(SettingDB.GetValue(Main_DefaultCacheExpire)); }
            set
            {
                SettingDB.SetValue(Main_DefaultCacheExpire, value.ToString());
                dataCaching.RemoveCache(Main_DefaultCacheExpire);
            }
        }

        public static string WebTitle
        {
            get { return SettingDB.GetValue(Main_WebTitle); }
            set
            {
                SettingDB.SetValue(Main_WebTitle, value);
                dataCaching.RemoveCache(Main_WebTitle);
            }
        }

        public static string MailServer
        {
            get { return SettingDB.GetValue(Main_MailServer); }
            set
            {
                SettingDB.SetValue(Main_MailServer, value);
                dataCaching.RemoveCache(Main_MailServer);
            }
        }

        public static string MailServerPort
        {
            get { return SettingDB.GetValue(Main_MailServerPort); }
            set
            {
                SettingDB.SetValue(Main_MailServerPort, value);
                dataCaching.RemoveCache(Main_MailServerPort);
            }
        }

        public static string MailUsername
        {
            get { return SettingDB.GetValue(Main_MailUsername); }
            set
            {
                SettingDB.SetValue(Main_MailUsername, value);
                dataCaching.RemoveCache(Main_MailUsername);
            }
        }

        public static string MailPassword
        {
            get { return SettingDB.GetValue(Main_MailPassword); }
            set
            {
                SettingDB.SetValue(Main_MailPassword, value);
                dataCaching.RemoveCache(Main_MailPassword);
            }
        }

        public static string ContactEmail
        {
            get { return SettingDB.GetValue(Main_ContactEmail); }
            set
            {
                SettingDB.SetValue(Main_ContactEmail, value);
                dataCaching.RemoveCache(Main_ContactEmail);
            }
        }

        public static string MetaSearch
        {
            get { return SettingDB.GetValue(Main_MetaSearch); }
            set
            {
                SettingDB.SetValue(Main_MetaSearch, value);
                dataCaching.RemoveCache(Main_MetaSearch);
            }
        }

        public static string MetaDescription
        {
            get { return SettingDB.GetValue(Main_MetaDescription); }
            set
            {
                SettingDB.SetValue(Main_MetaDescription, value);
                dataCaching.RemoveCache(Main_MetaDescription);
            }
        }

        public static string DownloadBrochure
        {
            get { return SettingDB.GetValue(Download_Brochure); }
            set
            {
                SettingDB.SetValue(Download_Brochure, value);
                dataCaching.RemoveCache(Download_Brochure);
            }
        }

        public static string BackgroundMusic
        {
            get { return SettingDB.GetValue(Background_Music); }
            set
            {
                SettingDB.SetValue(Background_Music, value);
                dataCaching.RemoveCache(Background_Music);
            }
        }

        public static string HotLine
        {
            get { return SettingDB.GetValue(Hot_Line); }
            set
            {
                SettingDB.SetValue(Hot_Line, value);
                dataCaching.RemoveCache(Hot_Line);
            }
        }

        public static string YahooID1
        {
            get { return SettingDB.GetValue(Yahoo_ID1); }
            set
            {
                SettingDB.SetValue(Yahoo_ID1, value);
                dataCaching.RemoveCache(Yahoo_ID1);
            }
        }

        public static string YahooID2
        {
            get { return SettingDB.GetValue(Yahoo_ID2); }
            set
            {
                SettingDB.SetValue(Yahoo_ID2, value);
                dataCaching.RemoveCache(Yahoo_ID2);
            }
        }

        public static void SetLanguage(string cultureCode)
        {
            var context = HttpContext.Current;
            var cookieLang = new HttpCookie(Main_LangCookieName, cultureCode) {Expires = DateTime.Now.AddYears(100)};
            context.Response.Cookies.Add(cookieLang);
        }

        public static void SetLanguageFrontEnd(string cultureCode)
        {
            var context = HttpContext.Current;
            var cookieLang = new HttpCookie(Main_FrontEndLangCookieName, cultureCode) { Expires = DateTime.Now.AddYears(100) };
            context.Response.Cookies.Add(cookieLang);
        }

        public static string GetLanguage()
        {
            string strOutput;

            if (HttpContext.Current.Request.Cookies[Main_LangCookieName] != null)
            {
                if (HttpContext.Current.Request.Cookies[Main_LangCookieName].Value != string.Empty)
                    strOutput = HttpContext.Current.Request.Cookies[Main_LangCookieName].Value;
                else
                {
                    SetLanguage(GetDefaultLanguage());
                    strOutput = GetDefaultLanguage();
                }
            }
            else
            {
                SetLanguage(GetDefaultLanguage());
                strOutput = GetDefaultLanguage();
            }
            return strOutput;
        }

        public static string GetLanguageFrontEnd()
        {
            string strOutput;

            if (HttpContext.Current.Request.Cookies[Main_FrontEndLangCookieName] != null)
            {
                if (HttpContext.Current.Request.Cookies[Main_FrontEndLangCookieName].Value != string.Empty)
                    strOutput = HttpContext.Current.Request.Cookies[Main_FrontEndLangCookieName].Value;
                else
                {
                    SetLanguageFrontEnd(GetDefaultLanguage());
                    strOutput = GetDefaultLanguage();
                }
            }
            else
            {
                SetLanguageFrontEnd(GetDefaultLanguage());
                strOutput = GetDefaultLanguage();
            }
            return strOutput;
        }

        public static string GetDefaultLanguage()
        {
            string strLanguage;
            if (ConfigurationManager.AppSettings["Default_Language"] != null)
                strLanguage = GetAppSetting("Default_Language");
            else
                strLanguage = "vi-VN";
            return strLanguage;
        }

        public static string NoticeAdd(string lang, bool succ)
        {
            if (succ)
            {
                return (lang == "vi-VN" ? "Thêm mới thành công !" : "Add successfully !");
            }
            else
            {
                return (lang == "vi-VN" ? "Thêm mới không thành công !" : "Add not successfully !");
            }
        }

        public static string NoticeEdit(string lang, bool succ)
        {

            if (succ)
            {
                return (lang == "vi-VN" ? "Cập nhật thành công !" : "Edit successfully !");
            }
            else
            {
                return (lang == "vi-VN" ? "Cập nhật không thành công !" : "Edit not successfully !");
            }
        }

        public static string NoticeDelete(string lang, bool succ)
        {

            if (succ)
            {
                return (lang == "vi-VN" ? "Xóa thành công !" : "Delete successfully !");
            }
            else
            {
                return (lang == "vi-VN" ? "Xóa không thành công !" : "Delete not successfully !");
            }
        }

        public static string NoticeRequired(string lang, string content)
        {
            return ((lang == "vi-VN" ? "Vui lòng nhập " : "Please, you enter ") + content + " !");
        }

        public static string GetConfirm(string lang)
        {

            return (lang == "vi-VN" ? "Ban quyet dinh hanh dong xoa !" : "Do you sure to delete !");

        }

        public static string NoticeInvalid(string lang, string content)
        {

            return (content + (lang == "vi-VN" ? " không hợp lệ !" : " is invalid !"));

        }

        
        
       
    }
}