using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace iDKCMS.Library
{
    public class HTMLUtility
    {
        public static string SecureHTML(string strInput)
        {
            strInput = strInput.Replace("&acute;", "'");
            strInput = strInput.Replace("&quot;", "\"");
            strInput = strInput.Replace("&lt;", "&amp;lt;");
            strInput = strInput.Replace("&gt;", "&amp;gt;");
            strInput = strInput.Replace("<", "&lt;");
            strInput = strInput.Replace(">", "&gt;");
            return strInput;
        }

        public static string ReplaceTag(string strInput)
        {
            string strPattern = @"(?<url>http://(?:[\w-]+\.)+[\w-]+(?:/[\w-./?%&~=]*[^.\s|,|\)|!])?)";
            string strReplace = "<a href=\"${url}\" target=_blank>${url}</a>";
            string data = strInput;

            strInput = Regex.Replace(strInput, strPattern, strReplace);
            strPattern = @"(?<!http://)(?<url>www\.(?:[\w-]+\.)+[\w-]+(?:/[\w-./?%&~=]*[^.\s|,|\)|!])?)";
            strReplace = "<a href=\"http://${url}\" target=_blank>${url}</a>";
            data = Regex.Replace(data, strPattern, strReplace);

            strPattern = @"(?<url>\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*?)";
            strReplace = "<a href=\"mailto:${url}\">${url}</a>";
            data = Regex.Replace(data, strPattern, strReplace);

            data = data.Replace("\n", "<br />");

            return data;
        }

        public static string OptimizeHtml(string content)
        {
            string retVal = content.Replace("\t", "");
            retVal = retVal.Replace("\r\n", " ");
            return retVal;
        }

        public static string OutputHTML(string strInput)
        {
            return HttpUtility.HtmlEncode(strInput);
        }

        public static void ReturnHTMLEncodeForDataGrid(DataGrid dtg)
        {
            int rowcount = dtg.Items.Count;
            int colcount = dtg.Columns.Count;
            for (int i = 0; i <= rowcount - 1; i++)
                for (int j = 0; j <= colcount - 1; j++)
                {
                    string strCellVal = dtg.Items[i].Cells[j].Text;
                    if (!strCellVal.Equals(string.Empty))
                    {
                        strCellVal = OutputHTML(strCellVal);
                        dtg.Items[i].Cells[j].Text = strCellVal;
                    }
                }
        }
    }
}