using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.Project
{
    public partial class MamNon_List : System.Web.UI.UserControl
    {
        private int _zoneCurrent;
        private const int _excludeSpecial = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            _zoneCurrent = ZoneUtility.GetZoneCurrent();

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

                var litName = (Literal)e.Item.FindControl("litName");
                var litContent = (Literal)e.Item.FindControl("litContent");
                var rptDocument = (Repeater)e.Item.FindControl("rptDocument");

                litName.Text = curData["Content_Name"].ToString();
                litContent.Text = curData["Content_Body"].ToString();

                var strSQL = "SELECT CMS_ContentDownload.*, CMS_Download.* FROM CMS_ContentDownload ";
                strSQL += " INNER JOIN CMS_Download ON CMS_ContentDownload.Download_ID = CMS_Download.Download_ID ";
                strSQL += " WHERE 1=1 ";
                strSQL += " AND CMS_Download.Download_Visible=1 ";
                strSQL += " AND CMS_ContentDownload.Content_ID=" + curData["Content_ID"] + " ";

                strSQL += " ORDER BY CMS_ContentDownload.Priority ASC ";

                var source = DataHelper.GetDataFromTable(strSQL);

                rptDocument.DataSource = source;
                rptDocument.DataBind();
            }
        }

        protected void rptDocument_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var curData = (DataRowView)e.Item.DataItem;

                var lnkDownload = (HyperLink)e.Item.FindControl("lnkDownload");

                var url = "http://" + Request.Url.Host + curData["Download_File"];
                lnkDownload.NavigateUrl = url;
            }
        }
    }
}