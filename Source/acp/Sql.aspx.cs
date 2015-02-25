using System;
using System.Configuration;
using System.Data.SqlClient;
using CommonLibrary.SqlDataAccessLayer;

namespace iDKCMS.BackEnd
{
    public partial class Sql : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = null;
            var db = new DataAccess(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                db.Open();
                if (CheckBox1.Checked)
                {
                    sql = TextBox1.Text;
                    db.ExecuteNonQuery(sql);
                    Label1.Visible = true;
                    Label1.Text = "xong";
                }
                else
                {
                    sql = TextBox1.Text;
                    SqlDataReader dr = db.ExecuteReader(sql);
                    DataGrid1.DataSource = dr;
                    DataGrid1.DataBind();
                    dr.Close();
                    Label1.Visible = false;
                }
            }
#if(!DEBUG)
			catch{}
#endif
            finally
            {
                db.Close();
            }
        }
    }
}