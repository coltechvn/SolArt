using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.UserControls
{
    public partial class SpecialInZone : System.Web.UI.UserControl
    {
        private int _zonecurrent;
        protected void Page_Load(object sender, EventArgs e)
        {
            _zonecurrent = ZoneUtility.GetZoneCurrent();
            var dtData = DistributionDB.GetContentByZoneAndRankInZone(_zonecurrent, true, 0, (int)AppEnv.CMSContentRank.Special , 1 );
            if (dtData.Rows.Count > 0)
            {
                rptData.DataSource = dtData;
                rptData.DataBind();
            }
            else
            {
                Visible = false;
            }
        }

        protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var curData = (DataRowView)e.Item.DataItem;
                var lnkName = (HyperLink)e.Item.FindControl("lnkName");
                var lnkAvatar = (HyperLink)e.Item.FindControl("lnkAvatar");
                var imgAvatar = (Image)e.Item.FindControl("imgAvatar");
                var litTeaser = (Literal)e.Item.FindControl("litTeaser");

                var distid = ConvertUtility.ToInt32(curData["Distribution_ID"]);

                lnkName.Text = curData["Content_Name"].ToString();
                lnkName.NavigateUrl = lnkAvatar.NavigateUrl = UrlFilter.BuildUrlByItemID(distid);

                litTeaser.Text = curData["Content_Teaser"].ToString();

                var coverInfo = ImageDB.GetCover(ConvertUtility.ToInt32(curData["Content_ID"]));
                if (coverInfo != null)
                {
                    string avatar = coverInfo.Image_File;
                    if (avatar.Length > 0)
                    {
                        imgAvatar.ImageUrl = UrlFilter.BuildImageUrl(MultimediaUtility.GetOriginalImage(avatar), 224, 0);
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

                SessionUtility.Remove("excludeid");

                SessionUtility.SetValue("excludeid", distid.ToString());
            }
        }
    }
}