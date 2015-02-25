using System;
using System.Web.UI;
using iDKCMS.Library;

namespace iDKCMS.BackEnd.UserControls.Controls
{
    public partial class SelectDate : UserControl
    {
        public DateTime GetDate()
        {
            return new DateTime(Convert.ToInt32(dropYear.SelectedValue), Convert.ToInt32(dropMonth.SelectedValue), Convert.ToInt32(dropDay.SelectedValue));
        }

        public void SetDate(DateTime date)
        {
            dropDay.SelectedIndex = -1;
            dropMonth.SelectedIndex = -1;
            dropYear.SelectedIndex = -1;
            MiscUtility.SetSelected(dropDay.Items, date.Day.ToString());
            MiscUtility.SetSelected(dropMonth.Items, date.Month.ToString());
            MiscUtility.SetSelected(dropYear.Items, date.Year.ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MiscUtility.FillIndex(dropDay, 1, 31, DateTime.Now.Day);
                MiscUtility.FillIndex(dropMonth, 1, 12, DateTime.Now.Month);
                MiscUtility.FillIndex(dropYear, DateTime.Now.Year, DateTime.Now.Year + 15, DateTime.Now.Year);
            }
        }
    }
}