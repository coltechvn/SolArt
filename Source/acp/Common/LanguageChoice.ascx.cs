using System;
using iDKCMS.Library;
using iDKCMS.Library.Distributor;

namespace iDKCMS.BackEnd.Common
{
    public partial class LanguageChoice : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rdoLanguage.DataSource = LanguageDistributor.GetAll();
                rdoLanguage.DataTextField = "Language_Name";
                rdoLanguage.DataValueField = "Language_Culture";
                rdoLanguage.DataBind();
                rdoLanguage.SelectedIndex = -1;
                MiscUtility.SetSelected(rdoLanguage.Items, AppEnv.GetLanguage().ToString());
            }
        }

        protected void rdoLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppEnv.SetLanguage(rdoLanguage.SelectedValue);
            string langCulture = "lang=" + Request.Params.Get("lang");
            Response.Redirect(Request.RawUrl.Replace(langCulture, "lang=" + rdoLanguage.SelectedValue));
        }
    }
}