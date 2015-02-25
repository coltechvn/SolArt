using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iDKCMS.Library.Data;

namespace iDKCMS.Library.DataAccess
{
    public class VideoDB
    {
        public static VideoInfo GetCover(int contentId)
        {
            VideoInfo retVal = null;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Videos_GetCover", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Content_ID", contentId);
            try
            {
                dbConn.Open();
                var dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new VideoInfo();
                    retVal.Video_ID = ConvertUtility.ToInt32(dr["Video_ID"]);
                    retVal.Video_Name = ConvertUtility.ToString(dr["Video_Name"]);
                    retVal.Video_Description = ConvertUtility.ToString(dr["Video_Description"]);
                    retVal.Video_Type = ConvertUtility.ToString(dr["Video_Type"]);
                    retVal.Video_File = ConvertUtility.ToString(dr["Video_File"]);
                    retVal.Video_YouTube = ConvertUtility.ToString(dr["Video_YouTube"]);
                    retVal.Video_Width = ConvertUtility.ToInt32(dr["Video_Width"]);
                    retVal.Video_Height = ConvertUtility.ToInt32(dr["Video_Height"]);
                    retVal.Video_CreateDate = ConvertUtility.ToDateTime(dr["Video_CreateDate"]);
                    retVal.Video_View = ConvertUtility.ToInt32(dr["Video_View"]);
                    retVal.User_ID = ConvertUtility.ToInt32(dr["User_ID"]);
                    retVal.Video_Visible = ConvertUtility.ToBoolean(dr["Video_Visible"]);
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
            var dbCmd = new SqlCommand("CMS_Videos_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };
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
        public static List<VideoInfo> GetEntitys()
        {
            var items = new List<VideoInfo>();
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Videos_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };

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


        public static void Delete(int video_ID)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Videos_Delete", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Video_ID", video_ID);
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
        public static int Insert(VideoInfo videoInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Videos_Insert", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Video_Name", videoInfo.Video_Name);
            dbCmd.Parameters.AddWithValue("@Video_Description", videoInfo.Video_Description);
            dbCmd.Parameters.AddWithValue("@Video_Type", videoInfo.Video_Type);
            dbCmd.Parameters.AddWithValue("@Video_File", videoInfo.Video_File);
            dbCmd.Parameters.AddWithValue("@Video_YouTube", videoInfo.Video_YouTube);
            dbCmd.Parameters.AddWithValue("@Video_Width", videoInfo.Video_Width);
            dbCmd.Parameters.AddWithValue("@Video_Height", videoInfo.Video_Height);
            dbCmd.Parameters.AddWithValue("@Video_CreateDate", videoInfo.Video_CreateDate);
            dbCmd.Parameters.AddWithValue("@Video_View", videoInfo.Video_View);
            dbCmd.Parameters.AddWithValue("@User_ID", videoInfo.User_ID);
            dbCmd.Parameters.AddWithValue("@Video_Visible", videoInfo.Video_Visible);
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

        public static void Update(VideoInfo videoInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Videos_Update", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Video_ID", videoInfo.Video_ID);
            dbCmd.Parameters.AddWithValue("@Video_Name", videoInfo.Video_Name);
            dbCmd.Parameters.AddWithValue("@Video_Description", videoInfo.Video_Description);
            dbCmd.Parameters.AddWithValue("@Video_Type", videoInfo.Video_Type);
            dbCmd.Parameters.AddWithValue("@Video_File", videoInfo.Video_File);
            dbCmd.Parameters.AddWithValue("@Video_YouTube", videoInfo.Video_YouTube);
            dbCmd.Parameters.AddWithValue("@Video_Width", videoInfo.Video_Width);
            dbCmd.Parameters.AddWithValue("@Video_Height", videoInfo.Video_Height);
            dbCmd.Parameters.AddWithValue("@Video_CreateDate", videoInfo.Video_CreateDate);
            dbCmd.Parameters.AddWithValue("@Video_View", videoInfo.Video_View);
            dbCmd.Parameters.AddWithValue("@User_ID", videoInfo.User_ID);
            dbCmd.Parameters.AddWithValue("@Video_Visible", videoInfo.Video_Visible);
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

        public static VideoInfo GetInfo(int video_ID)
        {
            VideoInfo retVal = null;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Videos_GetInfo", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Video_ID", video_ID);
            try
            {
                dbConn.Open();
                var dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new VideoInfo();
                    retVal.Video_ID = ConvertUtility.ToInt32(dr["Video_ID"]);
                    retVal.Video_Name = ConvertUtility.ToString(dr["Video_Name"]);
                    retVal.Video_Description = ConvertUtility.ToString(dr["Video_Description"]);
                    retVal.Video_Type = ConvertUtility.ToString(dr["Video_Type"]);
                    retVal.Video_File = ConvertUtility.ToString(dr["Video_File"]);
                    retVal.Video_YouTube = ConvertUtility.ToString(dr["Video_YouTube"]);
                    retVal.Video_Width = ConvertUtility.ToInt32(dr["Video_Width"]);
                    retVal.Video_Height = ConvertUtility.ToInt32(dr["Video_Height"]);
                    retVal.Video_CreateDate = ConvertUtility.ToDateTime(dr["Video_CreateDate"]);
                    retVal.Video_View = ConvertUtility.ToInt32(dr["Video_View"]);
                    retVal.User_ID = ConvertUtility.ToInt32(dr["User_ID"]);
                    retVal.Video_Visible = ConvertUtility.ToBoolean(dr["Video_Visible"]);
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        private static VideoInfo CreateEntityFromReader(IDataReader reader)
        {
            var item = new VideoInfo();
            try { if (!reader.IsDBNull(reader.GetOrdinal("Video_ID"))) item.Video_ID = ConvertUtility.ToInt32(reader["Video_ID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Video_Name"))) item.Video_Name = ConvertUtility.ToString(reader["Video_Name"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Video_Description"))) item.Video_Description = ConvertUtility.ToString(reader["Video_Description"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Video_Type"))) item.Video_Type = ConvertUtility.ToString(reader["Video_Type"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Video_File"))) item.Video_File = ConvertUtility.ToString(reader["Video_File"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Video_YouTube"))) item.Video_YouTube = ConvertUtility.ToString(reader["Video_YouTube"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Video_Width"))) item.Video_Width = ConvertUtility.ToInt32(reader["Video_Width"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Video_Height"))) item.Video_Height = ConvertUtility.ToInt32(reader["Video_Height"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Video_CreateDate"))) item.Video_CreateDate = ConvertUtility.ToDateTime(reader["Video_CreateDate"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Video_View"))) item.Video_View = ConvertUtility.ToInt32(reader["Video_View"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("User_ID"))) item.User_ID = ConvertUtility.ToInt32(reader["User_ID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Video_Visible"))) item.Video_Visible = ConvertUtility.ToBoolean(reader["Video_Visible"]); }
            catch { }
            return item;
        }


    }
}
