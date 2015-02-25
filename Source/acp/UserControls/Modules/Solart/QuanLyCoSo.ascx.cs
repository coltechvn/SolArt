using System;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.Solart;

namespace iDKCMS.BackEnd.UserControls.Modules.Solart
{
    public partial class QuanLyCoSo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUpdateStatus.Text = string.Empty;
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            dtgData.DataSource = CosoDB.GetAll();
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
                var info = CosoDB.GetInfo(Convert.ToInt32(e.Item.Cells[0].Text));
                if (info == null)
                {
                    cmdEmpty_Click(null, null);
                    return;
                }
                txtID.Text = info.Coso_ID.ToString();
                txtName.Text = info.Coso_Name;
                txtDes.Text = info.Coso_Info;
                txtAvatar.Text = info.Coso_Map;
            }
            if (e.CommandName == "del")
            {
                try
                {
                    CosoDB.Delete(Convert.ToInt32(e.Item.Cells[0].Text));
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
            var info = CosoDB.GetInfo(ConvertUtility.ToInt32(txtID.Text));
            if (info == null) return;

            info.Coso_Name = txtName.Text.Trim();
            info.Coso_Info = txtDes.Text;
            info.Coso_Map = txtAvatar.Text;
            try
            {
                CosoDB.Update(info);
                lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch
            {
                lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
            }
        }

        protected void cmdAddNew_Click(object sender, EventArgs e)
        {
            var info = new CosoInfo();
            info.Coso_Name = txtName.Text.Trim();
            info.Coso_Info = txtDes.Text;
            info.Coso_Map = txtAvatar.Text;
            //try
            //{
            txtID.Text = CosoDB.Insert(info).ToString();
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