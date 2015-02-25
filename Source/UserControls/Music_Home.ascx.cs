using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iDKCMS.Library;

namespace iDKCMS.FrontEnd.UserControls
{
    public partial class Music_Home : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var audioUrl = AppEnv.BackgroundMusic;

            if(audioUrl.Length > 0)
            {
                Audio1.AudioURL = audioUrl;
            }
        }
    }
}