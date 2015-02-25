using System.Web.UI;
using iDKCMS.Library.Data;

namespace iDKCMS.Library.WebBase
{
	public class AdminControl : UserControl
	{
		private AdminPage CurrentPage
		{
			get { return (AdminPage) this.Page; }
		}

		protected UserInfo CurrentAdminInfo
		{
			get { return CurrentPage.CurrentAdminInfo; }
		}
	}
}