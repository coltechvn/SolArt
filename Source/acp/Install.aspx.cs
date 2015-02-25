using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using iDKCMS.Library;

namespace iDKCMS.BackEnd
{
    public partial class Install : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (radFile.Checked)
                {
                    ExecuteScript(TextBox1.Text);
                }
                else if (radText.Checked)
                {
                    ExecuteScript(txtString.Text);
                }
                else
                {
                    MessageBox.Show("No Input !!");
                }
                MessageBox.Show("Success !!");
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        private void ExecuteScript(string sScriptFile)
        {
            string sScript = null;
            try
            {
                if (radFile.Checked)
                {
                    using (StreamReader file = new StreamReader(Request.MapPath(sScriptFile)))
                    {
                        sScript = file.ReadToEnd();
                        file.Close();
                    }
                }
                else
                {
                    sScript = sScriptFile;
                }
            }
            catch (FileNotFoundException)
            {
                return;
            }
            catch (Exception x)
            {
                throw new Exception("Failed to read " + sScriptFile, x);
            }

            string[] statements = Regex.Split(sScript, "\\sGO\\s", RegexOptions.IgnoreCase);

            using (SqlConnection conn = AppEnv.GetConnection)
            {
                conn.Open();

                using (SqlTransaction trans = conn.BeginTransaction(ExecuteUtility.IsolationLevel))
                {
                    foreach (string sql0 in statements)
                    {
                        string sql = sql0.Trim();

                        try
                        {
                            if (sql.ToLower().IndexOf("setuser") >= 0)
                                continue;

                            if (sql.Length > 0)
                            {
                                using (SqlCommand cmd = new SqlCommand())
                                {
                                    cmd.Transaction = trans;
                                    cmd.Connection = conn;
                                    cmd.CommandType = CommandType.Text;
                                    cmd.CommandText = sql.Trim();
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        catch (Exception x)
                        {
                            trans.Rollback();
                            throw new Exception(String.Format("FILE:\n{0}\n\nERROR:\n{2}\n\nSTATEMENT:\n{1}", sScriptFile, sql, x.Message));
                        }
                    }
                    trans.Commit();
                    conn.Close();
                }
            }
        }
    }
}