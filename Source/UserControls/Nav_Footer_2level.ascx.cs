using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.UserControls
{
    public partial class Nav_Footer_2level : System.Web.UI.UserControl
    {
        private int zoneCurrent;
        private int zoneHome;
            
        protected void Page_Load(object sender, EventArgs e)
        {
            zoneCurrent = ZoneUtility.GetZoneCurrent();

            zoneHome = ConvertUtility.ToInt32(SettingDB.GetValue(AppEnv.CMS_ZoneHome + AppEnv.GetLanguage()));

            rptData.DataSource = ZoneDB.GetZoneVisbleInFooterNav();
            rptData.DataBind();
        }

        protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                DataRowView curData = (DataRowView)e.Item.DataItem;
                //HyperLink lnkZone = (HyperLink)e.Item.FindControl("lnkZone");
                Literal litZone = (Literal)e.Item.FindControl("litZone");
                var rptSub2 = (Repeater)e.Item.FindControl("rptSub2");

                //if (curData["Zone_ID"].ToString() == zoneCurrent.ToString()) lnkZone.CssClass = "selected";

                //if (zoneCurrent == 0)
                //{
                //    if (curData["Zone_ID"].ToString() == zoneHome.ToString()) lnkZone.CssClass = "selected";
                //}

                //if (curData["Zone_RealUrl"].ToString().Length > 0)
                //    lnkZone.NavigateUrl = curData["Zone_RealUrl"].ToString();
                //else
                //    lnkZone.NavigateUrl = ZoneUtility.BuildUrlByZoneCurrent(ConvertUtility.ToInt32(curData["Zone_ID"]));

                litZone.Text = curData["Zone_Name"].ToString();
                //string avatar = curData["Zone_Avatar"].ToString().Trim();
                //if(avatar.Length > 0)
                //{
                //    imgAvatar.ImageUrl = avatar;
                //}
                //else
                //{
                //    imgAvatar.Visible = false;
                //    lnkZone.Text = curData["Zone_Name"].ToString();
                //}

                DataTable dtSub = ZoneDB.GetByParentID(ConvertUtility.ToInt32(curData["Zone_ID"]));

                if (dtSub.Rows.Count == 0)
                {
                    rptSub2.Visible = false;

                }
                else
                {
                    rptSub2.DataSource = dtSub;
                    rptSub2.ItemDataBound += new RepeaterItemEventHandler(rptSub2_ItemDataBound);
                    rptSub2.DataBind();
                }
            }
        }

        protected void rptSub2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                DataRowView curData = (DataRowView)e.Item.DataItem;
                HyperLink lnkSub2 = (HyperLink)e.Item.FindControl("lnkSub2");
                //Repeater rptSub3 = (Repeater)e.Item.FindControl("rptSub3");

                if (curData["Zone_ID"].ToString() == zoneCurrent.ToString()) lnkSub2.CssClass = "selected";

                if (zoneCurrent == 0)
                {
                    if (curData["Zone_ID"].ToString() == zoneHome.ToString()) lnkSub2.CssClass = "selected";
                }

                lnkSub2.Text = curData["Zone_Name"].ToString();

                if (curData["Zone_RealUrl"].ToString().Length > 0)
                    lnkSub2.NavigateUrl = curData["Zone_RealUrl"].ToString();
                else
                    lnkSub2.NavigateUrl = UrlFilter.BuildUrlByZoneID(ConvertUtility.ToInt32(curData["Zone_ID"]));

                //DataTable dtSub = ZoneDB.GetByParentID(ConvertUtility.ToInt32(curData["Zone_ID"]));

                //if (dtSub.Rows.Count == 0)
                //{
                //    rptSub3.Visible = false;
                //}
                //else
                //{
                //    rptSub3.DataSource = dtSub;
                //    rptSub3.ItemDataBound += new RepeaterItemEventHandler(rptSub3_ItemDataBound);
                //    rptSub3.DataBind();
                //}
            }
        }
    }
}