using System;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;


namespace iDKCMS.FrontEnd.Project
{
    public partial class TuyenSinh_Detail : System.Web.UI.UserControl
    {
        private DistributionInfo _distInfo;

        protected void Page_Load(object sender, EventArgs e)
        {
            _distInfo = DistributionDB.GetInfo(ConvertUtility.ToInt32(Request.QueryString["itemid"]));
            if (_distInfo == null)
            {
                Visible = false;
                return;
            }

            DistributionDB.UpdateView(_distInfo.Distribution_ID, 1);

            var contentInfo = ContentDB.GetInfo(_distInfo.Distribution_ContentID);
            litName.Text = contentInfo.Content_Name;

            if (_distInfo.Distribution_DisableTeaser)
            {
                pnTeaser.Visible = false;
            }
            else
            {
                if (contentInfo.Content_Teaser.Length > 0)
                    litTeaser.Text = contentInfo.Content_Teaser;
                else litTeaser.Visible = false;

                if (_distInfo.Distribution_DisableAvatar)
                {
                    imgAvatar.Visible = false;
                }
                else
                {
                    var coverInfo = ImageDB.GetCover(ConvertUtility.ToInt32(contentInfo.Content_ID));
                    if (coverInfo != null)
                    {
                        string avatar = coverInfo.Image_File;
                        if (avatar.Length > 0)
                        {
                            imgAvatar.ImageUrl = UrlFilter.BuildImageUrl(avatar, 150, 0);
                            lnkAvatar.NavigateUrl = MultimediaUtility.GetOriginalImage(avatar);

                            lnkAvatar.Attributes.Add("rel", "prettyPhoto");
                            lnkAvatar.ToolTip = coverInfo.Image_Description;
                        }
                        else
                        {
                            imgAvatar.Visible = false;
                        }
                    }
                    else
                    {
                        imgAvatar.Visible = false;
                    }
                }
            }

            litContent.Text = contentInfo.Content_Body;

            //litDatetime.Text = ConvertUtility.ToDateTime(distInfo.Distribution_CreateDate).ToString("dd/MM/yyyy");



            //DataTable dtNews = DistributionDB.GetNewsForCurrent(distInfo.Distribution_ID, 5);
            //if (dtNews.Rows.Count == 0)
            //{
            //    pnNew.Visible = false;
            //}
            //else
            //{
            //    rptNew.DataSource = dtNews;
            //    rptNew.DataBind();
            //}

            var khInfo = KhoahocDB.GetInfo(ConvertUtility.ToInt32(contentInfo.Content_ID));

            if (khInfo != null)
            {
                litDatetime.Text = khInfo.Khoahoc_KhaiGiang;
                lnkRegister.NavigateUrl =
                    UrlFilter.BuildUrlByZoneID(
                        ConvertUtility.ToInt32(
                            SettingDB.GetValue(AppEnv.CMS_ZoneClassRegister + AppEnv.GetLanguageFrontEnd()))) +
                    "&khoahocid=" + khInfo.Khoahoc_ID;
            }
        }
    }
}