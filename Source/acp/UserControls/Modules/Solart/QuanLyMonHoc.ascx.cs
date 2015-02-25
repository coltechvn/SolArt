using System;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.Solart;

namespace iDKCMS.BackEnd.UserControls.Modules.Solart
{
    public partial class QuanLyMonHoc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUpdateStatus.Text = string.Empty;
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            dtgData.DataSource = MonhocDB.GetAll();
            dtgData.DataBind();
        }

        protected void dtgData_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            var cmdDel = (Button)e.Item.FindControl("cmdDel");
            if (cmdDel != null) cmdDel.Attributes.Add("onclick", MiscUtility.DELETE_CONFIRM);
        }

        protected void dtgData_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                var info = MonhocDB.GetInfo(Convert.ToInt32(e.Item.Cells[0].Text));
                if (info == null)
                {
                    cmdEmpty_Click(null, null);
                    return;
                }
                txtID.Text = info.Monhoc_ID.ToString();
                txtName.Text = info.Monhoc_Name;
            }
            if (e.CommandName == "del")
            {
                try
                {
                    MonhocDB.Delete(Convert.ToInt32(e.Item.Cells[0].Text));
                    lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
                    cmdEmpty_Click(null, null);
                }
                catch
                {
                    lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
                }
            }
        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            var info = MonhocDB.GetInfo(ConvertUtility.ToInt32(txtID.Text));
            if (info == null) return;

            info.Monhoc_Name = txtName.Text.Trim();
            try
            {
                MonhocDB.Update(info);
                lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch
            {
                lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
            }
        }

        protected void cmdAddNew_Click(object sender, EventArgs e)
        {
            var info = new MonhocInfo();
            info.Monhoc_Name = txtName.Text.Trim();
            //try
            //{
            txtID.Text = MonhocDB.Insert(info).ToString();
            lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
            //}
            //catch
            //{
            //    lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
            //}
        }

        protected void cmdEmpty_Click(object sender, EventArgs e)
        {
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
        }
    }
}