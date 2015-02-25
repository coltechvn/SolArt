using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iDKCMS.WebControls
{
	public class NewDataGrid : DataGrid
	{
		public string SortBy
		{
			get 
			{
				if (ViewState["SortBy"] != null) return ViewState["SortBy"].ToString();
				else return "";
			}
			set { ViewState["SortBy"] = value;}
		}
		public string OrderBy
		{
			get 
			{
				if (ViewState["OrderBy"] != null) return ViewState["OrderBy"].ToString();
				else return "DESC";
			}
			set { ViewState["OrderBy"] = value;}
		}

		public int GetCurrentPageIndex()
		{
			return this.CurrentPageIndex;
			if (HttpContext.Current.Request.QueryString["page"] == null) return 0;
			else
			{
				int retVal = 0;
				try
				{
					retVal = Convert.ToInt32(HttpContext.Current.Request.QueryString["page"]);
				}
				catch
				{
					retVal = 0;
				}
				if (retVal > 0) retVal -= 1;
				else retVal = 0;
				return retVal;
			}
		}

		private string ChangePageIndex(int _newPageIndex)
		{
			if (HttpContext.Current.Request.QueryString["page"] == null)
			{
				string retVal = HttpContext.Current.Request.RawUrl;
				if (retVal.IndexOf("?") >= 0) retVal += "&page=" + _newPageIndex.ToString();
				else retVal += "?" + "page=" + _newPageIndex.ToString();
				return retVal;
			}
			else
			{
				string retVal = HttpContext.Current.Request.RawUrl;
				retVal = retVal.Replace("page=" + HttpContext.Current.Request.QueryString["page"], "page=" + _newPageIndex.ToString());
				return retVal;
			}
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			this.CurrentPageIndex = GetCurrentPageIndex();
			this.PageIndexChanged += new DataGridPageChangedEventHandler(DataGrid_PageIndexChanged);
			this.ItemCreated += new DataGridItemEventHandler(DataGrid_ItemCreated);
		}
		private void DataGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.CurrentPageIndex = e.NewPageIndex;
			//this.Page.Response.Redirect(ChangePageIndex(e.NewPageIndex + 1));
		}

		private void DataGrid_ItemCreated(object sender, DataGridItemEventArgs e)
		{
			if (e.Item.ItemType != ListItemType.Pager) return;
			if (this.PagerStyle.Mode == PagerMode.NumericPages)
				foreach (Control control in e.Item.Cells[0].Controls)
				{
					if (control.GetType().ToString() == "System.Web.UI.WebControls.DataGridLinkButton")
					{
						LinkButton lnk = (LinkButton) control;
						lnk.Text = "| " + lnk.Text + " |";
						lnk.CssClass = "link";
					}
					if (control.GetType().ToString() == "System.Web.UI.WebControls.Label")
					{
						Label lbl = (Label) control;
						lbl.Text = lbl.Text; // trang
					}
				}
		}
		protected override void OnSortCommand(DataGridSortCommandEventArgs e)
		{
			base.OnSortCommand (e);
			if (SortBy == e.SortExpression)
			{
				if (OrderBy == "ASC") OrderBy = "DESC";
				else OrderBy = "ASC";
			}
			else
			{
				SortBy = e.SortExpression;
				OrderBy = "ASC";
			}
			this.EditItemIndex = -1;
		}
	}
}