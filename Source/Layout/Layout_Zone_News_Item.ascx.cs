using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.Layout
{
    public partial class Layout_Zone_News_Item : System.Web.UI.UserControl
    {
        private int _zonecurrent;

        protected void Page_Load(object sender, EventArgs e)
        {
            _zonecurrent = ZoneUtility.GetZoneCurrent();

            var zoneInfo = ZoneDB.GetInfo(_zonecurrent);
            if (zoneInfo != null)
            {
                lnkZone.Text = zoneInfo.Zone_Name;
                lnkZone.NavigateUrl = UrlFilter.BuildUrlByZoneID(_zonecurrent);
            }
            else
            {
                Response.Redirect("/");
            }
        }
    }
}