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
    public partial class Layout_Zone_Khoahoc : System.Web.UI.UserControl
    {
        private int _zonecurrent;

        protected void Page_Load(object sender, EventArgs e)
        {
            _zonecurrent = ZoneUtility.GetZoneCurrent();
            lnkZone.Text = ZoneDB.GetZoneNameByID(_zonecurrent);
            lnkZone.NavigateUrl = UrlFilter.BuildUrlByZoneID(_zonecurrent);

            var source = ZoneDB.GetByParentID(_zonecurrent);
            if (source.Rows.Count > 0)
            {
                Subcategory_Full_2level1.Visible = true;
                KhoaHoc_List1.Visible = false;
                Subcategory_2level_Center1.Visible = true;
            }
            else
            {
                Subcategory_Full_2level1.Visible = false;
                KhoaHoc_List1.Visible = true;
                Subcategory_2level_Center1.Visible = false;
            }
        }
    }
}