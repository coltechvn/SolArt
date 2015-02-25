using System;
using System.Data;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.UserControls
{
    public partial class NewsFocus : System.Web.UI.UserControl
    {
        private int _zoneCurrent;
        protected void Page_Load(object sender, EventArgs e)
        {
            _zoneCurrent = ZoneUtility.GetZoneCurrent();

            //lnkZone.Text = ZoneDB.GetZoneNameByID(zoneCurrent);
            //lnkZone.NavigateUrl = ZoneUtility.BuildUrlByZoneCurrent(zoneCurrent);

            DataTable dtSpecial = DistributionDB.GetContentByZoneIDAndRank(_zoneCurrent, 1, (int)AppEnv.CMSContentRank.Special);
            if (dtSpecial.Rows.Count > 0)
            {
                int contentID = Convert.ToInt32(dtSpecial.Rows[0]["Content_ID"]);
                //litName.Text = dtSpecial.Rows[0]["Content_Name"].ToString();
                litContent.Text = ContentDB.GetInfo(contentID).Content_Body;
            }
        }
    }
}