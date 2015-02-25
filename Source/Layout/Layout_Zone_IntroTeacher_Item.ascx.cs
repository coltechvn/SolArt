using System;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.Layout
{
    public partial class Layout_Zone_IntroTeacher_Item : System.Web.UI.UserControl
    {
        private int _zonecurrent;

        protected void Page_Load(object sender, EventArgs e)
        {
            _zonecurrent = ZoneUtility.GetZoneCurrent();

            litZoneName.Text = ZoneDB.GetZoneNameByID(_zonecurrent);

        }
    }
}