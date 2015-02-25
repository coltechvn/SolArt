using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;


namespace iDKCMS.FrontEnd.Project
{
    public partial class GiaoVienList : System.Web.UI.UserControl
    {
        private int _zoneCurrent;
        private const int _excludeSpecial = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            _zoneCurrent = ZoneUtility.GetZoneCurrent();
            //_excludeSpecial = ConvertUtility.ToInt32(CookieUtility.GetCookie("exclueSpecialInZone" + _zoneCurrent));

            var source = DistributionDB.GetNewContentByZoneIDNoPage(_zoneCurrent, true, _excludeSpecial);

            if (source.Rows.Count > 0)
            {
                rptData.DataSource = source;
                rptData.DataBind();
            }
            else
            {
                rptData.Visible = false;
            }
        }

        protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var curData = (DataRowView)e.Item.DataItem;

                var lnkName = (HyperLink)e.Item.FindControl("lnkName");
                var litTeaser = (Literal)e.Item.FindControl("litTeaser");
                //var lnkAvatar = (HyperLink)e.Item.FindControl("lnkAvatar");
                var imgAvatar = (Image)e.Item.FindControl("imgAvatar");

                lnkName.Text = curData["Content_Name"].ToString();
                lnkName.NavigateUrl = UrlFilter.BuildUrlByItemID(ConvertUtility.ToInt32(curData["Distribution_ID"]));

                litTeaser.Text = curData["Content_Teaser"].ToString().Replace("\n", "<br />");

                var coverInfo = ImageDB.GetCover(ConvertUtility.ToInt32(curData["Content_ID"]));
                if (coverInfo != null)
                {
                    string avatar = coverInfo.Image_File;
                    if (avatar.Length > 0)
                    {
                        imgAvatar.ImageUrl = UrlFilter.BuildImageUrl(avatar, 120, 0);
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