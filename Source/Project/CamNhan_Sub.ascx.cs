using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.Project
{
    public partial class CamNhan_Sub : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            const string boxtname = "camnhanhome";
            var zoneid = ConvertUtility.ToInt32(ZoneDB.GetIDByFriendlyUrl(boxtname));

            if (zoneid <= 0) return;
            var info = ZoneDB.GetInfo(zoneid);
            if (info == null) return;

            lnkName.Text = info.Zone_Name;

            var realUrl = info.Zone_RealUrl;
            if (realUrl.Length > 0)
            {
                lnkName.NavigateUrl = lnkMore.NavigateUrl = realUrl;
            }
            else
                lnkName.NavigateUrl = lnkMore.NavigateUrl = UrlFilter.BuildUrlByZoneID(info.Zone_ParentID);

            var dtData = DistributionDB.GetContentRandomByZoneIDselfAndNumberRecord(zoneid, 1);
            if (dtData.Rows.Count <= 0) return;

            rptData.DataSource = dtData;
            rptData.DataBind();
        }

        protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var curData = (DataRowView)e.Item.DataItem;
                var litContent = (Literal)e.Item.FindControl("litContent");

                litContent.Text = curData["Content_Teaser"].ToString().Replace("\n", "<br />");
            }
        }
    }
}