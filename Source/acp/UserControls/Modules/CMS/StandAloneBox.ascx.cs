using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.BackEnd.UserControls.Modules.CMS
{
    public partial class StandAloneBox : System.Web.UI.UserControl
    {
        private string lang = string.Empty;
        private int totalPriority;

        protected void Page_Load(object sender, EventArgs e)
        {
            lang = AppEnv.GetLanguage();

            lblStatusUpdate.Text = "";

            if (!IsPostBack)
            {
                LoadZones();
                btnDelete.Attributes.Add("onclick", "return ConfirmDelete('" + AppEnv.GetConfirm(lang) + "');");
            }
        }

        private void LoadPrioritys(DataTable dataTable)
        {
            totalPriority = 0;

            if (dataTable != null && dataTable.Rows.Count > 0)
            {

                totalPriority = ZoneDB.GetMaxOrder(lang);

                if (totalPriority < dataTable.Rows.Count) totalPriority = dataTable.Rows.Count;

            }

        }

        private int zoneSelected
        {
            get
            {
                if (ViewState["zoneSelected"] != null) return (int)ViewState["zoneSelected"];
                else return 0;
            }
            set { ViewState["zoneSelected"] = value; }
        }


        private void LoadZones()
        {
            ZoneUtility.LoadZones(dropZones.Items);

            lstZones.DataSource = ZoneDB.GetStandAloneBox();
            lstZones.DataValueField = "Zone_ID";
            lstZones.DataTextField = "Zone_Name";
            lstZones.DataBind();
            lstZones.Items.Insert(0, new ListItem("Root", "0"));


            MiscUtility.SetSelected(lstZones.Items, zoneSelected.ToString());

            lstZones_SelectedIndexChanged(null, null);

        }

        protected void lstZones_SelectedIndexChanged(object sender, EventArgs e)
        {
            int zoneID = ConvertUtility.ToInt32(lstZones.SelectedValue);
            zoneSelected = zoneID;

            LoadInfo(zoneID);
        }

        private void LoadInfo(int zoneID)
        {
            hddID.Value = "";
            ZoneInfo info = ZoneDB.GetInfo(zoneID);
            if (info == null)
            {
                //  cmdEmpty_Click(null, null);
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                return;
            }

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            hddID.Value = info.Zone_ID.ToString();

            dropZones.SelectedIndex = -1;
            if (dropZones.Items.FindByValue(info.Zone_ParentID.ToString()) != null)
                dropZones.Items.FindByValue(info.Zone_ParentID.ToString()).Selected = true;

            txtName.Text = info.Zone_Name;
            txtDescriptionCK.HtmlValue = info.Zone_Description;
            txtFriendlyUrl.Text = info.Zone_FriendlyUrl;
            txtRealUrl.Text = info.Zone_RealUrl;
            txtAvatar.Text = info.Zone_Avatar;
            //priority field


            //lang field
            //isStandAloneBox field
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (hddID.Value == "") return;

            ZoneInfo info = ZoneDB.GetInfo(ConvertUtility.ToInt32(hddID.Value));
            if (info == null)
            {
                Reset();
                return;

            }

            if (txtName.Text.Trim() == "")
            {
                lblStatusUpdate.Text = AppEnv.NoticeRequired(lang, "TÊN MỤC");
                return;
            }


            info.Zone_ParentID = ConvertUtility.ToInt32(dropZones.SelectedValue);
            info.Zone_Name = txtName.Text.Trim();
            info.Zone_Description = txtDescriptionCK.HtmlValue;
            info.Zone_FriendlyUrl = txtFriendlyUrl.Text.Replace(" ", "");
            info.Zone_RealUrl = txtRealUrl.Text.Trim();
            info.Zone_Avatar = txtAvatar.Text.Trim();
            //priority field
            info.Zone_Lang = lang;

            if (info.Zone_ID == info.Zone_ParentID)
            {
                lblStatusUpdate.Text = "<font color='red'>" + (lang == "vi-VN" ? " Trùng mục cha, chọn mục cha khác !" : "The same Index Parent,Select other index Parent !") + "</font>";
                return;
            }
            if (ZoneDB.Update(info))
            {
                lblStatusUpdate.Text = AppEnv.NoticeEdit(lang, true);
                hddID.Value = "";
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                Reset();
            }
            else lblStatusUpdate.Text = AppEnv.NoticeEdit(lang, false);

            LoadZones();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (hddID.Value == "") return;

            if (ZoneDB.Delete(ConvertUtility.ToInt32(hddID.Value)))
            {
                lblStatusUpdate.Text = AppEnv.NoticeDelete(lang, true);
                hddID.Value = "";
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                Reset();
            }
            else lblStatusUpdate.Text = AppEnv.NoticeDelete(lang, false);

            zoneSelected = 0;

            LoadZones();
        }

        

        private void Reset()
        {
            txtName.Text = "";
            txtDescriptionCK.HtmlValue = "";
            txtFriendlyUrl.Text = "";
            txtRealUrl.Text = "";
            txtAvatar.Text = "";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            hddID.Value = "";
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            if (txtName.Text.Trim() == "")
            {
                lblStatusUpdate.Text = AppEnv.NoticeRequired(lang, "TÊN TRƯỜNG");
                return;
            }

            var info = new ZoneInfo();
            info.Zone_ParentID = ConvertUtility.ToInt32(dropZones.SelectedValue);
            info.Zone_Name = txtName.Text.Trim();
            info.Zone_Description = txtDescriptionCK.HtmlValue;

            info.Zone_FriendlyUrl = txtFriendlyUrl.Text.Replace(" ", "");

            info.Zone_RealUrl = txtRealUrl.Text.Trim();
            info.Zone_Avatar = txtAvatar.Text.Trim();
            info.Zone_Priority = ZoneDB.GetChildCount(ConvertUtility.ToInt32(dropZones.SelectedValue));
            info.Zone_MetaDescription = "";
            info.Zone_MetaKeywords = "";
            info.Zone_Layout = "";
            info.Zone_SubcategoryDisplay = "";
            info.Zone_ContentListingDisplay = "";
            info.Zone_VisibleInMainNav = false;
            info.Zone_VisibleInLeftNav = false;
            info.Zone_VisibleInTopNav = false;
            info.Zone_VisibleInFooterNav = false;
            info.Zone_ExcludeFromNav = true;
            info.Zone_Visible = false;
            info.Zone_Disable = false;
            info.Zone_Lang = lang;
            info.Zone_IsStandAloneBox = true;

            if (ZoneDB.Insert(info))
            {
                lblStatusUpdate.Text = AppEnv.NoticeAdd(lang, true);
                Reset();
            }
            else
            {
                lblStatusUpdate.Text = AppEnv.NoticeAdd(lang, false);
            }
            LoadZones();
        }
    }
}