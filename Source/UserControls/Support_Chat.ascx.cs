using System;
using iDKCMS.Library;

namespace iDKCMS.FrontEnd.UserControls
{
    public partial class Support_Chat : System.Web.UI.UserControl
    {
        protected string Ym1;
        protected string Ym2;
        protected void Page_Load(object sender, EventArgs e)
        {
            Ym1 = AppEnv.YahooID1;
            Ym2 = AppEnv.YahooID2;

            if (Ym1.Length == 0) liYM1.Visible = false;
            if (Ym2.Length == 0) liYM2.Visible = false;
        }
    }
}