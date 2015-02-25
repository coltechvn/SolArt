using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iDKCMS.Library.Data;

namespace iDKCMS.Library.DataAccess
{
    public class ZoneDB
    {
        public static int GetIDByFriendlyUrl(string friendlyUrl)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);

            var dbCmd = new SqlCommand("CMS_Zones_GetIDByFriendlyUrl", dbConn)
                            {CommandType = CommandType.StoredProcedure};
            dbCmd.Parameters.AddWithValue("@FriendlyUrl", friendlyUrl );
            dbCmd.Parameters.AddWithValue("@Lang", AppEnv.GetLanguageFrontEnd());
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                    return dr.GetInt32(0);
                else
                    return 0;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public static string GetZoneNameByID(int zoneID)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("CMS_Zones_GetZoneNameByID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ZoneID", zoneID);
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

        public static string GetZoneLayout(int zoneID)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("CMS_Zones_GetZoneLayout", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ZoneID", zoneID);
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

        public static DataTable GetStandAloneBox()
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("CMS_Zones_GetStandAloneBox", dbConn);
            dbCmd.Parameters.AddWithValue("@Lang", AppEnv.GetLanguage());
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

        public static DataTable GetByParentID(int parentID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("CMS_Zones_GetByParentID", dbConn);
            dbCmd.Parameters.AddWithValue("@ParentID", parentID);
            dbCmd.Parameters.AddWithValue("@Lang", AppEnv.GetLanguage());
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

        public static DataTable GetByParentIDOrderByName(int parentID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("CMS_Zones_GetByParentIDOrderByName", dbConn);
            dbCmd.Parameters.AddWithValue("@ParentID", parentID);
            dbCmd.Parameters.AddWithValue("@Lang", AppEnv.GetLanguage());

            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                //HttpContext.Current.Response.Write(sql);
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


        public static int GetParentID(int id)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("CMS_Zones_GetParentID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Id", id);
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

        public static DataTable GetZoneVisbleInMainNav()
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("CMS_Zones_GetZoneVisbleInMainNav", dbConn);
            dbCmd.Parameters.AddWithValue("@Lang", AppEnv.GetLanguage());
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

        public static DataTable GetZoneVisbleInLeftNav()
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("CMS_Zones_GetZoneVisbleInLeftNav", dbConn);
            dbCmd.Parameters.AddWithValue("@Lang", AppEnv.GetLanguage());
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

        public static DataTable GetZoneVisbleInTopNav()
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("CMS_Zones_GetZoneVisbleInTopNav", dbConn);
            dbCmd.Parameters.AddWithValue("@Lang", AppEnv.GetLanguage());
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

        public static DataTable GetZoneVisbleInFooterNav()
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("CMS_Zones_GetZoneVisbleInFooterNav", dbConn);
            dbCmd.Parameters.AddWithValue("@Lang", AppEnv.GetLanguage());
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


        public static bool SetPriority(int zoneID, int priority)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("CMS_Zones_SetPriority", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Zone_ID", zoneID);
            dbCmd.Parameters.AddWithValue("@Zone_Priority", priority);
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

        public static int GetChildCount(int parentID)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("CMS_Zones_GetChildCount", dbConn);
            dbCmd.Parameters.AddWithValue("@ParentID", parentID);
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

        public static int GetMaxOrder(string Language)
        {
            int retVal = 1;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("CMS_Zones_GetMaxOrder", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Language", Language);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = dr.GetInt32(0);

                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
                retVal = 1;
            }
            return retVal;
        }
        public static int[] GetFocusZoneList(string setting)
        {
            //int[] retVal = null;
            //string settingValue =  SettingDB.GetValue(setting);
            //string[] val = settingValue.Split(",".ToCharArray());
            //int len = val.Length;
            //retVal = new int[len];
            //for (int i = 0; i < len; i++)
            //{
            //    retVal[i] = 0;
            //    try
            //    {
            //        retVal[i] = ConvertUtility.ToInt32(val[i]);
            //    }
            //    catch { }
            //}
            //return retVal;

            int len_0 = 0, k = 0;

            int[] retVal = null;
            int[] retVal_0 = null;

            string settingValue = SettingDB.GetValue(setting);
            string[] val = settingValue.Split(",".ToCharArray());
            int len = val.Length;
            retVal = new int[len];
            for (int i = 0; i < len; i++)
            {
                retVal[i] = 0;
                try
                {
                    retVal[i] = ConvertUtility.ToInt32(val[i]);

                    if (retVal[i] > 0) ++len_0;

                }
                catch { }
            }

            retVal_0 = new int[len_0];

            for (int i = 0; i < len; i++)
            {
                if (retVal[i] > 0)
                {
                    retVal_0[k] = retVal[i];
                    k++;
                }
            }

            return retVal_0;
        }

        public static DataTable GetAll()
        {
            DataTable retVal;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Zones_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };
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

        public static List<ZoneInfo> GetEntitys()
        {
            var items = new List<ZoneInfo>();
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Zones_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };

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


        public static bool Delete(int zone_ID)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Zones_Delete", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Zone_ID", zone_ID);
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
        public static bool Insert(ZoneInfo zoneInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Zones_Insert", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Zone_ParentID", zoneInfo.Zone_ParentID);
            dbCmd.Parameters.AddWithValue("@Zone_Name", zoneInfo.Zone_Name);
            dbCmd.Parameters.AddWithValue("@Zone_Description", zoneInfo.Zone_Description);
            dbCmd.Parameters.AddWithValue("@Zone_FriendlyUrl", zoneInfo.Zone_FriendlyUrl);
            dbCmd.Parameters.AddWithValue("@Zone_RealUrl", zoneInfo.Zone_RealUrl);
            dbCmd.Parameters.AddWithValue("@Zone_Avatar", zoneInfo.Zone_Avatar);
            dbCmd.Parameters.AddWithValue("@Zone_Priority", zoneInfo.Zone_Priority);
            dbCmd.Parameters.AddWithValue("@Zone_MetaDescription", zoneInfo.Zone_MetaDescription);
            dbCmd.Parameters.AddWithValue("@Zone_MetaKeywords", zoneInfo.Zone_MetaKeywords);
            dbCmd.Parameters.AddWithValue("@Zone_Layout", zoneInfo.Zone_Layout);
            dbCmd.Parameters.AddWithValue("@Zone_SubcategoryDisplay", zoneInfo.Zone_SubcategoryDisplay);
            dbCmd.Parameters.AddWithValue("@Zone_ContentListingDisplay", zoneInfo.Zone_ContentListingDisplay);
            dbCmd.Parameters.AddWithValue("@Zone_VisibleInMainNav", zoneInfo.Zone_VisibleInMainNav);
            dbCmd.Parameters.AddWithValue("@Zone_VisibleInLeftNav", zoneInfo.Zone_VisibleInLeftNav);
            dbCmd.Parameters.AddWithValue("@Zone_VisibleInTopNav", zoneInfo.Zone_VisibleInTopNav);
            dbCmd.Parameters.AddWithValue("@Zone_VisibleInFooterNav", zoneInfo.Zone_VisibleInFooterNav);
            dbCmd.Parameters.AddWithValue("@Zone_ExcludeFromNav", zoneInfo.Zone_ExcludeFromNav);
            dbCmd.Parameters.AddWithValue("@Zone_Visible", zoneInfo.Zone_Visible);
            dbCmd.Parameters.AddWithValue("@Zone_Disable", zoneInfo.Zone_Disable);
            dbCmd.Parameters.AddWithValue("@Zone_Lang", zoneInfo.Zone_Lang);
            dbCmd.Parameters.AddWithValue("@Zone_IsStandAloneBox", zoneInfo.Zone_IsStandAloneBox);
            dbCmd.Parameters.AddWithValue("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
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

        public static bool Update(ZoneInfo zoneInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Zones_Update", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Zone_ID", zoneInfo.Zone_ID);
            dbCmd.Parameters.AddWithValue("@Zone_ParentID", zoneInfo.Zone_ParentID);
            dbCmd.Parameters.AddWithValue("@Zone_Name", zoneInfo.Zone_Name);
            dbCmd.Parameters.AddWithValue("@Zone_Description", zoneInfo.Zone_Description);
            dbCmd.Parameters.AddWithValue("@Zone_FriendlyUrl", zoneInfo.Zone_FriendlyUrl);
            dbCmd.Parameters.AddWithValue("@Zone_RealUrl", zoneInfo.Zone_RealUrl);
            dbCmd.Parameters.AddWithValue("@Zone_Avatar", zoneInfo.Zone_Avatar);
            dbCmd.Parameters.AddWithValue("@Zone_Priority", zoneInfo.Zone_Priority);
            dbCmd.Parameters.AddWithValue("@Zone_MetaDescription", zoneInfo.Zone_MetaDescription);
            dbCmd.Parameters.AddWithValue("@Zone_MetaKeywords", zoneInfo.Zone_MetaKeywords);
            dbCmd.Parameters.AddWithValue("@Zone_Layout", zoneInfo.Zone_Layout);
            dbCmd.Parameters.AddWithValue("@Zone_SubcategoryDisplay", zoneInfo.Zone_SubcategoryDisplay);
            dbCmd.Parameters.AddWithValue("@Zone_ContentListingDisplay", zoneInfo.Zone_ContentListingDisplay);
            dbCmd.Parameters.AddWithValue("@Zone_VisibleInMainNav", zoneInfo.Zone_VisibleInMainNav);
            dbCmd.Parameters.AddWithValue("@Zone_VisibleInLeftNav", zoneInfo.Zone_VisibleInLeftNav);
            dbCmd.Parameters.AddWithValue("@Zone_VisibleInTopNav", zoneInfo.Zone_VisibleInTopNav);
            dbCmd.Parameters.AddWithValue("@Zone_VisibleInFooterNav", zoneInfo.Zone_VisibleInFooterNav);
            dbCmd.Parameters.AddWithValue("@Zone_ExcludeFromNav", zoneInfo.Zone_ExcludeFromNav);
            dbCmd.Parameters.AddWithValue("@Zone_Visible", zoneInfo.Zone_Visible);
            dbCmd.Parameters.AddWithValue("@Zone_Disable", zoneInfo.Zone_Disable);
            dbCmd.Parameters.AddWithValue("@Zone_Lang", zoneInfo.Zone_Lang);
            dbCmd.Parameters.AddWithValue("@Zone_IsStandAloneBox", zoneInfo.Zone_IsStandAloneBox);
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

        public static ZoneInfo GetInfo(int zone_ID)
        {
            ZoneInfo retVal = null;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Zones_GetInfo", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Zone_ID", zone_ID);
            try
            {
                dbConn.Open();
                var dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new ZoneInfo();
                    retVal.Zone_ID = ConvertUtility.ToInt32(dr["Zone_ID"]);
                    retVal.Zone_ParentID = ConvertUtility.ToInt32(dr["Zone_ParentID"]);
                    retVal.Zone_Name = ConvertUtility.ToString(dr["Zone_Name"]);
                    retVal.Zone_Description = ConvertUtility.ToString(dr["Zone_Description"]);
                    retVal.Zone_FriendlyUrl = ConvertUtility.ToString(dr["Zone_FriendlyUrl"]);
                    retVal.Zone_RealUrl = ConvertUtility.ToString(dr["Zone_RealUrl"]);
                    retVal.Zone_Avatar = ConvertUtility.ToString(dr["Zone_Avatar"]);
                    retVal.Zone_Priority = ConvertUtility.ToInt32(dr["Zone_Priority"]);
                    retVal.Zone_MetaDescription = ConvertUtility.ToString(dr["Zone_MetaDescription"]);
                    retVal.Zone_MetaKeywords = ConvertUtility.ToString(dr["Zone_MetaKeywords"]);
                    retVal.Zone_Layout = ConvertUtility.ToString(dr["Zone_Layout"]);
                    retVal.Zone_SubcategoryDisplay = ConvertUtility.ToString(dr["Zone_SubcategoryDisplay"]);
                    retVal.Zone_ContentListingDisplay = ConvertUtility.ToString(dr["Zone_ContentListingDisplay"]);
                    retVal.Zone_VisibleInMainNav = ConvertUtility.ToBoolean(dr["Zone_VisibleInMainNav"]);
                    retVal.Zone_VisibleInLeftNav = ConvertUtility.ToBoolean(dr["Zone_VisibleInLeftNav"]);
                    retVal.Zone_VisibleInTopNav = ConvertUtility.ToBoolean(dr["Zone_VisibleInTopNav"]);
                    retVal.Zone_VisibleInFooterNav = ConvertUtility.ToBoolean(dr["Zone_VisibleInFooterNav"]);
                    retVal.Zone_ExcludeFromNav = ConvertUtility.ToBoolean(dr["Zone_ExcludeFromNav"]);
                    retVal.Zone_Visible = ConvertUtility.ToBoolean(dr["Zone_Visible"]);
                    retVal.Zone_Disable = ConvertUtility.ToBoolean(dr["Zone_Disable"]);
                    retVal.Zone_Lang = ConvertUtility.ToString(dr["Zone_Lang"]);
                    retVal.Zone_IsStandAloneBox = ConvertUtility.ToBoolean(dr["Zone_IsStandAloneBox"]);
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        private static ZoneInfo CreateEntityFromReader(IDataReader reader)
        {
            var item = new ZoneInfo();
            try { if (!reader.IsDBNull(reader.GetOrdinal("Zone_ID"))) item.Zone_ID = ConvertUtility.ToInt32(reader["Zone_ID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Zone_ParentID"))) item.Zone_ParentID = ConvertUtility.ToInt32(reader["Zone_ParentID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Zone_Name"))) item.Zone_Name = ConvertUtility.ToString(reader["Zone_Name"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Zone_Description"))) item.Zone_Description = ConvertUtility.ToString(reader["Zone_Description"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Zone_FriendlyUrl"))) item.Zone_FriendlyUrl = ConvertUtility.ToString(reader["Zone_FriendlyUrl"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Zone_RealUrl"))) item.Zone_RealUrl = ConvertUtility.ToString(reader["Zone_RealUrl"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Zone_Avatar"))) item.Zone_Avatar = ConvertUtility.ToString(reader["Zone_Avatar"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Zone_Priority"))) item.Zone_Priority = ConvertUtility.ToInt32(reader["Zone_Priority"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Zone_MetaDescription"))) item.Zone_MetaDescription = ConvertUtility.ToString(reader["Zone_MetaDescription"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Zone_MetaKeywords"))) item.Zone_MetaKeywords = ConvertUtility.ToString(reader["Zone_MetaKeywords"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Zone_Layout"))) item.Zone_Layout = ConvertUtility.ToString(reader["Zone_Layout"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Zone_SubcategoryDisplay"))) item.Zone_SubcategoryDisplay = ConvertUtility.ToString(reader["Zone_SubcategoryDisplay"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Zone_ContentListingDisplay"))) item.Zone_ContentListingDisplay = ConvertUtility.ToString(reader["Zone_ContentListingDisplay"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Zone_VisibleInMainNav"))) item.Zone_VisibleInMainNav = ConvertUtility.ToBoolean(reader["Zone_VisibleInMainNav"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Zone_VisibleInLeftNav"))) item.Zone_VisibleInLeftNav = ConvertUtility.ToBoolean(reader["Zone_VisibleInLeftNav"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Zone_VisibleInTopNav"))) item.Zone_VisibleInTopNav = ConvertUtility.ToBoolean(reader["Zone_VisibleInTopNav"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Zone_VisibleInFooterNav"))) item.Zone_VisibleInFooterNav = ConvertUtility.ToBoolean(reader["Zone_VisibleInFooterNav"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Zone_ExcludeFromNav"))) item.Zone_ExcludeFromNav = ConvertUtility.ToBoolean(reader["Zone_ExcludeFromNav"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Zone_Visible"))) item.Zone_Visible = ConvertUtility.ToBoolean(reader["Zone_Visible"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Zone_Disable"))) item.Zone_Disable = ConvertUtility.ToBoolean(reader["Zone_Disable"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Zone_Lang"))) item.Zone_Lang = ConvertUtility.ToString(reader["Zone_Lang"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Zone_IsStandAloneBox"))) item.Zone_IsStandAloneBox = ConvertUtility.ToBoolean(reader["Zone_IsStandAloneBox"]); }
            catch { }
            return item;
        }


    }
}
