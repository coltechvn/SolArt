using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace iDKCMS.Library.Solart
{
    public class HocsinhRegisterDB
    {
        public static DataTable GetKhoahoc(int hocsinhId)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Solart_Register_GetKhoahoc", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Hocsinh_ID", hocsinhId);
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

        public static DataTable GetAll()
        {
            DataTable retVal;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Register_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };
            try
            {
                retVal = new DataTable();
                var da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static List<HocsinhRegisterInfo> GetEntitys()
        {
            var items = new List<HocsinhRegisterInfo>();
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Register_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };

            try
            {
                dbConn.Open();
                IDataReader reader = dbCmd.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        var item = CreateEntityFromReader(reader);
                        items.Add(item);
                    }
                    reader.Close();
                }
            }
            finally
            {
                dbConn.Close();
            }
            return items;
        }


        public static void Delete(int hocsinh_ID, int contentid)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Register_Delete", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Hocsinh_ID", hocsinh_ID);
            dbCmd.Parameters.AddWithValue("@Content_ID", contentid);
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
        public static int Insert(HocsinhRegisterInfo hocsinhRegisterInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Register_Insert", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Hocsinh_ID", hocsinhRegisterInfo.Hocsinh_ID);
            dbCmd.Parameters.AddWithValue("@Content_ID", hocsinhRegisterInfo.Content_ID);
            dbCmd.Parameters.AddWithValue("@RegisterTime", hocsinhRegisterInfo.RegisterTime);
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

        public static void Update(HocsinhRegisterInfo hocsinhRegisterInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Register_Update", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Hocsinh_ID", hocsinhRegisterInfo.Hocsinh_ID);
            dbCmd.Parameters.AddWithValue("@Content_ID", hocsinhRegisterInfo.Content_ID);
            dbCmd.Parameters.AddWithValue("@RegisterTime", hocsinhRegisterInfo.RegisterTime);
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

        public static HocsinhRegisterInfo GetInfo(int hocsinh_ID, int contentId)
        {
            HocsinhRegisterInfo retVal = null;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Register_GetInfo", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Hocsinh_ID", hocsinh_ID);
            dbCmd.Parameters.AddWithValue("@Content_ID", contentId);
            try
            {
                dbConn.Open();
                var dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new HocsinhRegisterInfo();
                    retVal.Hocsinh_ID = ConvertUtility.ToInt32(dr["Hocsinh_ID"]);
                    retVal.Content_ID = ConvertUtility.ToInt32(dr["Content_ID"]);
                    retVal.RegisterTime = ConvertUtility.ToDateTime(dr["RegisterTime"]);
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        private static HocsinhRegisterInfo CreateEntityFromReader(IDataReader reader)
        {
            var item = new HocsinhRegisterInfo();
            try { if (!reader.IsDBNull(reader.GetOrdinal("Hocsinh_ID"))) item.Hocsinh_ID = ConvertUtility.ToInt32(reader["Hocsinh_ID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Content_ID"))) item.Content_ID = ConvertUtility.ToInt32(reader["Content_ID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("RegisterTime"))) item.RegisterTime = ConvertUtility.ToDateTime(reader["RegisterTime"]); }
            catch { }
            return item;
        }


    }
}
