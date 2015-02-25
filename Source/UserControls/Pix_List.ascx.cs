using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.UserControls
{
    public partial class Pix_List : System.Web.UI.UserControl
    {
        private int _zoneCurrent;
        private int _itemid;
        private int _contentId;
        private DistributionInfo _distInfo;

        protected void Page_Load(object sender, EventArgs e)
        {
            _zoneCurrent = ZoneUtility.GetZoneCurrent();

            _itemid = ConvertUtility.ToInt32(Request.QueryString["itemid"]);

            _distInfo = DistributionDB.GetInfo(_itemid);
            if (_distInfo == null)
            {
                Visible = false;
                return;
            }

            DistributionDB.UpdateView(_distInfo.Distribution_ID, 1);

            _contentId = _distInfo.Distribution_ContentID;

            var contentInfo = ContentDB.GetInfo(_contentId);

            lnkName.Text = contentInfo.Content_Name;
            lnkName.NavigateUrl = UrlFilter.BuildUrlByItemID(_itemid);

            

            lnkZone.Text = ZoneDB.GetZoneNameByID(_zoneCurrent);
            lnkZone.NavigateUrl = UrlFilter.BuildUrlByZoneID(_zoneCurrent);

            var strSQL = "SELECT CMS_ContentImage.*, CMS_Images.* FROM CMS_ContentImage ";
            strSQL += " INNER JOIN CMS_Images ON CMS_ContentImage.Image_ID = CMS_Images.Image_ID ";
            strSQL += " WHERE 1=1 ";

            strSQL += " AND CMS_ContentImage.Content_ID=" + _contentId + " ";
            strSQL += " AND CMS_Images.Image_Visible=1 ";
            strSQL += " ORDER BY CMS_ContentImage.Priority ASC ";

            var source = DataHelper.GetDataFromTable(strSQL);

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

                var imgAvatar = (Image)e.Item.FindControl("imgAvatar");
                var lnkAvatar = (HyperLink)e.Item.FindControl("lnkAvatar");
                var liAvatar = (HtmlGenericControl)e.Item.FindControl("liAvatar");

                string avatar = ConvertUtility.ToString(curData["Image_File"]);
                if (string.IsNullOrEmpty(avatar))
                {
                    liAvatar.Visible = false;
                }
                else
                {
                    imgAvatar.ImageUrl = UrlFilter.BuildImageUrl(avatar, 150, 0);
                    lnkAvatar.NavigateUrl = MultimediaUtility.GetOriginalImage(avatar);
                    lnkAvatar.Attributes.Add("rel", "prettyPhoto[pp_gal]"); //lnkAvatar.Attributes.Add("rel", "prettyPhoto");
                    lnkAvatar.ToolTip = curData["Image_Description"].ToString();
                }
            }
        }
    }
}