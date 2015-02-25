using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.UserControls
{
    public partial class Album_List : System.Web.UI.UserControl
    {
        private int _zoneCurrent;
        private const int _excludeSpecial = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            _zoneCurrent = ZoneUtility.GetZoneCurrent();

            lnkZone.Text = ZoneDB.GetZoneNameByID(_zoneCurrent);
            lnkZone.NavigateUrl = UrlFilter.BuildUrlByZoneID(_zoneCurrent);

            var source = DistributionDB.GetNewContentByZoneIDNoPage(_zoneCurrent, true, _excludeSpecial);

            if (source.Rows.Count > 0)
            {
                CollectionPager1.DataSource = source.DefaultView;
                CollectionPager1.BindToControl = rptData;

                if (AppEnv.GetLanguageFrontEnd() == "vi-VN")
                    CollectionPager1.LabelText = "Trang:&nbsp;";
                else
                    CollectionPager1.LabelText = "Page:&nbsp;";

                CollectionPager1.BackText = "<<";
                CollectionPager1.PageNumbersSeparator = "&nbsp;&nbsp;&nbsp;";
                CollectionPager1.BackNextLinkSeparator = "&nbsp;&nbsp;&nbsp;";

                rptData.DataSource = CollectionPager1.DataSourcePaged;
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
                var lnkAvatar = (HyperLink)e.Item.FindControl("lnkAvatar");
                var imgAvatar = (Image)e.Item.FindControl("imgAvatar");

                lnkName.Text = curData["Content_Name"].ToString();
                lnkName.NavigateUrl = lnkAvatar.NavigateUrl = UrlFilter.BuildUrlByItemID(ConvertUtility.ToInt32(curData["Distribution_ID"]));

                var coverInfo = ImageDB.GetCover(ConvertUtility.ToInt32(curData["Content_ID"]));
                if (coverInfo != null)
                {
                    string avatar = coverInfo.Image_File;
                    if (avatar.Length > 0)
                    {
                        imgAvatar.ImageUrl = UrlFilter.BuildImageUrl(avatar, 180, 0);
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