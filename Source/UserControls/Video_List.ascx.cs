using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;


namespace iDKCMS.FrontEnd.UserControls
{
    public partial class Video_List : System.Web.UI.UserControl
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

            var strSQL = "SELECT CMS_ContentVideo.*, CMS_Videos.* FROM CMS_ContentVideo ";
            strSQL += " INNER JOIN CMS_Videos ON CMS_ContentVideo.Video_ID = CMS_Videos.Video_ID ";
            strSQL += " WHERE 1=1 ";

            strSQL += " AND CMS_ContentVideo.Content_ID=" + _contentId + " ";
            strSQL += " AND CMS_Videos.Video_Visible=1 ";
            strSQL += " ORDER BY CMS_ContentVideo.Priority ASC ";

            var source = DataHelper.GetDataFromTable(strSQL);

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
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var curData = (DataRowView)e.Item.DataItem;
                var litPlayer = (Literal)e.Item.FindControl("litPlayer");
                var liAvatar = (HtmlGenericControl)e.Item.FindControl("liAvatar");
                var litDescription = (Literal)e.Item.FindControl("litDescription");

                var file = curData["Video_File"].ToString();
                var youtube = curData["Video_Youtube"].ToString();

                if(file.Length == 0 && youtube.Length == 0)
                {
                    liAvatar.Visible = false;
                }
                else
                {
                    litDescription.Text = curData["Video_Description"].ToString().Replace("\n", "<br />");
                    var type = curData["Video_Type"].ToString();

                    switch (type)
                    {
                        case "flash":
                            litPlayer.Text = MultimediaUtility.ShowFlashAdv("player" + curData["Video_ID"], curData["Video_File"].ToString(), 560, 315);
                            break;
                        case "youtube":
                            litPlayer.Text = MultimediaUtility.ShowYouTuBeAdv(curData["Video_Youtube"].ToString(), 560, 315);
                            break;
                        default:
                            litPlayer.Text = MultimediaUtility.strInitMultimedia(curData["Video_File"].ToString(), 560, 315);
                            break;
                    }   
                }

                
            }
        }
    }
}