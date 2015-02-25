using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iDKCMS.Library.Data;

namespace iDKCMS.Library.DataAccess
{
    public class ContentVideoDB
    {
        public static DataTable GetAll()
        {
            DataTable retVal;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_ContentVideo_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };
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
        public static List<ContentVideoInfo> GetEntitys()
        {
            var items = new List<ContentVideoInfo>();
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_ContentVideo_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };

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


        public static void Delete(int content_ID, int videoId)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_ContentVideo_Delete", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Content_ID", content_ID);
            dbCmd.Parameters.AddWithValue("@Video_ID", videoId);
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
        public static int Insert(ContentVideoInfo contentVideoInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_ContentVideo_Insert", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Content_ID", contentVideoInfo.Content_ID);
            dbCmd.Parameters.AddWithValue("@Video_ID", contentVideoInfo.Video_ID);
            dbCmd.Parameters.AddWithValue("@Priority", contentVideoInfo.Priority);
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

        public static void Update(ContentVideoInfo contentVideoInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_ContentVideo_Update", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Content_ID", contentVideoInfo.Content_ID);
            dbCmd.Parameters.AddWithValue("@Video_ID", contentVideoInfo.Video_ID);
            dbCmd.Parameters.AddWithValue("@Priority", contentVideoInfo.Priority);
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

        public static ContentVideoInfo GetInfo(int content_ID, int videoId)
        {
            ContentVideoInfo retVal = null;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_ContentVideo_GetInfo", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Content_ID", content_ID);
            dbCmd.Parameters.AddWithValue("@Video_ID", videoId);
            try
            {
                dbConn.Open();
                var dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new ContentVideoInfo();
                    retVal.Content_ID = ConvertUtility.ToInt32(dr["Content_ID"]);
                    retVal.Video_ID = ConvertUtility.ToInt32(dr["Video_ID"]);
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

        private static ContentVideoInfo CreateEntityFromReader(IDataReader reader)
        {
            var item = new ContentVideoInfo();
            try { if (!reader.IsDBNull(reader.GetOrdinal("Content_ID"))) item.Content_ID = ConvertUtility.ToInt32(reader["Content_ID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Video_ID"))) item.Video_ID = ConvertUtility.ToInt32(reader["Video_ID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Priority"))) item.Priority = ConvertUtility.ToInt32(reader["Priority"]); }
            catch { }
            return item;
        }


    }
}
