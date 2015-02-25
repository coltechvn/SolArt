using System;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.UserControls
{
    public partial class Gallery_Home : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            const string boxtname = "homebottomcenter";
            var zoneid = ConvertUtility.ToInt32(ZoneDB.GetIDByFriendlyUrl(boxtname));

            if (zoneid <= 0) return;
            var info = ZoneDB.GetInfo(zoneid);
            if (info == null) return;

            var avatar = info.Zone_Avatar;
            if(avatar.Length > 0)
            {
                imgAvatar.ImageUrl = UrlFilter.BuildImageUrl(avatar, 235, 0);
            }
            else
            {
                imgAvatar.Visible = false;
            }

            lnkName.Text = info.Zone_Name;

            var realUrl = info.Zone_RealUrl;
            if (realUrl.Length > 0)
            {
                lnkOther.NavigateUrl = lnkName.NavigateUrl = realUrl;
            }
            else
                lnkOther.NavigateUrl = lnkName.NavigateUrl = UrlFilter.BuildUrlByZoneID(info.Zone_ParentID);
        }
    }
}