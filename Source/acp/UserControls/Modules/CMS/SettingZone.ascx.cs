using System;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.BackEnd.UserControls.Modules.CMS
{
    public partial class SettingZone : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ZoneUtility.LoadZones(dropZoneHome.Items);
                foreach (ListItem item in dropZoneHome.Items)
                {
                    //lstZones.Items.Add(new ListItem(item.Text,item.Value));
                    //lstZonesSmall.Items.Add(new ListItem(item.Text, item.Value));
                    dropClassRegister.Items.Add(new ListItem(item.Text, item.Value));
                    dropKhoaHoc.Items.Add(new ListItem(item.Text, item.Value));
                }
            }
            dropZoneHome.SelectedIndex = -1;
            MiscUtility.SetSelected(dropZoneHome.Items, SettingDB.GetValue(AppEnv.CMS_ZoneHome + AppEnv.GetLanguage()));

            dropClassRegister.SelectedIndex = -1;
            MiscUtility.SetSelected(dropClassRegister.Items, SettingDB.GetValue(AppEnv.CMS_ZoneClassRegister + AppEnv.GetLanguage()));

            dropKhoaHoc.SelectedIndex = -1;
            MiscUtility.SetSelected(dropKhoaHoc.Items, SettingDB.GetValue(AppEnv.CMS_ZoneKhoaHoc + AppEnv.GetLanguage()));


            //if (!IsPostBack)
            //{
            //    string zoneFocus = "|" + SettingDB.GetValue(Constants.CMS_ZoneHomeFocus + AppEnv.GetLanguage());
            //    lstZoneFocus.Items.Clear();
            //    foreach (ListItem item in lstZones.Items) if (zoneFocus.IndexOf("|" + item.Value + "|") >= 0) lstZoneFocus.Items.Add(new ListItem(item.Text, item.Value));

            //    string zoneSmallFocus = "|" + SettingDB.GetValue(Constants.CMS_ZoneSmallFocus + AppEnv.GetLanguage());
            //    lstZonesSmallFocus.Items.Clear();
            //    foreach (ListItem itemS in lstZonesSmall.Items) if (zoneSmallFocus.IndexOf("|" + itemS.Value + "|") >= 0) lstZonesSmallFocus.Items.Add(new ListItem(itemS.Text, itemS.Value));
            //}
        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SettingDB.SetValue(AppEnv.CMS_ZoneHome + AppEnv.GetLanguage(), dropZoneHome.SelectedValue);
                SettingDB.SetValue(AppEnv.CMS_ZoneClassRegister + AppEnv.GetLanguage(), dropClassRegister.SelectedValue);
                SettingDB.SetValue(AppEnv.CMS_ZoneKhoaHoc + AppEnv.GetLanguage(), dropKhoaHoc.SelectedValue);

                //string zoneFocus = string.Empty;
                //foreach (ListItem item in lstZoneFocus.Items) zoneFocus += item.Value + "|";
                //SettingDB.SetValue(Constants.CMS_ZoneHomeFocus + AppEnv.GetLanguage(), zoneFocus);

                //string zoneSmallFocus = string.Empty;
                //foreach (ListItem itemS in lstZonesSmallFocus.Items) zoneSmallFocus += itemS.Value + "|";
                //SettingDB.SetValue(Constants.CMS_ZoneSmallFocus + AppEnv.GetLanguage(), zoneSmallFocus);

                lblStatusUpdate.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch
            {
                lblStatusUpdate.Text = MiscUtility.UPDATE_ERROR;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in lstZones.Items) if (item.Selected && (lstZoneFocus.Items.FindByValue(item.Value) == null)) lstZoneFocus.Items.Add(new ListItem(item.Text, item.Value));
        }

        protected void btnRemover_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < lstZoneFocus.Items.Count)
            {
                if (lstZoneFocus.Items[i].Selected) lstZoneFocus.Items.RemoveAt(i);
                else i += 1;
            }
        }

        protected void butZonesSmallAdd_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in lstZonesSmall.Items) if (item.Selected && (lstZonesSmallFocus.Items.FindByValue(item.Value) == null)) lstZonesSmallFocus.Items.Add(new ListItem(item.Text, item.Value));
        }

        protected void butZonesSmallRemove_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < lstZonesSmallFocus.Items.Count)
            {
                if (lstZonesSmallFocus.Items[i].Selected) lstZonesSmallFocus.Items.RemoveAt(i);
                else i += 1;
            }
        }
    }
}