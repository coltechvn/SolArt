using System;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.Layout
{
    public partial class Zone : System.Web.UI.UserControl
    {
        private int _zonecurrent;
        protected void Page_Load(object sender, EventArgs e)
        {
            _zonecurrent = ZoneUtility.GetZoneCurrent();

            var zoneLayout = ZoneDB.GetZoneLayout(_zonecurrent);
            if (zoneLayout.Length > 0)
            {
                PlaceHolder1.Controls.Add(Page.LoadControl("Layout/" + zoneLayout + ".ascx"));
            }
            else
            {
                Response.Redirect("/");
            }
        }
    }
}