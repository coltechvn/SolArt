using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iDKCMS.Library.Solart
{
    public class KhoahocMonhocDB
    {
        public static bool Insert(int khoahocId, int monhocId)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_KhoahocMonhoc_Insert", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Khoahoc_ID", khoahocId);
            dbCmd.Parameters.AddWithValue("@Monhoc_ID", monhocId);
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
                return true;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public static bool Remover(int khoahocId, int monhocId)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Solart_KhoahocMonhoc_Remover", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Khoahoc_ID", khoahocId);
            dbCmd.Parameters.AddWithValue("@Monhoc_ID", monhocId);
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
                return true;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public static DataTable GetMonhocDeployed(int khoahocId)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("Solart_KhoahocMonhoc_GetMonhocDeployed", dbConn);
            dbCmd.Parameters.AddWithValue("@Khoahoc_ID", khoahocId);
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
    }
}