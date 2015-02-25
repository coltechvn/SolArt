using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iDKCMS.Library.Data;

namespace iDKCMS.Library.DataAccess
{
    public class ImageDB
    {
        public static ImageInfo GetCover(int contentId)
        {
            ImageInfo retVal = null;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Images_GetCover", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Content_ID", contentId);
            try
            {
                dbConn.Open();
                var dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new ImageInfo();
                    retVal.Image_ID = ConvertUtility.ToInt32(dr["Image_ID"]);
                    retVal.Image_Name = ConvertUtility.ToString(dr["Image_Name"]);
                    retVal.Image_Description = ConvertUtility.ToString(dr["Image_Description"]);
                    retVal.Image_File = ConvertUtility.ToString(dr["Image_File"]);
                    retVal.Image_CreateDate = ConvertUtility.ToDateTime(dr["Image_CreateDate"]);
                    retVal.Image_FileSize = ConvertUtility.ToDouble(dr["Image_FileSize"]);
                    retVal.Image_Width = ConvertUtility.ToInt32(dr["Image_Width"]);
                    retVal.Image_Height = ConvertUtility.ToInt32(dr["Image_Height"]);
                    retVal.Image_View = ConvertUtility.ToInt32(dr["Image_View"]);
                    retVal.User_ID = ConvertUtility.ToInt32(dr["User_ID"]);
                    retVal.Image_Visible = ConvertUtility.ToBoolean(dr["Image_Visible"]);
                }
                if (dr != null) dr.Close();
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
            var dbCmd = new SqlCommand("CMS_Images_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };
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
        public static List<ImageInfo> GetEntitys()
        {
            var items = new List<ImageInfo>();
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Images_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };

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


        public static void Delete(int image_ID)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Images_Delete", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Image_ID", image_ID);
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
        public static int Insert(ImageInfo imageInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Images_Insert", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Image_Name", imageInfo.Image_Name);
            dbCmd.Parameters.AddWithValue("@Image_Description", imageInfo.Image_Description);
            dbCmd.Parameters.AddWithValue("@Image_File", imageInfo.Image_File);
            dbCmd.Parameters.AddWithValue("@Image_CreateDate", imageInfo.Image_CreateDate);
            dbCmd.Parameters.AddWithValue("@Image_FileSize", imageInfo.Image_FileSize);
            dbCmd.Parameters.AddWithValue("@Image_Width", imageInfo.Image_Width);
            dbCmd.Parameters.AddWithValue("@Image_Height", imageInfo.Image_Height);
            dbCmd.Parameters.AddWithValue("@Image_View", imageInfo.Image_View);
            dbCmd.Parameters.AddWithValue("@User_ID", imageInfo.User_ID);
            dbCmd.Parameters.AddWithValue("@Image_Visible", imageInfo.Image_Visible);
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

        public static void Update(ImageInfo imageInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Images_Update", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Image_ID", imageInfo.Image_ID);
            dbCmd.Parameters.AddWithValue("@Image_Name", imageInfo.Image_Name);
            dbCmd.Parameters.AddWithValue("@Image_Description", imageInfo.Image_Description);
            dbCmd.Parameters.AddWithValue("@Image_File", imageInfo.Image_File);
            dbCmd.Parameters.AddWithValue("@Image_CreateDate", imageInfo.Image_CreateDate);
            dbCmd.Parameters.AddWithValue("@Image_FileSize", imageInfo.Image_FileSize);
            dbCmd.Parameters.AddWithValue("@Image_Width", imageInfo.Image_Width);
            dbCmd.Parameters.AddWithValue("@Image_Height", imageInfo.Image_Height);
            dbCmd.Parameters.AddWithValue("@Image_View", imageInfo.Image_View);
            dbCmd.Parameters.AddWithValue("@User_ID", imageInfo.User_ID);
            dbCmd.Parameters.AddWithValue("@Image_Visible", imageInfo.Image_Visible);
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

        public static ImageInfo GetInfo(int image_ID)
        {
            ImageInfo retVal = null;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Images_GetInfo", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Image_ID", image_ID);
            try
            {
                dbConn.Open();
                var dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new ImageInfo();
                    retVal.Image_ID = ConvertUtility.ToInt32(dr["Image_ID"]);
                    retVal.Image_Name = ConvertUtility.ToString(dr["Image_Name"]);
                    retVal.Image_Description = ConvertUtility.ToString(dr["Image_Description"]);
                    retVal.Image_File = ConvertUtility.ToString(dr["Image_File"]);
                    retVal.Image_CreateDate = ConvertUtility.ToDateTime(dr["Image_CreateDate"]);
                    retVal.Image_FileSize = ConvertUtility.ToDouble(dr["Image_FileSize"]);
                    retVal.Image_Width = ConvertUtility.ToInt32(dr["Image_Width"]);
                    retVal.Image_Height = ConvertUtility.ToInt32(dr["Image_Height"]);
                    retVal.Image_View = ConvertUtility.ToInt32(dr["Image_View"]);
                    retVal.User_ID = ConvertUtility.ToInt32(dr["User_ID"]);
                    retVal.Image_Visible = ConvertUtility.ToBoolean(dr["Image_Visible"]);
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        private static ImageInfo CreateEntityFromReader(IDataReader reader)
        {
            var item = new ImageInfo();
            try { if (!reader.IsDBNull(reader.GetOrdinal("Image_ID"))) item.Image_ID = ConvertUtility.ToInt32(reader["Image_ID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Image_Name"))) item.Image_Name = ConvertUtility.ToString(reader["Image_Name"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Image_Description"))) item.Image_Description = ConvertUtility.ToString(reader["Image_Description"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Image_File"))) item.Image_File = ConvertUtility.ToString(reader["Image_File"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Image_CreateDate"))) item.Image_CreateDate = ConvertUtility.ToDateTime(reader["Image_CreateDate"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Image_FileSize"))) item.Image_FileSize = ConvertUtility.ToDouble(reader["Image_FileSize"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Image_Width"))) item.Image_Width = ConvertUtility.ToInt32(reader["Image_Width"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Image_Height"))) item.Image_Height = ConvertUtility.ToInt32(reader["Image_Height"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Image_View"))) item.Image_View = ConvertUtility.ToInt32(reader["Image_View"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("User_ID"))) item.User_ID = ConvertUtility.ToInt32(reader["User_ID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Image_Visible"))) item.Image_Visible = ConvertUtility.ToBoolean(reader["Image_Visible"]); }
            catch { }
            return item;
        }


    }
}
