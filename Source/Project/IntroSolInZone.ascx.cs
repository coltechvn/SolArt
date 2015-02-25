using System;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.Project
{
    public partial class IntroSolInZone : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            const string boxtname = "inzoneintro";
            var zoneid = ConvertUtility.ToInt32(ZoneDB.GetIDByFriendlyUrl(boxtname));

            if (zoneid <= 0) return;
            var info = ZoneDB.GetInfo(zoneid);
            if (info == null) return;

            litName.Text = info.Zone_Name;
            litContent.Text = info.Zone_Description;
        }
    }
}