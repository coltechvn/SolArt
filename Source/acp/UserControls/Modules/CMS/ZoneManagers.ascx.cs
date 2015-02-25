using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.BackEnd.UserControls.Modules.CMS
{
    public partial class ZoneManagers : System.Web.UI.UserControl
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
            ZoneUtility.LoadZones(lstZones.Items);
            lstZones.Items.Insert(0, new ListItem("Root", "0"));

            dropZones.Items.Clear();
            foreach (ListItem item in lstZones.Items)
                dropZones.Items.Add(new ListItem(item.Text, item.Value));


            MiscUtility.SetSelected(lstZones.Items, zoneSelected.ToString());

            lstZones_SelectedIndexChanged(null, null);

        }

        protected void lstZones_SelectedIndexChanged(object sender, EventArgs e)
        {
            int zoneID = ConvertUtility.ToInt32(lstZones.SelectedValue);
            zoneSelected = zoneID;

            DataTable data = ZoneDB.GetByParentID(zoneID);

            LoadPrioritys(data);

            dtgZones.DataSource = data;
            dtgZones.DataBind();

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
            txtDescription.Text = info.Zone_Description;
            txtFriendlyUrl.Text = info.Zone_FriendlyUrl;
            txtRealUrl.Text = info.Zone_RealUrl;
            txtAvatar.Text = info.Zone_Avatar;
            //priority field
            txtMetaDescription.Text = info.Zone_MetaDescription;
            txtMetaKeywords.Text = info.Zone_MetaKeywords;

            dropLayout.SelectedIndex = -1;
            if (dropLayout.Items.FindByValue(info.Zone_Layout) != null)
                dropLayout.Items.FindByValue(info.Zone_Layout).Selected = true;

            dropSubcategoryDisplay.SelectedIndex = -1;
            dropSubcategoryDisplay.SelectedValue = info.Zone_SubcategoryDisplay;

            dropContentDisplay.SelectedIndex = -1;
            dropContentDisplay.SelectedValue = info.Zone_ContentListingDisplay;

            chkMainNav.Checked = info.Zone_VisibleInMainNav;
            chkLeftNav.Checked = info.Zone_VisibleInLeftNav;
            chkTopNav.Checked = info.Zone_VisibleInTopNav;
            chkFooterNav.Checked = info.Zone_VisibleInFooterNav;

            chkExcludeFromNav.Checked = info.Zone_ExcludeFromNav;
            chkVisible.Checked = info.Zone_Visible;
            chkDisable.Checked = info.Zone_Disable;
            
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
            info.Zone_Description = txtDescription.Text;
            info.Zone_FriendlyUrl = UnicodeUtility.UnicodeToFriendlyUrl(txtName.Text);
            info.Zone_RealUrl = txtRealUrl.Text.Trim();
            info.Zone_Avatar = txtAvatar.Text.Trim();
            //priority field
            info.Zone_MetaDescription = txtDescription.Text;
            info.Zone_MetaKeywords = txtMetaKeywords.Text;
            info.Zone_Layout= dropLayout.SelectedValue;
            info.Zone_SubcategoryDisplay = dropSubcategoryDisplay.SelectedValue;
            info.Zone_ContentListingDisplay = dropContentDisplay.SelectedValue;
            info.Zone_VisibleInMainNav = chkMainNav.Checked;
            info.Zone_VisibleInLeftNav = chkLeftNav.Checked;
            info.Zone_VisibleInTopNav = chkTopNav.Checked;
            info.Zone_VisibleInFooterNav = chkFooterNav.Checked;
            info.Zone_ExcludeFromNav = chkExcludeFromNav.Checked;
            info.Zone_Visible = chkVisible.Checked;
            info.Zone_Disable = chkDisable.Checked;
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

        protected void dtgZones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lbl;
            LinkButton lnk;
            DropDownList ddl;

            lbl = (Label)e.Row.FindControl("lblHZone_Name");
            if (lbl != null)
            {
                lbl.Text = (lang == "vi-VN" ? "Tên mục" : "Index Name");
            }

            lnk = (LinkButton)e.Row.FindControl("lnkOrder");
            if (lnk != null)
            {
                lnk.Text = (lang == "vi-VN" ? "Thứ tự" : "Order");
            }

            lbl = (Label)e.Row.FindControl("lblPriority");
            ddl = (DropDownList)e.Row.FindControl("ddlOrder");

            if (lbl != null && ddl != null)
            {
                int order = ConvertUtility.ToInt32(lbl.Text);
                MiscUtility.FillIndex(ddl, totalPriority, order);
            }
        }

        protected void lnkOrder_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvr in dtgZones.Rows)
            {
                Label lblID = (Label)(gvr.FindControl("lblID"));

                if (lblID != null)
                {
                    //  lblNotice_1.Text = lblID.Text;

                    DropDownList ddlOrder = (DropDownList)gvr.FindControl("ddlOrder");
                    int newOrder = ConvertUtility.ToInt32(ddlOrder.SelectedValue);
                    int tabID = ConvertUtility.ToInt32(lblID.Text);
                    ZoneDB.SetPriority(tabID, newOrder);
                }
            }


            LoadZones();
        }

        private void Reset()
        {
            txtName.Text = "";
            txtDescription.Text = "";
            txtFriendlyUrl.Text = "";
            txtRealUrl.Text = "";
            txtAvatar.Text = "";
            txtMetaDescription.Text = "";
            txtMetaKeywords.Text = "";
            chkMainNav.Checked = false;
            chkLeftNav.Checked = false;
            chkTopNav.Checked = false;
            chkFooterNav.Checked = false;
            chkExcludeFromNav.Checked = false;
            chkVisible.Checked = true;
            chkDisable.Checked = false;
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
            info.Zone_Description = txtDescription.Text;

            info.Zone_FriendlyUrl = UnicodeUtility.UnicodeToFriendlyUrl(txtName.Text);

            info.Zone_RealUrl = txtRealUrl.Text.Trim();
            info.Zone_Avatar = txtAvatar.Text.Trim();
            info.Zone_Priority = ZoneDB.GetChildCount(ConvertUtility.ToInt32(dropZones.SelectedValue));
            info.Zone_MetaDescription = txtMetaDescription.Text;
            info.Zone_MetaKeywords = txtMetaKeywords.Text;
            info.Zone_Layout = dropLayout.SelectedValue;
            info.Zone_SubcategoryDisplay = dropSubcategoryDisplay.SelectedValue;
            info.Zone_ContentListingDisplay = dropContentDisplay.SelectedValue;
            info.Zone_VisibleInMainNav = chkMainNav.Checked;
            info.Zone_VisibleInLeftNav = chkLeftNav.Checked;
            info.Zone_VisibleInTopNav = chkTopNav.Checked;
            info.Zone_VisibleInFooterNav = chkFooterNav.Checked;
            info.Zone_ExcludeFromNav = chkExcludeFromNav.Checked;
            info.Zone_Visible = chkVisible.Checked;
            info.Zone_Disable = chkDisable.Checked;
            info.Zone_Lang = lang;
            info.Zone_IsStandAloneBox = false;
            
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