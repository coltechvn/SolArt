﻿using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.UserControls
{
    public partial class News_Home : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            const string boxtname = "homebottomleft";
            var zoneid = ConvertUtility.ToInt32(ZoneDB.GetIDByFriendlyUrl(boxtname));

            if (zoneid <= 0) return;
            var info = ZoneDB.GetInfo(zoneid);
            if (info == null) return;

            var realUrl = (info.Zone_RealUrl);
            if(realUrl.Length > 0)
            {
                lnkOther.NavigateUrl = realUrl;
            }
            else
            {
                lnkOther.NavigateUrl = UrlFilter.BuildUrlByZoneID(info.Zone_ParentID);
            }

            var dtData = DistributionDB.GetContentByZoneIDselfAndNumberRecord(zoneid, 3);
            if (dtData.Rows.Count <= 0) return;

            rptData.DataSource = dtData;
            rptData.DataBind();
        }

        protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var curData = (DataRowView)e.Item.DataItem;
                var litDay = (Literal)e.Item.FindControl("litDay");
                var litMonth = (Literal)e.Item.FindControl("litMonth");
                var lnkName = (HyperLink)e.Item.FindControl("lnkName");

                lnkName.Text = curData["Content_Name"].ToString();
                lnkName.NavigateUrl = UrlFilter.BuildUrlByItemID(ConvertUtility.ToInt32(DistributionDB.GetOriginalDistID(ConvertUtility.ToInt32(curData["Distribution_ContentID"]))));

                litDay.Text = ConvertUtility.ToDateTime(curData["Content_EventDate"]).Day.ToString();
                litMonth.Text = ConvertUtility.ToDateTime(curData["Content_EventDate"]).Month.ToString();

            }
        }
    }
}