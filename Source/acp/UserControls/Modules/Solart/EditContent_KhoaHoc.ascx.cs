using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;
using iDKCMS.Library.Solart;

namespace iDKCMS.BackEnd.UserControls.Modules.Solart
{
    public partial class EditContent_KhoaHoc : System.Web.UI.UserControl
    {
        private int _contentid;

        protected void Page_Load(object sender, EventArgs e)
        {
            _contentid = ConvertUtility.ToInt32(Request.QueryString["contentid"]);

            //mydealInfo = MydealItemDB.GetInfo(_contentid);

            if (!IsPostBack)
            {
                ZoneUtility.LoadZonesByParentID(dropLopHoc.Items, ConvertUtility.ToInt32(SettingDB.GetValue(AppEnv.CMS_ZoneKhoaHoc + AppEnv.GetLanguage())));
                dropLopHoc.Items.Insert(0, new ListItem("Lựa chọn lớp học", "0"));

                chklMonHoc.DataSource = MonhocDB.GetAll();
                chklMonHoc.DataTextField = "Monhoc_Name";
                chklMonHoc.DataValueField = "Monhoc_ID";
                chklMonHoc.DataBind();

                chklCoso.DataSource = CosoDB.GetAll();
                chklCoso.DataTextField = "Coso_Name";
                chklCoso.DataValueField = "Coso_ID";
                chklCoso.DataBind();

                chkVisible.Checked = true;
            }
            lblStatusUpdate.Text = string.Empty;
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (!IsPostBack)
            {
                var dtitems = KhoahocDB.GetContentCount(_contentid);

                if (dtitems.Rows.Count > 0)
                {
                    var khoahocInfo = KhoahocDB.GetInfo(_contentid);

                    MiscUtility.SetSelected(dropLopHoc.Items, khoahocInfo.Zone_ID.ToString());
                    txtNoiDungHocText.Text = khoahocInfo.Khoehoc_NoiDungHoc;

                    // do tuoi
                    string doTuoi = "|" + khoahocInfo.Khoahoc_DoTuoi;
                    foreach (ListItem item3 in lstDoTuoi.Items)
                        if (doTuoi.IndexOf("|" + item3.Value + "|") >= 0) item3.Selected = true;
                        else item3.Selected = false;

                    txtDoTuoiText.Text = khoahocInfo.Khoahoc_DoTuoiText;
                    txtGioHoc.Text = khoahocInfo.Khoahoc_GioHoc;
                    txtKhaiGiang.Text = khoahocInfo.Khoahoc_KhaiGiang;
                    chkVisible.Checked = khoahocInfo.Khoahoc_Avaiable;

                    //co so
                    string zoneDeployed = "|";
                    DataTable dtZoneDeployed = KhoahocCosoDB.GetCosoDeployed(khoahocInfo.Khoahoc_ID);
                    foreach (DataRow row in dtZoneDeployed.Rows) zoneDeployed += row["Coso_ID"] + "|";

                    foreach (ListItem item in chklCoso.Items)
                        if (zoneDeployed.IndexOf("|" + item.Value + "|") >= 0) item.Selected = true;
                        else item.Selected = false;

                    // mon hoc

                    string monhocDeployed = "|";
                    DataTable dtMonHoc = KhoahocMonhocDB.GetMonhocDeployed(khoahocInfo.Khoahoc_ID);
                    foreach (DataRow row in dtMonHoc.Rows) monhocDeployed += row["Monhoc_ID"] + "|";

                    foreach (ListItem item2 in chklMonHoc.Items)
                        if (monhocDeployed.IndexOf("|" + item2.Value + "|") >= 0) item2.Selected = true;
                        else item2.Selected = false;
                }
                else
                {
                    butDelete.Visible = false;
                }
            }
        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            var dtitems = KhoahocDB.GetContentCount(_contentid);


            //try
            //{
            if (dtitems.Rows.Count > 0)
            {
                var info = KhoahocDB.GetInfo(_contentid);

                var khoahocId = info.Khoahoc_ID;

                info.Zone_ID = ConvertUtility.ToInt32(dropLopHoc.SelectedValue);
                info.Khoehoc_NoiDungHoc = txtNoiDungHocText.Text;

                //dotuoi
                var zoneFocus = "|";
                foreach (ListItem item in lstDoTuoi.Items)
                {
                    if(item.Selected)
                        zoneFocus += item.Value + "|";
                }
                info.Khoahoc_DoTuoi = zoneFocus;

                info.Khoahoc_DoTuoiText = txtDoTuoiText.Text;
                info.Khoahoc_GioHoc = txtGioHoc.Text;
                info.Khoahoc_KhaiGiang = txtKhaiGiang.Text;
                info.Khoahoc_Avaiable = Convert.ToBoolean(chkVisible.Checked);

                foreach (ListItem item in chklCoso.Items)
                    if (item.Selected)
                    {
                        KhoahocCosoDB.Remover(khoahocId, Convert.ToInt32(item.Value));

                        var khoahoccosoInfo = new KhoahocCosoInfo();
                        khoahoccosoInfo.Khoahoc_ID = khoahocId;
                        khoahoccosoInfo.Coso_ID = Convert.ToInt32(item.Value);
                        KhoahocCosoDB.Insert(khoahoccosoInfo);

                        lblStatusUpdate.Text += item.Text + ",<br>";
                    }
                    else
                        KhoahocCosoDB.Remover(khoahocId, Convert.ToInt32(item.Value));

                foreach (ListItem item2 in chklMonHoc.Items)
                    if (item2.Selected)
                    {
                        KhoahocMonhocDB.Remover(khoahocId, Convert.ToInt32(item2.Value));
                        KhoahocMonhocDB.Insert(khoahocId, ConvertUtility.ToInt32(item2.Value));

                    }
                    else
                        KhoahocMonhocDB.Remover(khoahocId, Convert.ToInt32(item2.Value));

                KhoahocDB.Update(info);
            }
            else
            {
                var info = new KhoahocInfo();
                info.Content_ID = _contentid;
                info.Zone_ID = ConvertUtility.ToInt32(dropLopHoc.SelectedValue);
                info.Khoehoc_NoiDungHoc = txtNoiDungHocText.Text;

                //dotuoi
                var zoneFocus = "|";
                foreach (ListItem item in lstDoTuoi.Items)
                {
                    if (item.Selected)
                        zoneFocus += item.Value + "|";
                }
                info.Khoahoc_DoTuoi = zoneFocus;

                info.Khoahoc_DoTuoiText = txtDoTuoiText.Text;
                info.Khoahoc_GioHoc = txtGioHoc.Text;
                info.Khoahoc_KhaiGiang = txtKhaiGiang.Text;
                info.Khoahoc_Avaiable = Convert.ToBoolean(chkVisible.Checked);

                var khoahocId = KhoahocDB.Insert(info);

                foreach (ListItem item in chklCoso.Items)
                    if (item.Selected)
                    {
                        KhoahocCosoDB.Remover(khoahocId, Convert.ToInt32(item.Value));

                        var khoahoccosoInfo = new KhoahocCosoInfo();
                        khoahoccosoInfo.Khoahoc_ID = khoahocId;
                        khoahoccosoInfo.Coso_ID = Convert.ToInt32(item.Value);
                        KhoahocCosoDB.Insert(khoahoccosoInfo);

                        lblStatusUpdate.Text += item.Text + ",<br>";
                    }
                    else
                        KhoahocCosoDB.Remover(khoahocId, Convert.ToInt32(item.Value));


                foreach (ListItem item2 in chklMonHoc.Items)
                    if (item2.Selected)
                    {
                        KhoahocMonhocDB.Remover(khoahocId, Convert.ToInt32(item2.Value));
                        KhoahocMonhocDB.Insert(khoahocId, ConvertUtility.ToInt32(item2.Value));

                    }
                    else
                        KhoahocMonhocDB.Remover(khoahocId, Convert.ToInt32(item2.Value));
            }

            //Response.Redirect(Request.RawUrl + "#idTab7");
            lblSuccess.Visible = true;

            lblStatusUpdate.Text = lblSuccess.Text = MiscUtility.UPDATE_SUCCESS;
            //}
            //catch
            //{
            //    lblStatusUpdate.Text = MiscUtility.UPDATE_ERROR;
            //}

        }

        protected void butDelete_Click(object sender, EventArgs e)
        {
            var dtitems = KhoahocDB.GetContentCount(_contentid);

            if (dtitems.Rows.Count > 0)
            {
                var info = KhoahocDB.GetInfo(_contentid);

                var khoahocId = info.Khoahoc_ID;

                KhoahocDB.Delete(khoahocId);

                lblStatusUpdate.Text = lblSuccess.Text = MiscUtility.UPDATE_SUCCESS;
            }
        }
    }
}