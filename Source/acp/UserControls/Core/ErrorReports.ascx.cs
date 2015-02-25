using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using iDKCMS.Library;

namespace iDKCMS.BackEnd.UserControls.Core
{
    public partial class ErrorReports : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            string strSQL = "SELECT Main_ErrorReport.* FROM Main_ErrorReport ";

            if (dtgError.SortBy == "") dtgError.SortBy = "Error_Datetime";
            strSQL += " ORDER BY " + dtgError.SortBy + " " + dtgError.OrderBy;

            DataTable source = DataHelper.GetDataFromTable(strSQL);

            int curPage = dtgError.GetCurrentPageIndex() + 1;
            if (curPage > source.Rows.Count / dtgError.PageSize + ConvertUtility.ToInt32(source.Rows.Count % dtgError.PageSize > 0) && curPage > 1)
                dtgError.CurrentPageIndex = 0;

            dtgError.DataSource = source;
            dtgError.DataBind();
            lblTotal.Text = "Total: " + source.Rows.Count;
        }

        protected void dtgError_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                int id = ConvertUtility.ToInt32(e.Item.Cells[0].Text);
                try
                {
                    DataHelper.DeleteFromTable("Main_ErrorReport", "Error_ID", id);
                    lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
                }
                catch
                {
                    lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
                }
            }
        }

        protected void dtgError_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView curData = (DataRowView)e.Item.DataItem;
                e.Item.Cells[2].Text = ConvertUtility.ToString(e.Item.DataSetIndex + 1);

                HyperLink lnkUrl = (HyperLink)e.Item.FindControl("lnkUrl");
                Label lblDate = (Label)e.Item.FindControl("lblDate");
                lnkUrl.NavigateUrl = curData["Error_Url"].ToString();
                lnkUrl.Text = curData["Error_Url"].ToString();
                lblDate.Text = ConvertUtility.ToDateTime(curData["Error_Datetime"]).ToString();

                ImageButton btn_delete = (ImageButton)e.Item.FindControl("btn_delete");
                btn_delete.Attributes.Add("onclick", MiscUtility.DELETE_CONFIRM);

                e.Item.Attributes.Add("onmouseover", "this.className='Hoverrow';");
                if (e.Item.ItemType == ListItemType.AlternatingItem)
                    e.Item.Attributes.Add("onmouseout", "this.className='DarkRow';");
                else
                    e.Item.Attributes.Add("onmouseout", "this.className='LightRow';");
            }
        }

        protected void butDellChecked_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridItem item in dtgError.Items)
                {
                    CheckBox chkSelect = (CheckBox)item.FindControl("chkSelect");
                    if (chkSelect.Checked)
                    {
                        int id = ConvertUtility.ToInt32(item.Cells[0].Text);
                        DataHelper.DeleteFromTable("Main_ErrorReport", "Error_ID", id);
                    }
                }
                lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch
            {
                lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR; //ex.ToString();
            }
        }

        protected void butDelAll_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridItem item in dtgError.Items)
                {
                    int id = ConvertUtility.ToInt32(item.Cells[0].Text);
                    DataHelper.DeleteFromTable("Main_ErrorReport", "Error_ID", id);
                }
                lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch
            {
                lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR; //ex.ToString();
            }
        }
    }
}