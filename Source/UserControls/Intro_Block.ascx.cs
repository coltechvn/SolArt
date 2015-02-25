using System;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.UserControls
{
    public partial class Intro_Block : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            const string boxtname = "addresshome";
            var zoneid = ConvertUtility.ToInt32(ZoneDB.GetIDByFriendlyUrl(boxtname));

            if (zoneid <= 0) return;
            var info = ZoneDB.GetInfo(zoneid);
            if (info == null) return;

            litContent.Text = info.Zone_Description;
        }
    }
}