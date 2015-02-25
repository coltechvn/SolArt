using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;
using iDKCMS.Library.Solart;

namespace iDKCMS.FrontEnd.Project
{
    public partial class Search_Khoahoc : System.Web.UI.UserControl
    {
        private string _dotuoi = string.Empty;
        private string _monhoc = string.Empty;
        private string _coso = string.Empty;
        private string _lophoc = string.Empty;
        private int _khoahocid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            _dotuoi = ConvertUtility.ToString(Request.QueryString["dt"]);
            _monhoc = ConvertUtility.ToString(Request.QueryString["mh"]);
            _coso = ConvertUtility.ToString(Request.QueryString["cs"]);

            if (!IsPostBack)
            {
                dropFilterMonHoc.DataSource = MonhocDB.GetAll();
                dropFilterMonHoc.DataTextField = "Monhoc_Name";
                dropFilterMonHoc.DataValueField = "Monhoc_ID";
                dropFilterMonHoc.DataBind();
                dropFilterMonHoc.Items.Insert(0, new ListItem("Chọn môn học", ""));

                dropFilterCoso.DataSource = CosoDB.GetAll();
                dropFilterCoso.DataTextField = "Coso_Name";
                dropFilterCoso.DataValueField = "Coso_ID";
                dropFilterCoso.DataBind();
                dropFilterCoso.Items.Insert(0, new ListItem("Chọn cơ sở", ""));

                MiscUtility.SetSelected(dropFilterDoTuoi.Items, _dotuoi);
                MiscUtility.SetSelected(dropFilterMonHoc.Items, _monhoc);
                MiscUtility.SetSelected(dropFilterCoso.Items, _coso);
            }
        }

        protected void butSearch_Click(object sender, EventArgs e)
        {
            var dotuoi = dropFilterDoTuoi.SelectedValue;
            var monhoc = dropFilterMonHoc.SelectedValue;
            var coso = dropFilterCoso.SelectedValue;

            Response.Redirect(UrlFilter.BuildUrlByZoneID(ConvertUtility.ToInt32(SettingDB.GetValue(AppEnv.CMS_ZoneClassRegister + AppEnv.GetLanguageFrontEnd()))) + "&dt=" + dotuoi + "&mh=" + monhoc + "&cs=" + coso, true);
        }
    }
}