using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.UserControls
{
    public partial class SubCategory : System.Web.UI.UserControl
    {
        private int zoneCurrent;

        protected void Page_Load(object sender, EventArgs e)
        {
            zoneCurrent = ZoneUtility.GetZoneCurrent();
            var source = ZoneDB.GetByParentID(zoneCurrent);
            if (source.Rows.Count == 0)
            {
                var zoneparent = ZoneDB.GetParentID(zoneCurrent);
                if(zoneparent != 0)
                {
                    source = ZoneDB.GetByParentID(zoneparent);
                }
            }
            rptData.DataSource = source;
            rptData.DataBind();
        }

        protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var curData = (DataRowView)e.Item.DataItem;
                var lnkZone = (HyperLink)e.Item.FindControl("lnkZone");

                if (curData["Zone_ID"].ToString() == zoneCurrent.ToString()) lnkZone.Font.Underline = true;

                lnkZone.Text = curData["Zone_Name"].ToString();
                if (curData["Zone_RealUrl"].ToString().Length > 0)
                    lnkZone.NavigateUrl = curData["Zone_RealUrl"].ToString();
                else
                    lnkZone.NavigateUrl = UrlFilter.BuildUrlByZoneID(ConvertUtility.ToInt32(curData["Zone_ID"]));
            }
        }
    }
}