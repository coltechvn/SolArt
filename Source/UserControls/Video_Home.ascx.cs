using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.UserControls
{
    public partial class Video_Home : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            const string boxtname = "homebottomright";
            var zoneid = ConvertUtility.ToInt32(ZoneDB.GetIDByFriendlyUrl(boxtname));

            if (zoneid <= 0) return;
            var info = ZoneDB.GetInfo(zoneid);
            if (info == null) return;

            var realUrl = (info.Zone_RealUrl);
            if (realUrl.Length > 0)
            {
                lnkOther.NavigateUrl = realUrl;
            }
            else
            {
                lnkOther.NavigateUrl = UrlFilter.BuildUrlByZoneID(info.Zone_ParentID);
            }

            var dtSpecial = DistributionDB.GetContentByZoneIDAndRank(zoneid, 1, (int)AppEnv.CMSContentRank.Special);
            if (dtSpecial.Rows.Count > 0)
            {
                rptSpecial.DataSource = dtSpecial;
                rptSpecial.DataBind();
            }

            var dtData = DistributionDB.GetContentByZoneIDAndRank(zoneid, 3, (int)AppEnv.CMSContentRank.Default);
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

        protected void rptSpecial_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var curData = (DataRowView)e.Item.DataItem;
                var litPlayer = (Literal)e.Item.FindControl("litPlayer");

                var coverInfo = VideoDB.GetCover(ConvertUtility.ToInt32(curData["Content_ID"]));
                if (coverInfo != null)
                {
                    var type = coverInfo.Video_Type;

                    switch (type)
                    {
                        case "flash":
                            litPlayer.Text = MultimediaUtility.ShowFlashAdv("home", coverInfo.Video_File, 255, 158);
                            break;
                        case "youtube":
                            litPlayer.Text = MultimediaUtility.ShowYouTuBeAdv(coverInfo.Video_YouTube, 255, 158);
                            break;
                        default:
                            litPlayer.Text = MultimediaUtility.strInitMultimedia(coverInfo.Video_File, 255, 158);
                            break;
                    }
                }
            }
        }
    }
}