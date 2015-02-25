using System;
using iDKCMS.Library;

namespace iDKCMS.BackEnd.UserControls.Core
{
    public partial class Welcome : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblLanguage.Text = AppEnv.GetLanguage();
        }
    }
}