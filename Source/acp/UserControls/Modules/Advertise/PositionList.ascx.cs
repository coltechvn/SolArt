using System;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.BackEnd.UserControls.Modules.Advertise
{
    public partial class PositionList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) LoadPositions();
            lblUpdateStatus.Text = string.Empty;
        }

        private void LoadPositions()
        {
            dtgPositions.DataSource = PositionDB.GetAll();
            dtgPositions.DataBind();
        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            PositionInfo info = PositionDB.GetInfo(ConvertUtility.ToInt32(txtID.Text));
            info.Pos_Position = txtPosition.Text.Trim();
            info.Pos_Type = dropType.SelectedValue;
            info.Pos_Name = txtName.Text.Trim();
            info.Pos_SeparateCode = txtSeparateCode.Text.Trim();
            info.Pos_Width = ConvertUtility.ToInt32(txtWidth.Text);
            info.Pos_Height = ConvertUtility.ToInt32(txtHeight.Text);
            try
            {
                PositionDB.Update(info);
                lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
                LoadPositions();
            }
            catch
            {
                lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
            }
        }

        protected void cmdAddNew_Click(object sender, EventArgs e)
        {
            PositionInfo info = new PositionInfo();
            info.Pos_Type = dropType.SelectedValue;
            info.Pos_Name = txtName.Text.Trim();
            info.Pos_Position = txtPosition.Text.Trim();
            info.Pos_SeparateCode = txtSeparateCode.Text.Trim();
            info.Pos_Width = ConvertUtility.ToInt32(txtWidth.Text);
            info.Pos_Height = ConvertUtility.ToInt32(txtHeight.Text);
            //try
            //{
            PositionDB.Insert(info);
            lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
            LoadPositions();
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
            txtPosition.Text = string.Empty;
        }

        protected void dtgPositions_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                PositionInfo info = PositionDB.GetInfo(ConvertUtility.ToInt32(e.Item.Cells[0].Text));
                if (info == null) return;
                txtID.Text = info.Pos_ID.ToString();
                txtName.Text = info.Pos_Name;
                txtPosition.Text = info.Pos_Position;
                dropType.SelectedIndex = -1;
                MiscUtility.SetSelected(dropType.Items, info.Pos_Type);
                txtSeparateCode.Text = info.Pos_SeparateCode;
                txtWidth.Text = info.Pos_Width.ToString();
                txtHeight.Text = info.Pos_Height.ToString();
            }
            if (e.CommandName == "del")
            {
                try
                {
                    PositionDB.Delete(ConvertUtility.ToInt32(e.Item.Cells[0].Text));
                    lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
                    LoadPositions();
                }
                catch
                {
                    lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
                }
            }
        }

        protected void dtgPositions_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            Button cmdDel = (Button)e.Item.FindControl("cmdDel");
            cmdDel.Attributes.Add("onclick", MiscUtility.DELETE_CONFIRM);
            switch (e.Item.Cells[3].Text)
            {
                case "rotator":
                    e.Item.Cells[3].Text = "Xoay vòng";
                    break;
                case "random":
                    e.Item.Cells[3].Text = "Ngẫu nhiên";
                    break;
                case "popup":
                    e.Item.Cells[3].Text = "PopUp";
                    break;
                case "namngang":
                    e.Item.Cells[3].Text = "Chiều ngang";
                    break;
                default:
                    e.Item.Cells[3].Text = "Chiều dọc";
                    break;
            }
        }
    }
}