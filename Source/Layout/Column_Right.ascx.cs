using System;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.Layout
{
    public partial class Column_Right : System.Web.UI.UserControl
    {
        private int _zonecurrent;
        protected void Page_Load(object sender, EventArgs e)
        {
            _zonecurrent = ZoneUtility.GetZoneCurrent();

            var zoneLayout = ZoneDB.GetZoneLayout(_zonecurrent);
            if (zoneLayout.Length > 0)
            {
                switch (zoneLayout)
                {
                    case "Layout_Zone_ClassRegister":
                        break;
                    case "Layout_Zone_Khoahoc":
                    case "Layout_Zone_Mamnon":
                        TuyenSinh_Home1.Visible = true;
                        Search_Khoahoc1.Visible = true;
                        Subcategory_2level1.Visible = true;
                        News_Sub1.Visible = true;
                        break;
                    case "Layout_Zone_Contact":
                        TuyenSinh_Home1.Visible = true;
                        CamNhan_Sub1.Visible = true;
                        break;
                    default:
                        TuyenSinh_Home1.Visible = true;
                        CamNhan_Sub1.Visible = true;
                        Music_Home1.Visible = true;
                        Video_RightSub1.Visible = true;
                        break;

                }
            }
        }
    }
}