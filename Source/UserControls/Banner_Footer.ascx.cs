using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.UserControls
{
    public partial class Banner_Footer : System.Web.UI.UserControl
    {
        private int _zonecurrent;

        protected void Page_Load(object sender, EventArgs e)
        {
            const string position = "network";
            _zonecurrent = ZoneUtility.GetZoneCurrent();

            var positionid = ConvertUtility.ToInt32(PositionDB.GetIDByPosition(position));

            var source = AdvertiseDB.GetAvailables(positionid, _zonecurrent); //AdvertiseDB.GetLimitedAvailables(positionid, zonecurrent, 8);

            if (source.Rows.Count <= 0) return;

            rptData.DataSource = source;
            rptData.DataBind();
        }

        protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var curData = (DataRowView)e.Item.DataItem;

                var litAdv = (Literal)e.Item.FindControl("litAdv");

                var advType = curData["Advertise_Type"].ToString();
                var width = ConvertUtility.ToInt32(curData["Advertise_Width"]);
                var height = ConvertUtility.ToInt32(curData["Advertise_Height"]);
                var path = curData["Advertise_Path"].ToString();
                //string url = curData["Advertise_RedirectURL"].ToString();
                const string target = "_blank";

                switch (advType)
                {
                    case "flash":
                        litAdv.Text = MultimediaUtility.strInitFlash(path, width, height);
                        break;
                    case "media":
                        litAdv.Text = MultimediaUtility.strInitMultimedia(path, width, height);
                        break;
                    case "flv":
                        litAdv.Text =
                            MultimediaUtility.ShowFlashAdv(curData["Advertise_ID"].ToString(), path, width, height);
                        break;
                    case "embed":
                        litAdv.Text = MultimediaUtility.ShowYouTuBeAdv(curData["Advertise_Embed"].ToString(), width, height);
                        break;
                    default:
                        litAdv.Text =
                            MultimediaUtility.strInitImage(path, width, height,
                                                           ConvertUtility.ToInt32(curData["Advertise_ID"]), target);
                        break;
                }
            }
        }
    }
}