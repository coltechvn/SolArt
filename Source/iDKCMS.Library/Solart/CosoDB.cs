using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace iDKCMS.Library.Solart
{
    public class CosoDB
    {
        public static string GetNameByID(int cosoId)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("Solart_Coso_GetNameByID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Coso_ID", cosoId);
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
            var dbCmd = new SqlCommand("Solart_Coso_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };
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
        public static List<CosoInfo> GetEntitys()
        {
            var items = new List<CosoInfo>();
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Coso_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };

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


        public static void Delete(int coso_ID)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Coso_Delete", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Coso_ID", coso_ID);
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
        public static int Insert(CosoInfo cosoInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Coso_Insert", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Coso_Name", cosoInfo.Coso_Name);
            dbCmd.Parameters.AddWithValue("@Coso_Info", cosoInfo.Coso_Info);
            dbCmd.Parameters.AddWithValue("@Coso_Map", cosoInfo.Coso_Map);
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

        public static void Update(CosoInfo cosoInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Coso_Update", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Coso_ID", cosoInfo.Coso_ID);
            dbCmd.Parameters.AddWithValue("@Coso_Name", cosoInfo.Coso_Name);
            dbCmd.Parameters.AddWithValue("@Coso_Info", cosoInfo.Coso_Info);
            dbCmd.Parameters.AddWithValue("@Coso_Map", cosoInfo.Coso_Map);
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

        public static CosoInfo GetInfo(int coso_ID)
        {
            CosoInfo retVal = null;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Coso_GetInfo", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Coso_ID", coso_ID);
            try
            {
                dbConn.Open();
                var dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new CosoInfo();
                    retVal.Coso_ID = ConvertUtility.ToInt32(dr["Coso_ID"]);
                    retVal.Coso_Name = ConvertUtility.ToString(dr["Coso_Name"]);
                    retVal.Coso_Info = ConvertUtility.ToString(dr["Coso_Info"]);
                    retVal.Coso_Map = ConvertUtility.ToString(dr["Coso_Map"]);
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        private static CosoInfo CreateEntityFromReader(IDataReader reader)
        {
            var item = new CosoInfo();
            try { if (!reader.IsDBNull(reader.GetOrdinal("Coso_ID"))) item.Coso_ID = ConvertUtility.ToInt32(reader["Coso_ID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Coso_Name"))) item.Coso_Name = ConvertUtility.ToString(reader["Coso_Name"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Coso_Info"))) item.Coso_Info = ConvertUtility.ToString(reader["Coso_Info"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Coso_Map"))) item.Coso_Map = ConvertUtility.ToString(reader["Coso_Map"]); }
            catch { }
            return item;
        }


    }
}
