using System;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.Layout
{
    public partial class Content : System.Web.UI.UserControl
    {
        private int _itemid;
        protected void Page_Load(object sender, EventArgs e)
        {
            _itemid = ConvertUtility.ToInt32(Request.QueryString["itemid"]);

            var disInfo = DistributionDB.GetInfo(_itemid);
            if(disInfo != null)
            {
                if(disInfo.Distribution_Layout == "zone")
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("Layout/" + ZoneDB.GetZoneLayout(disInfo.Distribution_ZoneID)  + "_Item.ascx"));
                }
                else
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("Layout/" + disInfo.Distribution_Layout + "_Item.ascx"));
                }
            }
            else
            {
                Response.Redirect("/");
            }
        }
    }
}