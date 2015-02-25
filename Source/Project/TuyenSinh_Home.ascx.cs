using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.Project
{
    public partial class TuyenSinh_Home : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            const string boxtname = "tuyensinhhome";
            var zoneid = ConvertUtility.ToInt32(ZoneDB.GetIDByFriendlyUrl(boxtname));

            if (zoneid <= 0) return;
            var info = ZoneDB.GetInfo(zoneid);
            if (info == null) return;

            lnkOther.NavigateUrl = UrlFilter.BuildUrlByZoneID(info.Zone_ParentID);

            string lang = AppEnv.GetLanguageFrontEnd();

            var zoneClassRegister = ConvertUtility.ToInt32(SettingDB.GetValue(AppEnv.CMS_ZoneClassRegister + lang));

            lnkRegister.NavigateUrl = UrlFilter.BuildUrlByZoneID(zoneClassRegister);

            var dtData = DistributionDB.GetContentByZoneIDselfAndNumberRecord(zoneid, 10);
            if (dtData.Rows.Count <= 0) return;

            rptData.DataSource = dtData;
            rptData.DataBind();
        }

        protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var curData = (DataRowView)e.Item.DataItem;
                var lnkName = (HyperLink)e.Item.FindControl("lnkName");

                lnkName.Text = curData["Content_Name"].ToString();
                lnkName.NavigateUrl = UrlFilter.BuildUrlByItemID(ConvertUtility.ToInt32(DistributionDB.GetOriginalDistID(ConvertUtility.ToInt32(curData["Distribution_ContentID"]))));
            }
        }
    }
}