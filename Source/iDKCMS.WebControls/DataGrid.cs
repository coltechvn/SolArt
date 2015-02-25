using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iDKCMS.WebControls
{
	
	public class DataGrid : System.Web.UI.WebControls.DataGrid
	{
		private int GetCurrentPageIndex()
		{
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
			this.Page.Response.Redirect(ChangePageIndex(e.NewPageIndex + 1));
		}

		private void DataGrid_ItemCreated(object sender, DataGridItemEventArgs e)
		{
			if (e.Item.ItemType != ListItemType.Pager) return;
			foreach (Control control in e.Item.Cells[0].Controls)
			{
				if (control.GetType().ToString() == "System.Web.UI.WebControls.DataGridLinkButton")
				{
					LinkButton lnk = (LinkButton) control;
					lnk.Text = "| " + lnk.Text + " |";
				}
				if (control.GetType().ToString() == "System.Web.UI.WebControls.Label")
				{
					Label lbl = (Label) control;
					lbl.Text = "&nbsp;Trang: " + lbl.Text;
				}
			}
		}
	}
}