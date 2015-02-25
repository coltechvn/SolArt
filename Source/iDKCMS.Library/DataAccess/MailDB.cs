using System;
using System.Data;
using System.Data.SqlClient;
using iDKCMS.Library.Data;

namespace iDKCMS.Library.DataAccess
{
    public class MailDB
    {
        public static DataTable GetAll()
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Main_Mail_GetAll", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static void Delete(int _mail_ID)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Main_Mail_Delete", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Mail_ID", _mail_ID);
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
            }
            finally
            {
                dbConn.Close();
            }
        }
        public static int Insert(MailInfo _mailInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Main_Mail_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Mail_Kind", _mailInfo.Mail_Kind);
            dbCmd.Parameters.AddWithValue("@Mail_Name", _mailInfo.Mail_Name);
            dbCmd.Parameters.AddWithValue("@Mail_Email", _mailInfo.Mail_Email);
            dbCmd.Parameters.AddWithValue("@Mail_Phone", _mailInfo.Mail_Phone);
            dbCmd.Parameters.AddWithValue("@Mail_Address", _mailInfo.Mail_Address);
            dbCmd.Parameters.AddWithValue("@Mail_Content", _mailInfo.Mail_Content);
            dbCmd.Parameters.AddWithValue("@Pix_ID", _mailInfo.Pix_ID);
            dbCmd.Parameters.AddWithValue("@Mail_Answer", _mailInfo.Mail_Answer);
            dbCmd.Parameters.AddWithValue("@Mail_Datetime", _mailInfo.Mail_Datetime);
            dbCmd.Parameters.AddWithValue("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
                return (int)dbCmd.Parameters["@RETURN_VALUE"].Value;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public static void Update(MailInfo _mailInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Main_Mail_Update", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Mail_ID", _mailInfo.Mail_ID);
            dbCmd.Parameters.AddWithValue("@Mail_Kind", _mailInfo.Mail_Kind);
            dbCmd.Parameters.AddWithValue("@Mail_Name", _mailInfo.Mail_Name);
            dbCmd.Parameters.AddWithValue("@Mail_Email", _mailInfo.Mail_Email);
            dbCmd.Parameters.AddWithValue("@Mail_Phone", _mailInfo.Mail_Phone);
            dbCmd.Parameters.AddWithValue("@Mail_Address", _mailInfo.Mail_Address);
            dbCmd.Parameters.AddWithValue("@Mail_Content", _mailInfo.Mail_Content);
            dbCmd.Parameters.AddWithValue("@Pix_ID", _mailInfo.Pix_ID);
            dbCmd.Parameters.AddWithValue("@Mail_Answer", _mailInfo.Mail_Answer);
            dbCmd.Parameters.AddWithValue("@Mail_Datetime", _mailInfo.Mail_Datetime);
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
            }
            finally
            {
                dbConn.Close();
            }
        }

        public static MailInfo GetInfo(int _mail_ID)
        {
            MailInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Main_Mail_GetInfo", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Mail_ID", _mail_ID);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new MailInfo();
                    retVal.Mail_ID = Convert.ToInt32(dr["Mail_ID"]);
                    retVal.Mail_Kind = Convert.ToString(dr["Mail_Kind"]);
                    retVal.Mail_Name = Convert.ToString(dr["Mail_Name"]);
                    retVal.Mail_Email = Convert.ToString(dr["Mail_Email"]);
                    retVal.Mail_Phone = Convert.ToString(dr["Mail_Phone"]);
                    retVal.Mail_Address = Convert.ToString(dr["Mail_Address"]);
                    retVal.Mail_Content = Convert.ToString(dr["Mail_Content"]);
                    retVal.Pix_ID = Convert.ToInt32(dr["Pix_ID"]);
                    retVal.Mail_Answer = Convert.ToBoolean(dr["Mail_Answer"]);
                    retVal.Mail_Datetime = Convert.ToDateTime(dr["Mail_Datetime"]);
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
    }
}
