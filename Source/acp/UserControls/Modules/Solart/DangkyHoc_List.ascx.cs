using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.Solart;

namespace iDKCMS.BackEnd.UserControls.Modules.Solart
{
    public partial class DangkyHoc_List : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtSearch.Attributes.Add("onkeyup", "initTyper(this);");
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            var strSQL = "SELECT Solart_Hocsinh.* FROM Solart_Hocsinh ";
            strSQL += " WHERE 1=1 ";

            if (txtSearch.Text != "") strSQL += " AND " + dropSearchBy.SelectedValue + " LIKE N'%" + txtSearch.Text.Trim() + "%'";
            if (dropSearchStatus.SelectedValue != "all") strSQL += " AND Hocsinh_IsLearning=" + dropSearchStatus.SelectedValue + " ";

            if (dtgOrder.SortBy == "") dtgOrder.SortBy = "Hocsinh_CreateDate";
            strSQL += " ORDER BY " + dtgOrder.SortBy + " " + dtgOrder.OrderBy;

            DataTable source = DataHelper.GetDataFromTable(strSQL);

            int curPage = dtgOrder.GetCurrentPageIndex() + 1;
            if (curPage > source.Rows.Count / dtgOrder.PageSize + ConvertUtility.ToInt32(source.Rows.Count % dtgOrder.PageSize > 0) && curPage > 1)
                dtgOrder.CurrentPageIndex = 0;

            dtgOrder.DataSource = source;
            //dtgOrder.ItemDataBound += new DataGridItemEventHandler(dtgOrder_ItemDataBound);
            dtgOrder.DataBind();
            lblTotal.Text = "Total: " + source.Rows.Count;
        }


        protected void butUpdateAll_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridItem item in dtgOrder.Items)
                {
                    int id = ConvertUtility.ToInt32(item.Cells[0].Text);
                    HocsinhInfo info = HocsinhDB.GetInfo(id);

                    var chkIsLearning = (CheckBox)item.FindControl("chkIsLearning");

                    info.Hocsinh_IsLearning = ConvertUtility.ToBoolean(chkIsLearning.Checked);

                    HocsinhDB.Update(info);
                }
                lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch
            {
                lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR; //ex.ToString();
            }
        }

        protected void butDeleteChecked_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridItem item in dtgOrder.Items)
                {
                    CheckBox chkSelect = (CheckBox)item.FindControl("chkSelect");
                    if (chkSelect.Checked)
                    {
                        int id = ConvertUtility.ToInt32(item.Cells[0].Text);
                        HocsinhDB.Delete(id);
                    }
                }
                lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch
            {
                lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR; //ex.ToString();
            }
        }

        protected void dtgProduct_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                int id = ConvertUtility.ToInt32(e.Item.Cells[0].Text);
                try
                {
                    HocsinhDB.Delete(id);
                    lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
                }
                catch
                {
                    lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
                }
            }
            if (e.CommandName == "updaterow")
            {
                try
                {
                    int id = ConvertUtility.ToInt32(e.Item.Cells[0].Text);
                    HocsinhInfo info = HocsinhDB.GetInfo(id);

                    var chkIsLearning = (CheckBox)e.Item.FindControl("chkIsLearning");

                    info.Hocsinh_IsLearning = ConvertUtility.ToBoolean(chkIsLearning.Checked);

                    HocsinhDB.Update(info);

                    lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
                }
                catch
                {
                    lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR; //ex.ToString();
                }
            }
        }

        protected void dtgProduct_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var curData = (DataRowView)e.Item.DataItem;

                var lblDatetime = (Label)e.Item.FindControl("lblDatetime");
                var lnkOrderName = (HyperLink)e.Item.FindControl("lnkOrderName");
                var lblAddress = (Label)e.Item.FindControl("lblAddress");
                var dropStatus = (DropDownList)e.Item.FindControl("dropStatus");

                lblDatetime.Text = ConvertUtility.ToDateTime(curData["Hocsinh_CreateDate"]).ToString("dd/MM/yyyy HH:mm");
                lnkOrderName.ToolTip = curData["Hocsinh_Note"].ToString();

                lnkOrderName.Text = curData["Hocsinh_Name"].ToString();
                lnkOrderName.NavigateUrl = "mailto:" + curData["Hocsinh_Email"];
                lblAddress.Text = curData["Hocsinh_Address"].ToString();

                var btn_delete = (WebControl)e.Item.FindControl("btn_delete");
                btn_delete.Attributes.Add("onclick", MiscUtility.DELETE_CONFIRM);

                e.Item.Attributes.Add("onmouseover", "this.className='Hoverrow';");
                if (e.Item.ItemType == ListItemType.AlternatingItem)
                    e.Item.Attributes.Add("onmouseout", "this.className='DarkRow';");
                else
                    e.Item.Attributes.Add("onmouseout", "this.className='LightRow';");
            }
        }
    }
}