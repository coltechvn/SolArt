using System;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd
{
    public partial class Default : System.Web.UI.Page
    {
        private string defaultTitle = AppEnv.WebTitle;
        protected string Pageclass = "sub";

        protected void Page_Load(object sender, EventArgs e)
        {
            litDescription.Text = "<meta name=\"description\" content=\"" + AppEnv.MetaDescription + "\">";
            litKeyword.Text =
                "<meta name=\"keywords\" content=\"" + AppEnv.MetaSearch + "\">";

            AppEnv.GetLanguageFrontEnd();

            string jumpto = ConvertUtility.ToString(Request.QueryString["tab"]);
            switch (jumpto)
            {
                case "zone":
                    PlaceHolder1.Controls.Add(Page.LoadControl("Layout/Zone.ascx"));
                    break;
                case "content":
                    PlaceHolder1.Controls.Add(Page.LoadControl("Layout/Content.ascx"));
                    break;
                case "register":
                    PlaceHolder1.Controls.Add(Page.LoadControl("UserControls/Register_Member.ascx"));
                    break;
                case "active":
                    PlaceHolder1.Controls.Add(Page.LoadControl("UserControls/Active_Member.ascx"));
                    break;
                case "cart":
                    PlaceHolder1.Controls.Add(Page.LoadControl("UserControls/Cart.ascx"));
                    break;
                default:
                    PlaceHolder1.Controls.Add(Page.LoadControl("Layout/Home.ascx"));
                    Pageclass = "banner_wrap";
                    Column_Right1.Visible = false;
                    TuyenSinh_Home1.Visible = true;
                    Home_AloneArea1.Visible = true;
                    break;
            }

            int itemid = ConvertUtility.ToInt32(Request.QueryString["itemid"]);

            if (itemid != 0)
            {
                switch (jumpto)
                {
                    case "tab":
                        litWebTitle.Text = defaultTitle + " - " + DistributionDB.GetNameByDistID(itemid);
                        break;
                    default:
                        litWebTitle.Text = defaultTitle;
                        break;
                }
            }
            else
            {
                int zonecurrent = ZoneUtility.GetZoneCurrent();

                if (zonecurrent == 0)
                    litWebTitle.Text = defaultTitle;
                else
                    litWebTitle.Text = defaultTitle + " - " + ZoneDB.GetZoneNameByID(zonecurrent);
            }
        }
    }
}