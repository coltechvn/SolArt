using System;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.BackEnd.UserControls.Modules.Advertise
{
    public partial class UploadAdvertise : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (ConvertUtility.ToBoolean(AppEnv.AdvInZone))
                {
                    ZoneUtility.LoadZones(lstZones.Items); lstZones.Enabled = true;
                    lstZones.Items.Insert(0, new ListItem("Root 0", "0"));
                }
                else
                {
                    lstZones.Items.Insert(0, new ListItem("Root 0", "0"));
                    lstZones.Enabled = false; lstZones.SelectedIndex = 0;
                }


                lstPositions.DataSource = PositionDB.GetAll();
                lstPositions.DataTextField = "Pos_Name";
                lstPositions.DataValueField = "Pos_ID";
                lstPositions.DataBind();

                SelectDate1.SetDate(DateTime.Now);
                SelectDate2.SetDate(DateTime.Now.AddYears(1));
            }
            txtPath.fpUploadDir = AppEnv.UploadAdvertise;
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            LoadAdvertise();
        }

        private void LoadAdvertise()
        {
            int adID = ConvertUtility.ToInt32(Request.QueryString["advertiseid"]);
            if (adID != 0)
            {
                cmdAddNew.Enabled = false;
                cmdAddNext.Enabled = false;
                cmdEmpty.Enabled = false;
            }
            else adID = ConvertUtility.ToInt32(txtID.Text);
            AdvertiseInfo info = AdvertiseDB.GetInfo(adID);
            if (info == null)
            {
                cmdEmpty_Click(null, null); return;
            }
            txtID.Text = info.Advertise_ID.ToString();
            txtPath.Text = info.Advertise_Path;

            txtName.Text = info.Advertise_Name;
            txtUrl.Text = info.Advertise_RedirectURL;
            txtWidth.Text = info.Advertise_Width.ToString();
            txtHeight.Text = info.Advertise_Height.ToString();
            chkEnable.Checked = info.Advertise_Enable;

            SelectDate1.SetDate(info.Advertise_StartDate);
            SelectDate2.SetDate(info.Advertise_EndDate);
            dropType.SelectedIndex = -1;
            MiscUtility.SetSelected(dropType.Items, info.Advertise_Type);

            lstPositions.SelectedIndex = -1;
            MiscUtility.SetSelected(lstPositions.Items, info.Advertise_PositionID.ToString());

            PositionInfo posInfo = PositionDB.GetInfo(info.Advertise_PositionID);
            if (txtWidth.Text == "0") txtWidth.Text = posInfo.Pos_Width.ToString();
            if (txtHeight.Text == "0") txtHeight.Text = posInfo.Pos_Height.ToString();

            txtEmbed.Text = info.Advertise_Embed;

            foreach (ListItem item in lstZones.Items)
                if (Convert.ToString("|" + info.Advertise_Params).IndexOf("|" + item.Value + "|") >= 0)
                    item.Selected = true;
                else item.Selected = false;

        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            AdvertiseInfo info = AdvertiseDB.GetInfo(ConvertUtility.ToInt32(txtID.Text));
            if (info == null)
            {
                cmdEmpty_Click(null, null); return;
            }
            info.Advertise_Name = txtName.Text;
            info.Advertise_Enable = chkEnable.Checked;
            info.Advertise_Height = ConvertUtility.ToInt32(txtHeight.Text);
            info.Advertise_Width = ConvertUtility.ToInt32(txtWidth.Text);
            info.Advertise_StartDate = SelectDate1.GetDate();
            info.Advertise_EndDate = SelectDate2.GetDate();
            info.Advertise_Path = txtPath.Text;
            info.Advertise_PositionID = ConvertUtility.ToInt32(lstPositions.SelectedValue);
            info.Advertise_Type = dropType.SelectedValue;
            info.Advertise_RedirectURL = txtUrl.Text;
            info.Advertise_Lang = AppEnv.GetLanguage();
            string location = string.Empty;
            foreach (ListItem item in lstZones.Items) if (item.Selected) location += item.Value + "|";
            info.Advertise_Params = location;
            info.Advertise_Embed = txtEmbed.Text.Trim();

            try
            {
                AdvertiseDB.Update(info);
                lblStatusUpdate.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch
            {
                lblStatusUpdate.Text = MiscUtility.UPDATE_ERROR;
            }
        }

        protected void cmdAddNew_Click(object sender, EventArgs e)
        {
            AdvertiseInfo info = new AdvertiseInfo();
            info.Advertise_Name = txtName.Text;
            info.Advertise_Enable = chkEnable.Checked;
            info.Advertise_Height = ConvertUtility.ToInt32(txtHeight.Text);
            info.Advertise_Width = ConvertUtility.ToInt32(txtWidth.Text);
            info.Advertise_StartDate = SelectDate1.GetDate();
            info.Advertise_EndDate = SelectDate2.GetDate();
            info.Advertise_Path = txtPath.Text;
            info.Advertise_PositionID = ConvertUtility.ToInt32(lstPositions.SelectedValue);
            info.Advertise_Type = dropType.SelectedValue;
            info.Advertise_RedirectURL = txtUrl.Text;
            info.Advertise_Lang = AppEnv.GetLanguage();
            string location = string.Empty;
            foreach (ListItem item in lstZones.Items) if (item.Selected) location += item.Value + "|";
            info.Advertise_Params = location;
            info.Advertise_Embed = txtEmbed.Text.Trim();
            txtID.Text = AdvertiseDB.Insert(info).ToString();
            try
            {

                lblStatusUpdate.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch
            {
                lblStatusUpdate.Text = MiscUtility.UPDATE_ERROR;
            }
        }

        protected void cmdAddNext_Click(object sender, EventArgs e)
        {
            cmdAddNew_Click(null, null);
            cmdEmpty_Click(null, null);
        }

        protected void cmdEmpty_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtID.Text = string.Empty;
            txtPath.Text = string.Empty;
            txtUrl.Text = "http://";
            txtEmbed.Text = string.Empty;
        }

        protected void lstPositions_SelectedIndexChanged(object sender, EventArgs e)
        {
            int posid = ConvertUtility.ToInt32(lstPositions.SelectedValue);

            PositionInfo posInfo = PositionDB.GetInfo(posid);
            txtWidth.Text = posInfo.Pos_Width.ToString();
            txtHeight.Text = posInfo.Pos_Height.ToString();
        }
    }
}