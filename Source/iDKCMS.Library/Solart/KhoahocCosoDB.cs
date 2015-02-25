using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace iDKCMS.Library.Solart
{
    public class KhoahocCosoDB
    {
        public static DataTable GetCosoDeployed(int khoahocId)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("Solart_KhoahocCoso_GetCosoDeployed", dbConn);
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

        public static bool Remover(int khoahocId, int cosoId)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Solart_KhoahocCoso_Remover", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Khoahoc_ID", khoahocId);
            dbCmd.Parameters.AddWithValue("@Coso_ID", cosoId);
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

        public static DataTable GetAll()
        {
            DataTable retVal;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_KhoahocCoso_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };
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
        public static List<KhoahocCosoInfo> GetEntitys()
        {
            var items = new List<KhoahocCosoInfo>();
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_KhoahocCoso_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };

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


        public static void Delete(int khoahoc_ID, int cosoId)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_KhoahocCoso_Delete", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Khoahoc_ID", khoahoc_ID);
            dbCmd.Parameters.AddWithValue("@Coso_ID", cosoId);
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
        public static int Insert(KhoahocCosoInfo khoahocCosoInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_KhoahocCoso_Insert", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Khoahoc_ID", khoahocCosoInfo.Khoahoc_ID);
            dbCmd.Parameters.AddWithValue("@Coso_ID", khoahocCosoInfo.Coso_ID);
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

        public static void Update(KhoahocCosoInfo khoahocCosoInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_KhoahocCoso_Update", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Khoahoc_ID", khoahocCosoInfo.Khoahoc_ID);
            dbCmd.Parameters.AddWithValue("@Coso_ID", khoahocCosoInfo.Coso_ID);
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

        public static KhoahocCosoInfo GetInfo(int khoahoc_ID, int cosoId)
        {
            KhoahocCosoInfo retVal = null;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_KhoahocCoso_GetInfo", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Khoahoc_ID", khoahoc_ID);
            dbCmd.Parameters.AddWithValue("@Coso_ID", cosoId);
            try
            {
                dbConn.Open();
                var dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new KhoahocCosoInfo();
                    retVal.Khoahoc_ID = ConvertUtility.ToInt32(dr["Khoahoc_ID"]);
                    retVal.Coso_ID = ConvertUtility.ToInt32(dr["Coso_ID"]);
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        private static KhoahocCosoInfo CreateEntityFromReader(IDataReader reader)
        {
            var item = new KhoahocCosoInfo();
            try { if (!reader.IsDBNull(reader.GetOrdinal("Khoahoc_ID"))) item.Khoahoc_ID = ConvertUtility.ToInt32(reader["Khoahoc_ID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Coso_ID"))) item.Coso_ID = ConvertUtility.ToInt32(reader["Coso_ID"]); }
            catch { }
            return item;
        }


    }
}
