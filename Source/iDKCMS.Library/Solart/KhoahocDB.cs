using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using iDKCMS.Library.Solart;

namespace iDKCMS.Library.DataAccess
{
    public class KhoahocDB
    {
        public static DataTable GetContentCount(int content_ID)
        {
            DataTable retVal = null;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Khoahoc_GetInfo", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Content_ID", content_ID);
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

        public static DataTable GetAll()
        {
            DataTable retVal;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Khoahoc_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };
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
        public static List<KhoahocInfo> GetEntitys()
        {
            var items = new List<KhoahocInfo>();
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Khoahoc_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };

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


        public static void Delete(int khoahoc_ID)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Khoahoc_Delete", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Khoahoc_ID", khoahoc_ID);
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
        public static int Insert(KhoahocInfo khoahocInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Khoahoc_Insert", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Content_ID", khoahocInfo.Content_ID);
            dbCmd.Parameters.AddWithValue("@Zone_ID", khoahocInfo.Zone_ID);
            dbCmd.Parameters.AddWithValue("@Khoehoc_NoiDungHoc", khoahocInfo.Khoehoc_NoiDungHoc);
            dbCmd.Parameters.AddWithValue("@Khoahoc_DoTuoi", khoahocInfo.Khoahoc_DoTuoi);
            dbCmd.Parameters.AddWithValue("@Khoahoc_DoTuoiText", khoahocInfo.Khoahoc_DoTuoiText);
            dbCmd.Parameters.AddWithValue("@Khoahoc_GioHoc", khoahocInfo.Khoahoc_GioHoc);
            dbCmd.Parameters.AddWithValue("@Khoahoc_KhaiGiang", khoahocInfo.Khoahoc_KhaiGiang);
            dbCmd.Parameters.AddWithValue("@Khoahoc_Avaiable", khoahocInfo.Khoahoc_Avaiable);
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

        public static void Update(KhoahocInfo khoahocInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Khoahoc_Update", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Khoahoc_ID", khoahocInfo.Khoahoc_ID);
            dbCmd.Parameters.AddWithValue("@Content_ID", khoahocInfo.Content_ID);
            dbCmd.Parameters.AddWithValue("@Zone_ID", khoahocInfo.Zone_ID);
            dbCmd.Parameters.AddWithValue("@Khoehoc_NoiDungHoc", khoahocInfo.Khoehoc_NoiDungHoc);
            dbCmd.Parameters.AddWithValue("@Khoahoc_DoTuoi", khoahocInfo.Khoahoc_DoTuoi);
            dbCmd.Parameters.AddWithValue("@Khoahoc_DoTuoiText", khoahocInfo.Khoahoc_DoTuoiText);
            dbCmd.Parameters.AddWithValue("@Khoahoc_GioHoc", khoahocInfo.Khoahoc_GioHoc);
            dbCmd.Parameters.AddWithValue("@Khoahoc_KhaiGiang", khoahocInfo.Khoahoc_KhaiGiang);
            dbCmd.Parameters.AddWithValue("@Khoahoc_Avaiable", khoahocInfo.Khoahoc_Avaiable);
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

        public static KhoahocInfo GetInfo(int contentId)
        {
            KhoahocInfo retVal = null;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Khoahoc_GetInfo", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Content_ID", contentId);
            try
            {
                dbConn.Open();
                var dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new KhoahocInfo();
                    retVal.Khoahoc_ID = ConvertUtility.ToInt32(dr["Khoahoc_ID"]);
                    retVal.Content_ID = ConvertUtility.ToInt32(dr["Content_ID"]);
                    retVal.Zone_ID = ConvertUtility.ToInt32(dr["Zone_ID"]);
                    retVal.Khoehoc_NoiDungHoc = ConvertUtility.ToString(dr["Khoehoc_NoiDungHoc"]);
                    retVal.Khoahoc_DoTuoi = ConvertUtility.ToString(dr["Khoahoc_DoTuoi"]);
                    retVal.Khoahoc_DoTuoiText = ConvertUtility.ToString(dr["Khoahoc_DoTuoiText"]);
                    retVal.Khoahoc_GioHoc = ConvertUtility.ToString(dr["Khoahoc_GioHoc"]);
                    retVal.Khoahoc_KhaiGiang = ConvertUtility.ToString(dr["Khoahoc_KhaiGiang"]);
                    retVal.Khoahoc_Avaiable = ConvertUtility.ToBoolean(dr["Khoahoc_Avaiable"]);
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        private static KhoahocInfo CreateEntityFromReader(IDataReader reader)
        {
            var item = new KhoahocInfo();
            try { if (!reader.IsDBNull(reader.GetOrdinal("Khoahoc_ID"))) item.Khoahoc_ID = ConvertUtility.ToInt32(reader["Khoahoc_ID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Content_ID"))) item.Content_ID = ConvertUtility.ToInt32(reader["Content_ID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Zone_ID"))) item.Zone_ID = ConvertUtility.ToInt32(reader["Zone_ID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Khoehoc_NoiDungHoc"))) item.Khoehoc_NoiDungHoc = ConvertUtility.ToString(reader["Khoehoc_NoiDungHoc"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Khoahoc_DoTuoi"))) item.Khoahoc_DoTuoi = ConvertUtility.ToString(reader["Khoahoc_DoTuoi"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Khoahoc_DoTuoiText"))) item.Khoahoc_DoTuoiText = ConvertUtility.ToString(reader["Khoahoc_DoTuoiText"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Khoahoc_GioHoc"))) item.Khoahoc_GioHoc = ConvertUtility.ToString(reader["Khoahoc_GioHoc"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Khoahoc_KhaiGiang"))) item.Khoahoc_KhaiGiang = ConvertUtility.ToString(reader["Khoahoc_KhaiGiang"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Khoahoc_Avaiable"))) item.Khoahoc_Avaiable = ConvertUtility.ToBoolean(reader["Khoahoc_Avaiable"]); }
            catch { }
            return item;
        }


    }
}
