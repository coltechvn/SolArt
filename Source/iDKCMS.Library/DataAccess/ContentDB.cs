using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iDKCMS.Library.Data;

namespace iDKCMS.Library.DataAccess
{
    public class ContentDB
    {
        public static string GetAuthorInfoByContentID(int contentid)
        {
            return "Người viết  : " + GetUserNameByContentID(contentid) + "\r\n" +
                "Người sửa  : " + GetModifiedUserNameByContentID(contentid);
        }

        public static void SetComment(int contentid, string comment)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("CMS_Contents_SetComment", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ContentID", contentid);
            dbCmd.Parameters.AddWithValue("@Comment", comment);
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

        public static int GetZoneIDByContentID(int contentid)
        {
            var retVal = 0;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("CMS_Contents_GetZoneIDByContentID", dbConn);
            dbCmd.Parameters.AddWithValue("@ContentID", contentid);
            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read()) retVal = dr.GetInt32(0);
                dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        public static string GetUserNameByContentID(int contentid)
        {
            string retVal = string.Empty;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("CMS_Contents_GetUserNameByContentID", dbConn);
            dbCmd.Parameters.AddWithValue("@ContentID", contentid);
            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read()) retVal = dr.GetString(0);
                dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        public static string GetModifiedUserNameByContentID(int contentid)
        {
            string retVal = string.Empty;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("CMS_Contents_GetModifiedUserNameByContentID", dbConn);
            dbCmd.Parameters.AddWithValue("@ContentID", contentid);
            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read()) retVal = dr.GetString(0);
                dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        public static string GetName(int contentid)
        {
            string retVal = string.Empty;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("CMS_Contents_GetName", dbConn);
            dbCmd.Parameters.AddWithValue("@ContentID", contentid);
            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read()) retVal = dr.GetString(0);
                dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        public static DataTable GetContents(int zoneID, int status)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("CMS_Contents_GetContents", dbConn);
            dbCmd.Parameters.AddWithValue("@ZoneID", zoneID);
            dbCmd.Parameters.AddWithValue("@Status", status);
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

        public static DataTable SearchNormal(string text, string lang)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            string sql =
                "SELECT  Content_Name, Content_Teaser, Distribution_ID, Distribution_CreateDate, Distribution_ZoneID FROM CMS_Contents ";
            sql += " INNER JOIN CMS_Distributions ON Distribution_ContentID = Content_ID ";
            sql += " WHERE Distribution_ID IN ";
            sql += " ( ";
            sql += " SELECT DISTINCT Distribution_ID FROM CMS_Distributions ";
            sql += " INNER JOIN CMS_Zones ON Zone_ID = Distribution_ZoneID ";
            sql +=
                " WHERE Distribution_ContentID IN (SELECT Content_ID FROM CMS_Contents WHERE (Content_Name LIKE N'%" + text + "%') OR (Content_Teaser LIKE N'%" + text + "%') OR (Content_Body LIKE N'%" + text + "%')) ";
            sql += " AND Zone_Lang = '" + lang + "' ";
            sql += " ) ";

            SqlCommand dbCmd = new SqlCommand(sql, dbConn);
            dbCmd.CommandType = CommandType.Text;
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

        public static DataTable SearchNormalByZone(string text, string lang, int zoneid)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            string sql =
                "SELECT  Content_Name, Content_Teaser, Distribution_ID, Distribution_CreateDate, Distribution_ZoneID FROM CMS_Contents ";
            sql += " INNER JOIN CMS_Distributions ON Distribution_ContentID = Content_ID ";
            sql += " WHERE Distribution_ID IN ";
            sql += " ( ";
            sql += " SELECT DISTINCT Distribution_ID FROM CMS_Distributions ";
            sql += " INNER JOIN CMS_Zones ON Zone_ID = Distribution_ZoneID ";
            sql +=
                " WHERE Distribution_ContentID IN (SELECT Content_ID FROM CMS_Contents WHERE (Content_Name LIKE N'%" + text + "%') OR (Content_Teaser LIKE N'%" + text + "%') OR (Content_Body LIKE N'%" + text + "%')) ";
            sql += " AND Distribution_ZoneID = '" + zoneid + "' ";
            sql += " AND Zone_Lang = '" + lang + "' ";
            sql += " ) ";

            SqlCommand dbCmd = new SqlCommand(sql, dbConn);
            dbCmd.CommandType = CommandType.Text;
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

        public static DataTable GetDocuments(int zoneID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("CMS_Contents_GetDocuments", dbConn);
            dbCmd.Parameters.AddWithValue("@ZoneID", zoneID);
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

        public static DataTable GetDocumentsByUserID(int zoneID, int userID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("CMS_Contents_GetDocumentsByUserID", dbConn);
            dbCmd.Parameters.AddWithValue("@ZoneID", zoneID);
            dbCmd.Parameters.AddWithValue("@UserID", userID);
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

        public static DataTable GetContentsByUserID(int zoneID, int status, int userID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("CMS_Contents_GetContentsByUserID", dbConn);
            dbCmd.Parameters.AddWithValue("@ZoneID", zoneID);
            dbCmd.Parameters.AddWithValue("@Status", status);
            dbCmd.Parameters.AddWithValue("@UserID", userID);
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


        public static void SetStatus(int contentID, int status)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("CMS_Contents_SetStatus", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Content_ID", contentID);
            dbCmd.Parameters.AddWithValue("@Content_Status", status);
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

        public static void DeleteTemp()
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Contents_DeleteTemp", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@DeleteTime", DateTime.Now.AddDays(-7));
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

        public static DataTable GetAll()
        {
            DataTable retVal;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Contents_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };
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
        public static List<ContentInfo> GetEntitys()
        {
            var items = new List<ContentInfo>();
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Contents_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };

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


        public static void Delete(int content_ID)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Contents_Delete", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Content_ID", content_ID);
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
        public static int Insert(ContentInfo contentInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Contents_Insert", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Content_Name", contentInfo.Content_Name);
            dbCmd.Parameters.AddWithValue("@Content_Teaser", contentInfo.Content_Teaser);
            dbCmd.Parameters.AddWithValue("@Content_Body", contentInfo.Content_Body);
            dbCmd.Parameters.AddWithValue("@Content_CreateDate", contentInfo.Content_CreateDate);
            dbCmd.Parameters.AddWithValue("@Content_ModifiedDate", contentInfo.Content_ModifiedDate);
            dbCmd.Parameters.AddWithValue("@Content_Status", contentInfo.Content_Status);
            dbCmd.Parameters.AddWithValue("@Content_OriginalZoneID", contentInfo.Content_OriginalZoneID);
            dbCmd.Parameters.AddWithValue("@Content_UserID", contentInfo.Content_UserID);
            dbCmd.Parameters.AddWithValue("@Content_ModifiedUserID", contentInfo.Content_ModifiedUserID);
            dbCmd.Parameters.AddWithValue("@Content_Author", contentInfo.Content_Author);
            dbCmd.Parameters.AddWithValue("@Content_EventDate", contentInfo.Content_EventDate);
            dbCmd.Parameters.AddWithValue("@Content_FriendlyUrl", contentInfo.Content_FriendlyUrl);
            dbCmd.Parameters.AddWithValue("@Content_Comment", contentInfo.Content_Comment);
            dbCmd.Parameters.AddWithValue("@Content_ExcludeFromSearch", contentInfo.Content_ExcludeFromSearch);
            dbCmd.Parameters.AddWithValue("@Content_IsPhoto", contentInfo.Content_IsPhoto);
            dbCmd.Parameters.AddWithValue("@Content_IsDownload", contentInfo.Content_IsDownload);
            dbCmd.Parameters.AddWithValue("@Content_IsVideo", contentInfo.Content_IsVideo);
            dbCmd.Parameters.AddWithValue("@Content_IsPoll", contentInfo.Content_IsPoll);
            dbCmd.Parameters.AddWithValue("@Content_IsProduct", contentInfo.Content_IsProduct);
            dbCmd.Parameters.AddWithValue("@Content_Visible", contentInfo.Content_Visible);
            dbCmd.Parameters.AddWithValue("@Content_IsTemp", contentInfo.Content_IsTemp);
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

        public static void Update(ContentInfo contentInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Contents_Update", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Content_ID", contentInfo.Content_ID);
            dbCmd.Parameters.AddWithValue("@Content_Name", contentInfo.Content_Name);
            dbCmd.Parameters.AddWithValue("@Content_Teaser", contentInfo.Content_Teaser);
            dbCmd.Parameters.AddWithValue("@Content_Body", contentInfo.Content_Body);
            dbCmd.Parameters.AddWithValue("@Content_CreateDate", contentInfo.Content_CreateDate);
            dbCmd.Parameters.AddWithValue("@Content_ModifiedDate", contentInfo.Content_ModifiedDate);
            dbCmd.Parameters.AddWithValue("@Content_Status", contentInfo.Content_Status);
            dbCmd.Parameters.AddWithValue("@Content_OriginalZoneID", contentInfo.Content_OriginalZoneID);
            dbCmd.Parameters.AddWithValue("@Content_UserID", contentInfo.Content_UserID);
            dbCmd.Parameters.AddWithValue("@Content_ModifiedUserID", contentInfo.Content_ModifiedUserID);
            dbCmd.Parameters.AddWithValue("@Content_Author", contentInfo.Content_Author);
            dbCmd.Parameters.AddWithValue("@Content_EventDate", contentInfo.Content_EventDate);
            dbCmd.Parameters.AddWithValue("@Content_FriendlyUrl", contentInfo.Content_FriendlyUrl);
            dbCmd.Parameters.AddWithValue("@Content_Comment", contentInfo.Content_Comment);
            dbCmd.Parameters.AddWithValue("@Content_ExcludeFromSearch", contentInfo.Content_ExcludeFromSearch);
            dbCmd.Parameters.AddWithValue("@Content_IsPhoto", contentInfo.Content_IsPhoto);
            dbCmd.Parameters.AddWithValue("@Content_IsDownload", contentInfo.Content_IsDownload);
            dbCmd.Parameters.AddWithValue("@Content_IsVideo", contentInfo.Content_IsVideo);
            dbCmd.Parameters.AddWithValue("@Content_IsPoll", contentInfo.Content_IsPoll);
            dbCmd.Parameters.AddWithValue("@Content_IsProduct", contentInfo.Content_IsProduct);
            dbCmd.Parameters.AddWithValue("@Content_Visible", contentInfo.Content_Visible);
            dbCmd.Parameters.AddWithValue("@Content_IsTemp", contentInfo.Content_IsTemp);
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

        public static ContentInfo GetInfo(int content_ID)
        {
            ContentInfo retVal = null;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Contents_GetInfo", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Content_ID", content_ID);
            try
            {
                dbConn.Open();
                var dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new ContentInfo();
                    retVal.Content_ID = ConvertUtility.ToInt32(dr["Content_ID"]);
                    retVal.Content_Name = ConvertUtility.ToString(dr["Content_Name"]);
                    retVal.Content_Teaser = ConvertUtility.ToString(dr["Content_Teaser"]);
                    retVal.Content_Body = ConvertUtility.ToString(dr["Content_Body"]);
                    retVal.Content_CreateDate = ConvertUtility.ToDateTime(dr["Content_CreateDate"]);
                    retVal.Content_ModifiedDate = ConvertUtility.ToDateTime(dr["Content_ModifiedDate"]);
                    retVal.Content_Status = ConvertUtility.ToInt32(dr["Content_Status"]);
                    retVal.Content_OriginalZoneID = ConvertUtility.ToInt32(dr["Content_OriginalZoneID"]);
                    retVal.Content_UserID = ConvertUtility.ToInt32(dr["Content_UserID"]);
                    retVal.Content_ModifiedUserID = ConvertUtility.ToInt32(dr["Content_ModifiedUserID"]);
                    retVal.Content_Author = ConvertUtility.ToString(dr["Content_Author"]);
                    retVal.Content_EventDate = ConvertUtility.ToDateTime(dr["Content_EventDate"]);
                    retVal.Content_FriendlyUrl = ConvertUtility.ToString(dr["Content_FriendlyUrl"]);
                    retVal.Content_Comment = ConvertUtility.ToString(dr["Content_Comment"]);
                    retVal.Content_ExcludeFromSearch = ConvertUtility.ToBoolean(dr["Content_ExcludeFromSearch"]);
                    retVal.Content_IsPhoto = ConvertUtility.ToBoolean(dr["Content_IsPhoto"]);
                    retVal.Content_IsDownload = ConvertUtility.ToBoolean(dr["Content_IsDownload"]);
                    retVal.Content_IsVideo = ConvertUtility.ToBoolean(dr["Content_IsVideo"]);
                    retVal.Content_IsPoll = ConvertUtility.ToBoolean(dr["Content_IsPoll"]);
                    retVal.Content_IsProduct = ConvertUtility.ToBoolean(dr["Content_IsProduct"]);
                    retVal.Content_Visible = ConvertUtility.ToBoolean(dr["Content_Visible"]);
                    retVal.Content_IsTemp = ConvertUtility.ToBoolean(dr["Content_IsTemp"]);
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        private static ContentInfo CreateEntityFromReader(IDataReader reader)
        {
            var item = new ContentInfo();
            try { if (!reader.IsDBNull(reader.GetOrdinal("Content_ID"))) item.Content_ID = ConvertUtility.ToInt32(reader["Content_ID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Content_Name"))) item.Content_Name = ConvertUtility.ToString(reader["Content_Name"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Content_Teaser"))) item.Content_Teaser = ConvertUtility.ToString(reader["Content_Teaser"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Content_Body"))) item.Content_Body = ConvertUtility.ToString(reader["Content_Body"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Content_CreateDate"))) item.Content_CreateDate = ConvertUtility.ToDateTime(reader["Content_CreateDate"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Content_ModifiedDate"))) item.Content_ModifiedDate = ConvertUtility.ToDateTime(reader["Content_ModifiedDate"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Content_Status"))) item.Content_Status = ConvertUtility.ToInt32(reader["Content_Status"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Content_OriginalZoneID"))) item.Content_OriginalZoneID = ConvertUtility.ToInt32(reader["Content_OriginalZoneID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Content_UserID"))) item.Content_UserID = ConvertUtility.ToInt32(reader["Content_UserID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Content_ModifiedUserID"))) item.Content_ModifiedUserID = ConvertUtility.ToInt32(reader["Content_ModifiedUserID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Content_Author"))) item.Content_Author = ConvertUtility.ToString(reader["Content_Author"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Content_EventDate"))) item.Content_EventDate = ConvertUtility.ToDateTime(reader["Content_EventDate"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Content_FriendlyUrl"))) item.Content_FriendlyUrl = ConvertUtility.ToString(reader["Content_FriendlyUrl"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Content_Comment"))) item.Content_Comment = ConvertUtility.ToString(reader["Content_Comment"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Content_ExcludeFromSearch"))) item.Content_ExcludeFromSearch = ConvertUtility.ToBoolean(reader["Content_ExcludeFromSearch"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Content_IsPhoto"))) item.Content_IsPhoto = ConvertUtility.ToBoolean(reader["Content_IsPhoto"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Content_IsDownload"))) item.Content_IsDownload = ConvertUtility.ToBoolean(reader["Content_IsDownload"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Content_IsVideo"))) item.Content_IsVideo = ConvertUtility.ToBoolean(reader["Content_IsVideo"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Content_IsPoll"))) item.Content_IsPoll = ConvertUtility.ToBoolean(reader["Content_IsPoll"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Content_IsProduct"))) item.Content_IsProduct = ConvertUtility.ToBoolean(reader["Content_IsProduct"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Content_Visible"))) item.Content_Visible = ConvertUtility.ToBoolean(reader["Content_Visible"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Content_IsTemp"))) item.Content_IsTemp = ConvertUtility.ToBoolean(reader["Content_IsTemp"]); }
            catch { }
            return item;
        }


    }
}
