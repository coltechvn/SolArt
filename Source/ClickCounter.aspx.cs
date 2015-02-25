using System;
using System.Web.UI;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd
{
    public partial class ClickCounter : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            int id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            AdvertiseInfo info = AdvertiseDB.GetInfo(id);
            if (info == null)
            {
                ClientScript.RegisterStartupScript(typeof(Page), "Close", "<script>javascript:window.close()</script>");
                return;
            }
            else
            {
                if (info.Advertise_RedirectURL == string.Empty)
                    ClientScript.RegisterStartupScript(typeof(Page), "Close", "<script>javascript:window.close()</script>");
                else
                {
                    AdvertiseDB.Clicks(info.Advertise_ID, 1);
                    Response.Redirect(info.Advertise_RedirectURL);
                }
            }
        }
    }
}