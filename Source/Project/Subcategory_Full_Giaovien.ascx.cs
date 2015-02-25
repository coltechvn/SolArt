using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.Project
{
    public partial class Subcategory_Full_Giaovien : System.Web.UI.UserControl
    {
        private int _zonecurrent;

        protected void Page_Load(object sender, EventArgs e)
        {
            _zonecurrent = ZoneUtility.GetZoneCurrent();
            var source = ZoneDB.GetByParentID(_zonecurrent);
            
            var zoneInfo = ZoneDB.GetInfo(_zonecurrent);

            if (zoneInfo != null)
            {
                litZoneName.Text = zoneInfo.Zone_Name;

                if (source.Rows.Count == 0)
                {
                    pntSub.Visible = false;
                    
                    var listStyle = zoneInfo.Zone_ContentListingDisplay;
                    if (listStyle == "one")
                    {
                        PlaceHolder1.Controls.Add(Page.LoadControl("UserControls/NewsFocus.ascx"));
                    }
                    else
                    {
                        PlaceHolder1.Controls.Add(Page.LoadControl("Project/GiaoVienList.ascx"));
                    }

                }
                else
                {
                    rptData.DataSource = source;
                    rptData.DataBind();
                }
            }
            else
            {
                Response.Redirect("/");
            }
        }

        protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var curData = (DataRowView)e.Item.DataItem;
                var lnkName = (HyperLink)e.Item.FindControl("lnkName");
                var litDescription = (Literal)e.Item.FindControl("litDescription");
                var imgAvatar = (Image)e.Item.FindControl("imgAvatar");

                if (curData["Zone_ID"].ToString() == _zonecurrent.ToString()) lnkName.Font.Underline = true;

                litDescription.Text = curData["Zone_Description"].ToString().Replace("\n", "<br />");

                var avatar = curData["Zone_Avatar"].ToString();
                if (avatar.Length > 0)
                {
                    imgAvatar.ImageUrl = UrlFilter.BuildImageUrl(avatar, 200, 0);
                }
                else
                {
                    imgAvatar.Visible = false;
                }

                lnkName.Text = curData["Zone_Name"].ToString();
                if (curData["Zone_RealUrl"].ToString().Length > 0)
                    lnkName.NavigateUrl = curData["Zone_RealUrl"].ToString();
                else
                    lnkName.NavigateUrl = UrlFilter.BuildUrlByZoneID(ConvertUtility.ToInt32(curData["Zone_ID"]));
            }
        }
    }
}