using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using iDKCMS.Library.Data;

namespace iDKCMS.Library.DataAccess
{
    public class ContentImageDB
    {
        public static int GetQuantityImageOfContent(int contentId)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_ContentImage_GetQuantityImageOfContent", dbConn);
            dbCmd.Parameters.AddWithValue("@ContentID", contentId);
            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read()) return dr.GetInt32(0);
                else return 0;
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
            var dbCmd = new SqlCommand("CMS_ContentImage_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };
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
        public static List<ContentImageInfo> GetEntitys()
        {
            var items = new List<ContentImageInfo>();
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_ContentImage_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };

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


        public static void Delete(int contentId, int imageId)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_ContentImage_Delete", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Content_ID", contentId);
            dbCmd.Parameters.AddWithValue("@Image_ID", imageId);
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
        public static void Insert(ContentImageInfo contentImageInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_ContentImage_Insert", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Content_ID", contentImageInfo.Content_ID);
            dbCmd.Parameters.AddWithValue("@Image_ID", contentImageInfo.Image_ID);
            dbCmd.Parameters.AddWithValue("@IsCover", contentImageInfo.IsCover);
            dbCmd.Parameters.AddWithValue("@Priority", contentImageInfo.Priority);
            dbCmd.Parameters.AddWithValue("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
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

        public static void Update(ContentImageInfo contentImageInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_ContentImage_Update", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Content_ID", contentImageInfo.Content_ID);
            dbCmd.Parameters.AddWithValue("@Image_ID", contentImageInfo.Image_ID);
            dbCmd.Parameters.AddWithValue("@IsCover", contentImageInfo.IsCover);
            dbCmd.Parameters.AddWithValue("@Priority", contentImageInfo.Priority);
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

        public static ContentImageInfo GetInfo(int contentId, int imageId)
        {
            ContentImageInfo retVal = null;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_ContentImage_GetInfo", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Content_ID", contentId);
            dbCmd.Parameters.AddWithValue("@Image_ID", imageId);
            try
            {
                dbConn.Open();
                var dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new ContentImageInfo();
                    retVal.Content_ID = ConvertUtility.ToInt32(dr["Content_ID"]);
                    retVal.Image_ID = ConvertUtility.ToInt32(dr["Image_ID"]);
                    retVal.IsCover = ConvertUtility.ToBoolean(dr["IsCover"]);
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

        private static ContentImageInfo CreateEntityFromReader(IDataReader reader)
        {
            var item = new ContentImageInfo();
            try { if (!reader.IsDBNull(reader.GetOrdinal("Content_ID"))) item.Content_ID = ConvertUtility.ToInt32(reader["Content_ID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Image_ID"))) item.Image_ID = ConvertUtility.ToInt32(reader["Image_ID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("IsCover"))) item.IsCover = ConvertUtility.ToBoolean(reader["IsCover"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Priority"))) item.Priority = ConvertUtility.ToInt32(reader["Priority"]); }
            catch { }
            return item;
        }
 

    }
}