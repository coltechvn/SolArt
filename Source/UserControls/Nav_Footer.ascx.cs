using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.UserControls
{
    public partial class Nav_Footer : System.Web.UI.UserControl
    {
        private int _zoneCurrent;
        private int _zoneHome;

        protected void Page_Load(object sender, EventArgs e)
        {
            _zoneCurrent = ZoneUtility.GetZoneCurrent();

            _zoneHome = ConvertUtility.ToInt32(SettingDB.GetValue(AppEnv.CMS_ZoneHome + AppEnv.GetLanguageFrontEnd()));

            rptData.DataSource = ZoneDB.GetZoneVisbleInFooterNav();
            rptData.DataBind();

        }

        protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var curData = (DataRowView)e.Item.DataItem;
                var lnkZone = (HyperLink)e.Item.FindControl("lnkZone");

                if (curData["Zone_ID"].ToString() == _zoneCurrent.ToString()) lnkZone.CssClass = "selected";

                if (_zoneCurrent == 0)
                {
                    if (curData["Zone_ID"].ToString() == _zoneHome.ToString()) lnkZone.CssClass = "selected";
                }

                if (curData["Zone_RealUrl"].ToString().Length > 0)
                    lnkZone.NavigateUrl = curData["Zone_RealUrl"].ToString();
                else
                    lnkZone.NavigateUrl = UrlFilter.BuildUrlByZoneID(ConvertUtility.ToInt32(curData["Zone_ID"]));

                lnkZone.Text = curData["Zone_Name"].ToString();

                
            }
        }
    }
}