using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.Project
{
    public partial class CamNhan_Home : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            const string boxtname = "camnhanhome";
            var zoneid = ConvertUtility.ToInt32(ZoneDB.GetIDByFriendlyUrl(boxtname));

            if (zoneid <= 0) return;
            var info = ZoneDB.GetInfo(zoneid);
            if (info == null) return;

            
            var realUrl = info.Zone_RealUrl;
            if (realUrl.Length > 0)
            {
                lnkZone.NavigateUrl = realUrl;
            }
            else
                lnkZone.NavigateUrl = UrlFilter.BuildUrlByZoneID(info.Zone_ParentID);

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
                var litName = (Literal)e.Item.FindControl("litName");
                var litTeaser = (Literal)e.Item.FindControl("litTeaser");
                var litDatetime = (Literal)e.Item.FindControl("litDatetime");
                var imgAvatar = (Image)e.Item.FindControl("imgAvatar");

                litName.Text = curData["Content_Name"].ToString();
                litTeaser.Text = curData["Content_Teaser"].ToString();

                litDatetime.Text = ConvertUtility.ToDateTime(curData["Distribution_CreateDate"]).ToString("dd MMMM yyyy");

                var coverInfo = ImageDB.GetCover(ConvertUtility.ToInt32(curData["Content_ID"]));
                if (coverInfo != null)
                {
                    var avatar = coverInfo.Image_File;
                    if (avatar.Length > 0)
                    {
                        imgAvatar.ImageUrl = UrlFilter.BuildImageScaleHeight(avatar, 0, 50);
                    }
                    else
                    {
                        imgAvatar.Visible = false;
                    }
                }
                else
                {
                    imgAvatar.Visible = false;
                }
            }
        }
    }
}