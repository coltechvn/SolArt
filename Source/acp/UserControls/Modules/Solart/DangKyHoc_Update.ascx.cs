using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.Solart;

namespace iDKCMS.BackEnd.UserControls.Modules.Solart
{
    public partial class DangKyHoc_Update : System.Web.UI.UserControl
    {
        private int _hocsinhid;
        protected void Page_Load(object sender, EventArgs e)
        {
            _hocsinhid = ConvertUtility.ToInt32(Request.QueryString["hocsinhid"]);
            if (_hocsinhid == 0) return;
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            HocsinhInfo info = HocsinhDB.GetInfo(_hocsinhid);
            if (info == null) return;

            lblDateTime.Text = ConvertUtility.ToDateTime(info.Hocsinh_CreateDate).ToString("dd/MM/yyyy HH:mm");
            lnkFullname.Text = info.Hocsinh_Name;
            lnkFullname.NavigateUrl = "mailto:" + info.Hocsinh_Email;
            lblPhuHuynh.Text = info.Hocsinh_Parent;
            lblEmail.Text = info.Hocsinh_Email;
            lblPhone.Text = info.Hocsinh_Tel;
            lblAddress.Text = info.Hocsinh_Address.Replace("\n", "<br>");
            lblBirthday.Text = info.Hocsinh_Birthday;
            lblContent.Text = info.Hocsinh_Note.Replace("\n", "<br>");
            chkIsLearning.Checked = info.Hocsinh_IsLearning;

            dtlProduct.DataSource = HocsinhRegisterDB.GetKhoahoc(_hocsinhid);
            dtlProduct.DataBind();
        }

        protected void butUpdate_Click(object sender, EventArgs e)
        {
            var info = HocsinhDB.GetInfo(_hocsinhid);
            info.Hocsinh_IsLearning = ConvertUtility.ToBoolean(chkIsLearning.Checked);
            try
            {
                HocsinhDB.Update(info);
                lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch
            {
                lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
            }
        }

        protected void butDelete_Click(object sender, EventArgs e)
        {
            try
            {
                HocsinhDB.Delete(_hocsinhid);
                Response.Redirect(AppEnv.ADMIN_CMD + "classregisterlist");
            }
            catch
            {
                lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
            }
        }

        protected void butCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(AppEnv.ADMIN_CMD + "classregisterlist");
        }

        protected void dtlProduct_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                var contentid = ConvertUtility.ToInt32(e.CommandArgument);
                try
                {
                    HocsinhRegisterDB.Delete(_hocsinhid, contentid);

                    lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
                }
                catch
                {
                    lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
                }
            }
        }

        protected void dtlProduct_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var curData = (DataRowView)e.Item.DataItem;

                var lnkName = (HyperLink)e.Item.FindControl("lnkName");
                var litLophoc = (Literal)e.Item.FindControl("litLophoc");
                var litKhaiGiang = (Literal)e.Item.FindControl("litKhaiGiang");
                var litNoiDungHoc = (Literal)e.Item.FindControl("litNoiDungHoc");
                var litDoTuoi = (Literal)e.Item.FindControl("litDoTuoi");
                var litGioHoc = (Literal)e.Item.FindControl("litGioHoc");
                var rptCoso = (Repeater)e.Item.FindControl("rptCoso");
                
                var butRowDelete = (Button)e.Item.FindControl("butRowDelete");

                lnkName.Text = curData["Content_Name"].ToString();

                litLophoc.Text = curData["Zone_Name"].ToString();
                litKhaiGiang.Text = curData["Khoahoc_KhaiGiang"].ToString();
                litNoiDungHoc.Text = curData["Khoehoc_NoiDungHoc"].ToString();
                litDoTuoi.Text = curData["Khoahoc_DoTuoiText"].ToString();
                litGioHoc.Text = curData["Khoahoc_GioHoc"].ToString();

                butRowDelete.CommandArgument = ConvertUtility.ToString(curData["Content_ID"]);

                rptCoso.DataSource = KhoahocCosoDB.GetCosoDeployed(ConvertUtility.ToInt32(curData["Khoahoc_ID"]));
                rptCoso.ItemDataBound += new RepeaterItemEventHandler(rptCoso_ItemDataBound);
                rptCoso.DataBind();
            }
        }

        protected void rptCoso_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var curData = (DataRowView)e.Item.DataItem;

                var litCoso = (Literal)e.Item.FindControl("litCoso");

                litCoso.Text = CosoDB.GetNameByID(ConvertUtility.ToInt32(curData["Coso_ID"]));
            }
        }
    }
}