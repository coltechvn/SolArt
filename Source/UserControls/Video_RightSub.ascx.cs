using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.UserControls
{
    public partial class Video_RightSub : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            const string boxtname = "subvideo";
            var zoneid = ConvertUtility.ToInt32(ZoneDB.GetIDByFriendlyUrl(boxtname));

            if (zoneid <= 0) return;
            var info = ZoneDB.GetInfo(zoneid);
            if (info == null) return;

            lnkName.Text = info.Zone_Name;

            var realUrl = (info.Zone_RealUrl);
            if (realUrl.Length > 0)
            {
                lnkName.NavigateUrl = realUrl;
            }
            else
            {
                lnkName.NavigateUrl = UrlFilter.BuildUrlByZoneID(info.Zone_ParentID);
            }

            var dtSpecial = DistributionDB.GetContentRandomByZoneIDselfAndNumberRecord(zoneid, 1);
            if (dtSpecial.Rows.Count > 0)
            {
                rptSpecial.DataSource = dtSpecial;
                rptSpecial.DataBind();
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