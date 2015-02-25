using System;
using System.Data;
using System.Data.SqlClient;
using iDKCMS.Library.Data;

namespace iDKCMS.Library.DataAccess
{
    public class ActiveDB
    {
        public static DataTable GetAll()
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Main_Active_GetAll", dbConn);
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
        public static void Delete(string _sessionID)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Main_Active_Delete", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@SessionID", _sessionID);
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
        public static int Insert(ActiveInfo _activeInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Main_Active_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@SessionID", _activeInfo.SessionID);
            dbCmd.Parameters.AddWithValue("@IP", _activeInfo.IP);
            dbCmd.Parameters.AddWithValue("@User_ID", _activeInfo.User_ID);
            dbCmd.Parameters.AddWithValue("@LoginTime", _activeInfo.LoginTime);
            dbCmd.Parameters.AddWithValue("@LastActiveTime", _activeInfo.LastActiveTime);
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

        public static void Update(ActiveInfo _activeInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Main_Active_Update", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@SessionID", _activeInfo.SessionID);
            dbCmd.Parameters.AddWithValue("@IP", _activeInfo.IP);
            dbCmd.Parameters.AddWithValue("@User_ID", _activeInfo.User_ID);
            dbCmd.Parameters.AddWithValue("@LoginTime", _activeInfo.LoginTime);
            dbCmd.Parameters.AddWithValue("@LastActiveTime", _activeInfo.LastActiveTime);
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

        public static ActiveInfo GetInfo(string _sessionID)
        {
            ActiveInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Main_Active_GetInfo", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@SessionID", _sessionID);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new ActiveInfo();
                    retVal.SessionID = Convert.ToString(dr["SessionID"]);
                    retVal.IP = Convert.ToString(dr["IP"]);
                    retVal.User_ID = Convert.ToInt32(dr["User_ID"]);
                    retVal.LoginTime = Convert.ToDateTime(dr["LoginTime"]);
                    retVal.LastActiveTime = Convert.ToDateTime(dr["LastActiveTime"]);
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
