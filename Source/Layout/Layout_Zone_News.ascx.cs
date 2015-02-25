using System;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.Layout
{
    public partial class Layout_Zone_News : System.Web.UI.UserControl
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
                var listStyle = zoneInfo.Zone_ContentListingDisplay;
                if (listStyle == "one")
                {
                    SpecialInZone1.Visible = false;
                    PlaceHolder1.Controls.Add(Page.LoadControl("UserControls/NewsFocus.ascx"));
                }
                else
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("UserControls/NewsList.ascx"));
                }
            }
            else
            {
                Response.Redirect("/");
            }
        }
    }
}