using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace iDKCMS.Library.Solart
{
    public class MonhocDB
    {
        public static string GetNameByID(int monhocID)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("Solart_Monhoc_GetNameByID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Monhoc_ID", monhocID);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                    return dr.GetString(0);
                else
                    return string.Empty;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public static DataTable GetAll()
        {
            DataTable retVal;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Monhoc_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };
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
        public static List<MonhocInfo> GetEntitys()
        {
            var items = new List<MonhocInfo>();
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Monhoc_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };

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


        public static void Delete(int monhoc_ID)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Monhoc_Delete", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Monhoc_ID", monhoc_ID);
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
        public static int Insert(MonhocInfo monhocInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Monhoc_Insert", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Monhoc_Name", monhocInfo.Monhoc_Name);
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

        public static void Update(MonhocInfo monhocInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Monhoc_Update", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Monhoc_ID", monhocInfo.Monhoc_ID);
            dbCmd.Parameters.AddWithValue("@Monhoc_Name", monhocInfo.Monhoc_Name);
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

        public static MonhocInfo GetInfo(int monhoc_ID)
        {
            MonhocInfo retVal = null;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Monhoc_GetInfo", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Monhoc_ID", monhoc_ID);
            try
            {
                dbConn.Open();
                var dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new MonhocInfo();
                    retVal.Monhoc_ID = ConvertUtility.ToInt32(dr["Monhoc_ID"]);
                    retVal.Monhoc_Name = ConvertUtility.ToString(dr["Monhoc_Name"]);
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        private static MonhocInfo CreateEntityFromReader(IDataReader reader)
        {
            var item = new MonhocInfo();
            try { if (!reader.IsDBNull(reader.GetOrdinal("Monhoc_ID"))) item.Monhoc_ID = ConvertUtility.ToInt32(reader["Monhoc_ID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Monhoc_Name"))) item.Monhoc_Name = ConvertUtility.ToString(reader["Monhoc_Name"]); }
            catch { }
            return item;
        }


    }
}
