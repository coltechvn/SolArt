using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iDKCMS.Library.Data;

namespace iDKCMS.Library.DataAccess
{
    public class DownloadDB
    {
        public static DataTable GetAll()
        {
            DataTable retVal;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Download_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };
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
        public static List<DownloadInfo> GetEntitys()
        {
            var items = new List<DownloadInfo>();
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Download_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };

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


        public static void Delete(int download_ID)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Download_Delete", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Download_ID", download_ID);
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
        public static int Insert(DownloadInfo downloadInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Download_Insert", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Download_Name", downloadInfo.Download_Name);
            dbCmd.Parameters.AddWithValue("@Download_Description", downloadInfo.Download_Description);
            dbCmd.Parameters.AddWithValue("@Download_File", downloadInfo.Download_File);
            dbCmd.Parameters.AddWithValue("@Download_Extension", downloadInfo.Download_Extension);
            dbCmd.Parameters.AddWithValue("@Download_Visible", downloadInfo.Download_Visible);
            dbCmd.Parameters.AddWithValue("@Download_CreateDate", downloadInfo.Download_CreateDate);
            dbCmd.Parameters.AddWithValue("@Download_FileSize", downloadInfo.Download_FileSize);
            dbCmd.Parameters.AddWithValue("@Download_View", downloadInfo.Download_View);
            dbCmd.Parameters.AddWithValue("@User_ID", downloadInfo.User_ID);
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

        public static void Update(DownloadInfo downloadInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Download_Update", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Download_ID", downloadInfo.Download_ID);
            dbCmd.Parameters.AddWithValue("@Download_Name", downloadInfo.Download_Name);
            dbCmd.Parameters.AddWithValue("@Download_Description", downloadInfo.Download_Description);
            dbCmd.Parameters.AddWithValue("@Download_File", downloadInfo.Download_File);
            dbCmd.Parameters.AddWithValue("@Download_Extension", downloadInfo.Download_Extension);
            dbCmd.Parameters.AddWithValue("@Download_Visible", downloadInfo.Download_Visible);
            dbCmd.Parameters.AddWithValue("@Download_CreateDate", downloadInfo.Download_CreateDate);
            dbCmd.Parameters.AddWithValue("@Download_FileSize", downloadInfo.Download_FileSize);
            dbCmd.Parameters.AddWithValue("@Download_View", downloadInfo.Download_View);
            dbCmd.Parameters.AddWithValue("@User_ID", downloadInfo.User_ID);
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

        public static DownloadInfo GetInfo(int download_ID)
        {
            DownloadInfo retVal = null;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Download_GetInfo", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Download_ID", download_ID);
            try
            {
                dbConn.Open();
                var dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new DownloadInfo();
                    retVal.Download_ID = ConvertUtility.ToInt32(dr["Download_ID"]);
                    retVal.Download_Name = ConvertUtility.ToString(dr["Download_Name"]);
                    retVal.Download_Description = ConvertUtility.ToString(dr["Download_Description"]);
                    retVal.Download_File = ConvertUtility.ToString(dr["Download_File"]);
                    retVal.Download_Extension = ConvertUtility.ToString(dr["Download_Extension"]);
                    retVal.Download_Visible = ConvertUtility.ToBoolean(dr["Download_Visible"]);
                    retVal.Download_CreateDate = ConvertUtility.ToDateTime(dr["Download_CreateDate"]);
                    retVal.Download_FileSize = ConvertUtility.ToDouble(dr["Download_FileSize"]);
                    retVal.Download_View = ConvertUtility.ToInt32(dr["Download_View"]);
                    retVal.User_ID = ConvertUtility.ToInt32(dr["User_ID"]);
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        private static DownloadInfo CreateEntityFromReader(IDataReader reader)
        {
            var item = new DownloadInfo();
            try { if (!reader.IsDBNull(reader.GetOrdinal("Download_ID"))) item.Download_ID = ConvertUtility.ToInt32(reader["Download_ID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Download_Name"))) item.Download_Name = ConvertUtility.ToString(reader["Download_Name"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Download_Description"))) item.Download_Description = ConvertUtility.ToString(reader["Download_Description"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Download_File"))) item.Download_File = ConvertUtility.ToString(reader["Download_File"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Download_Extension"))) item.Download_Extension = ConvertUtility.ToString(reader["Download_Extension"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Download_Visible"))) item.Download_Visible = ConvertUtility.ToBoolean(reader["Download_Visible"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Download_CreateDate"))) item.Download_CreateDate = ConvertUtility.ToDateTime(reader["Download_CreateDate"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Download_FileSize"))) item.Download_FileSize = ConvertUtility.ToDouble(reader["Download_FileSize"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Download_View"))) item.Download_View = ConvertUtility.ToInt32(reader["Download_View"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("User_ID"))) item.User_ID = ConvertUtility.ToInt32(reader["User_ID"]); }
            catch { }
            return item;
        }


    }
}
