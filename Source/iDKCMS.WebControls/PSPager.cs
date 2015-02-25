using System;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace iDKCMS.WebControls
{
    public class PSPager: Literal
    {
        private int _pagesize;
        public int PageSize
        {
            get { return _pagesize; }
            set { _pagesize = value; }
        }

        private int _dataSource;
        public int DataSource
        {
            get { return _dataSource; }
            set { _dataSource = value; }
        }

        private string _queryString;
        public string QueryString
        {
            get { return _queryString; }
            set { _queryString = value; }
        }

        private string _pageText;
        public string PageText
        {
            get { return _pageText; }
            set { _pageText = value; }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnInit(e);

            if (QueryString == null) QueryString = "page";
            if (PageText == null) PageText = "Trang: ";

            string curURL = HttpContext.Current.Request.RawUrl;
            string strPage = HttpContext.Current.Request.QueryString[QueryString];

            // xac dinh su dung & hay ?
            string sep = "&";
            if(!curURL.Contains("?"))
            {
                sep = "?";
            }

            // viet lai url neu ton tai page
            int page = 1;
            if (strPage != null)
            {
                page = int.Parse(strPage);

                curURL = curURL.Replace(sep + QueryString + "=" + page, "");
            }

            // khoi tao chuoi
            StringBuilder sb = new StringBuilder();

            int totalPage = (DataSource + (PageSize - 1)) / PageSize; // xac dinh so luong trang
            int min = page - 5; // khoang cach tu trang hien tai sang trai
            min = (min <= 0) ? 1 : min;
            int max = min + 14; // khoang cach tu trang hien tai sang phai
            max = max > totalPage ? totalPage : max;

            // text dau dong
            sb.Append(@PageText);

            // trang dau
            if (min > 1)
            {
                sb.Append(@"<a href='");
                sb.Append(curURL);
                sb.Append(sep + QueryString + "=1'>| 1 |</a> ...");
            }

            // cac trang o giua
            for (int i = min; i <= max; i++)
            {
                if (i != page)
                {
                    sb.Append(@"<a href='");
                    sb.Append(curURL);
                    sb.Append(sep + QueryString + "=");
                    sb.Append(i);
                    sb.Append("'>");
                }

                // Trang hien tai
                if (i == page)
                {
                    sb.Append("| <b>");
                    sb.Append(i);
                    sb.Append("</b> | ");
                }
                else
                {
                    sb.Append("| ");
                    sb.Append(i);
                    sb.Append(" |");
                }

                if (i != page)
                {
                    sb.Append("</a> ");
                }
            }

            // trang cuoi
            if (max < totalPage)
            {
                sb.Append(@" ... <a href='");
                sb.Append(curURL);
                sb.Append(sep + QueryString + "=");
                sb.Append(totalPage);
                sb.Append("'>");
                sb.Append("| ");
                sb.Append(totalPage);
                sb.Append(" |");
                sb.Append("</a>");
            }

            // xuat chuoi ra
            Text = sb.ToString();
        }
    }
}
