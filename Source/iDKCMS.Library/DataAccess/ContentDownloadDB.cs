/* This code has generator by EM Group Utilities 
* E-mail:	buiphuongdong@gmail.com 
* Tel: (84)+ 98 999 1925 
*  */

using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iDKCMS.Library.Data;

namespace iDKCMS.Library.DataAccess
{
    public class ContentDownloadDB
    {
        public static DataTable GetAll()
        {
            DataTable retVal;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_ContentDownload_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };
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
        public static List<ContentDownloadInfo> GetEntitys()
        {
            var items = new List<ContentDownloadInfo>();
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_ContentDownload_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };

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


        public static void Delete(int content_ID, int downloadId)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_ContentDownload_Delete", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Content_ID", content_ID);
            dbCmd.Parameters.AddWithValue("@Download_ID", downloadId);
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
        public static int Insert(ContentDownloadInfo contentDownloadInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_ContentDownload_Insert", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Content_ID", contentDownloadInfo.Content_ID);
            dbCmd.Parameters.AddWithValue("@Download_ID", contentDownloadInfo.Download_ID);
            dbCmd.Parameters.AddWithValue("@Priority", contentDownloadInfo.Priority);
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

        public static void Update(ContentDownloadInfo contentDownloadInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_ContentDownload_Update", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Content_ID", contentDownloadInfo.Content_ID);
            dbCmd.Parameters.AddWithValue("@Download_ID", contentDownloadInfo.Download_ID);
            dbCmd.Parameters.AddWithValue("@Priority", contentDownloadInfo.Priority);
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

        public static ContentDownloadInfo GetInfo(int content_ID, int downloadId)
        {
            ContentDownloadInfo retVal = null;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_ContentDownload_GetInfo", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Content_ID", content_ID);
            dbCmd.Parameters.AddWithValue("@Download_ID", downloadId);
            try
            {
                dbConn.Open();
                var dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new ContentDownloadInfo();
                    retVal.Content_ID = ConvertUtility.ToInt32(dr["Content_ID"]);
                    retVal.Download_ID = ConvertUtility.ToInt32(dr["Download_ID"]);
                    retVal.Priority = ConvertUtility.ToInt32(dr["Priority"]);
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        private static ContentDownloadInfo CreateEntityFromReader(IDataReader reader)
        {
            var item = new ContentDownloadInfo();
            try { if (!reader.IsDBNull(reader.GetOrdinal("Content_ID"))) item.Content_ID = ConvertUtility.ToInt32(reader["Content_ID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Download_ID"))) item.Download_ID = ConvertUtility.ToInt32(reader["Download_ID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Priority"))) item.Priority = ConvertUtility.ToInt32(reader["Priority"]); }
            catch { }
            return item;
        }


    }
}
