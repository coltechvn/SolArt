using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iDKCMS.Library.Data;

namespace iDKCMS.Library.DataAccess
{
    public class DistributionDB
    {
        public static int GetOriginalDistID(int contentId)
        {
            var retVal = 0;

            var originalZoneId = ConvertUtility.ToInt32(ContentDB.GetZoneIDByContentID(contentId));

            if (originalZoneId > 0)
            {
                retVal = ConvertUtility.ToInt32(GetDistIDByContentAndZone(contentId, originalZoneId));
            }

            return retVal;
        }

        public static void SetPriority(int distID, int priority)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("CMS_Distributions_SetPriority", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Distribution_ID", distID);
            dbCmd.Parameters.AddWithValue("@Priority", priority);
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

        public static int GetZoneID(int distID)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("CMS_Distributions_GetZoneID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@DistributionID", distID);
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

        public static int GetDistIDByContentAndZone(int contentId, int zoneId)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("CMS_Distributions_GetDistIDByContentAndZone", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Content_ID", contentId);
            dbCmd.Parameters.AddWithValue("@Zone_ID", zoneId);
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

        public static bool UpdateView(int distID, int number)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("CMS_Distributions_UpdateView", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@DistID", distID);
            dbCmd.Parameters.AddWithValue("@Number", number);
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

        public static bool RemoverByContentID(int contentID)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("CMS_Distributions_RemoverByContentID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ContentID", contentID);
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

        public static bool RemoverInZoneID(int contentID, int zoneID)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("CMS_Distributions_RemoverInZoneID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ContentID", contentID);
            dbCmd.Parameters.AddWithValue("@ZoneID", zoneID);
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

        public static bool CheckContentExist(int contentID, int zoneID)
        {
            int distId;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Distributions_CheckContentExist", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ContentID", contentID);
            dbCmd.Parameters.AddWithValue("@ZoneID", zoneID);
            try
            {
                dbConn.Open();

                var dr = dbCmd.ExecuteReader();
                if (dr.Read()) distId = dr.GetInt32(0);
                else distId = 0;
            }
            finally
            {
                dbConn.Close();
            }
            return distId > 0;
        }


        public static string GetNameByDistID(int distID)
        {
            string retVal = string.Empty;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("CMS_Distributions_GetNameByDistID", dbConn);
            dbCmd.Parameters.AddWithValue("@DistID", distID);
            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read()) retVal = dr.GetString(0);
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        public static DataTable GetZoneDeployed(int contentID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("CMS_Distributions_GetZoneDeployed", dbConn);
            dbCmd.Parameters.AddWithValue("@ContentID", contentID);
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

        public static ContentInfo GetContentInfoByDistID(int distID)
        {
            DistributionInfo distInfo = DistributionDB.GetInfo(distID);
            if (distInfo == null) return null;
            else return ContentDB.GetInfo(distInfo.Distribution_ContentID);
        }


        public static DataTable GetPreviousForCurrent(int currentID, int numberRecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("CMS_Distributions_GetPreviousForCurrent", dbConn);
            dbCmd.Parameters.AddWithValue("@CurrentID", currentID);
            dbCmd.Parameters.AddWithValue("@NumberRecord", numberRecord);
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

        public static DataTable GetNewsForCurrent(int currentID, int numberRecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("CMS_Distributions_GetNewsForCurrent", dbConn);
            dbCmd.Parameters.AddWithValue("@CurrentID", currentID);
            dbCmd.Parameters.AddWithValue("@NumberRecord", numberRecord);
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

        public static DataTable GetContentByZoneIDAndRank(int zoneID, int numberRecord, int rank)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);


            SqlCommand dbCmd = new SqlCommand("CMS_Distributions_GetContentByZoneIDAndRank", dbConn);
            dbCmd.Parameters.AddWithValue("@ZoneID", zoneID);
            dbCmd.Parameters.AddWithValue("@NumberRecord", numberRecord);
            dbCmd.Parameters.AddWithValue("@Rank", rank);
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

        public static DataTable GetDeployByZoneID(int zoneID, int userID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("CMS_Distributions_GetDeployByZoneIDAndUserID", dbConn);
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

        public static DataTable GetDeployByZoneID(int zoneID, int pageSize, int currentPage, out int totalRecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("CMS_Distributions_GetDeployByZoneID", dbConn);
            dbCmd.Parameters.AddWithValue("@ZoneID", zoneID);
            dbCmd.Parameters.AddWithValue("@PageSize", pageSize);
            dbCmd.Parameters.AddWithValue("@CurrentPage", currentPage);
            dbCmd.Parameters.Add(new SqlParameter("@TotalRecord", SqlDbType.Int));
            dbCmd.Parameters["@TotalRecord"].Direction = ParameterDirection.Output;
            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
                totalRecord = Convert.ToInt32(dbCmd.Parameters["@TotalRecord"].Value);
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        public static DataTable GetNewContentByZoneID(int zoneID, bool inZone, int pageSize, int currentPage, out int totalRecord, int excludeid)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("CMS_Distributions_GetNewContentByZoneID", dbConn);
            dbCmd.Parameters.AddWithValue("@ZoneID", zoneID);
            dbCmd.Parameters.AddWithValue("@InZone", inZone);
            dbCmd.Parameters.AddWithValue("@PageSize", pageSize);
            dbCmd.Parameters.AddWithValue("@CurrentPage", currentPage);
            dbCmd.Parameters.AddWithValue("@ExcludeID", excludeid);
            dbCmd.Parameters.Add(new SqlParameter("@TotalRecord", SqlDbType.Int));
            dbCmd.Parameters["@TotalRecord"].Direction = ParameterDirection.Output;
            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
                totalRecord = Convert.ToInt32(dbCmd.Parameters["@TotalRecord"].Value);
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        public static DataTable GetNewContentByZoneIDNoPage(int zoneID, bool inZone, int excludeid)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("CMS_Distributions_GetNewContentByZoneIDNoPage", dbConn);
            dbCmd.Parameters.AddWithValue("@ZoneID", zoneID);
            dbCmd.Parameters.AddWithValue("@InZone", inZone);
            dbCmd.Parameters.AddWithValue("@ExcludeID", excludeid);
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

        public static DataTable GetNewProduct(int excludeid, int numberrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("CMS_Distributions_GetNewProduct", dbConn);
            dbCmd.Parameters.AddWithValue("@ExcludeID", excludeid);
            dbCmd.Parameters.AddWithValue("@NumberRecord", numberrecord);
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

        /* ******************************* lost *****************************/

        public static DataTable GetNewContentByZoneIDNoPageByDate(int zoneID, int excludeid, string startdate, string enddate)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("CMS_Distributions_GetNewContentByZoneIDNoPageByDate", dbConn);
            dbCmd.Parameters.AddWithValue("@ZoneID", zoneID);
            dbCmd.Parameters.AddWithValue("@ExcludeID", excludeid);
            dbCmd.Parameters.AddWithValue("@StartDate", startdate);
            dbCmd.Parameters.AddWithValue("@EndDate", enddate);
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

        public static DataTable GetNewContentByZoneID(int zoneID, int numberRecord, int excludeid)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);


            SqlCommand dbCmd = new SqlCommand("CMS_Distributions_GetNewContentExcludeID", dbConn);
            dbCmd.Parameters.AddWithValue("@ZoneID", zoneID);
            dbCmd.Parameters.AddWithValue("@NumberRecord", numberRecord);
            dbCmd.Parameters.AddWithValue("@ExcludeID", excludeid);
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

        public static DataTable GetContentByZoneAndRankInZone(int zoneID, bool inzone, int excludeid, int rank, int numberRecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);


            SqlCommand dbCmd = new SqlCommand("CMS_Distributions_GetContentByZoneAndRankInZone", dbConn);
            dbCmd.Parameters.AddWithValue("@ZoneID", zoneID);
            dbCmd.Parameters.AddWithValue("@InZone", inzone);
            dbCmd.Parameters.AddWithValue("@ExcludeID", excludeid);
            dbCmd.Parameters.AddWithValue("@Rank", rank);
            dbCmd.Parameters.AddWithValue("@NumberRecord", numberRecord);
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

        public static bool SetRank(int _distribution_ID, int rank)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("CMS_Distributions_SetRank", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Distribution_ID", _distribution_ID);
            dbCmd.Parameters.AddWithValue("@Distribution_Rank", rank);
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

        public static DataTable GetContentRandomByZoneIDselfAndNumberRecord(int zoneID, int numberRecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("CMS_Distributions_GetContentRandomByZoneIDSelfAndNumberRecord", dbConn);
            dbCmd.Parameters.AddWithValue("@ZoneID", zoneID);
            dbCmd.Parameters.AddWithValue("@NumberRecord", numberRecord);
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

        public static DataTable GetContentByZoneIDselfAndNumberRecord(int zoneID, int numberRecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("CMS_Distributions_GetContentByZoneIDSelfAndNumberRecord", dbConn);
            dbCmd.Parameters.AddWithValue("@ZoneID", zoneID);
            dbCmd.Parameters.AddWithValue("@NumberRecord", numberRecord);
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

        public static DataTable GetAll()
        {
            DataTable retVal;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Distributions_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };
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
        public static List<DistributionInfo> GetEntitys()
        {
            var items = new List<DistributionInfo>();
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Distributions_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };

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


        public static void Delete(int distribution_ID)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Distributions_Delete", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Distribution_ID", distribution_ID);
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
        public static int Insert(DistributionInfo distributionInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Distributions_Insert", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Distribution_ContentID", distributionInfo.Distribution_ContentID);
            dbCmd.Parameters.AddWithValue("@Distribution_ZoneID", distributionInfo.Distribution_ZoneID);
            dbCmd.Parameters.AddWithValue("@Distribution_CreateDate", distributionInfo.Distribution_CreateDate);
            dbCmd.Parameters.AddWithValue("@Distribution_Rank", distributionInfo.Distribution_Rank);
            dbCmd.Parameters.AddWithValue("@Distribution_View", distributionInfo.Distribution_View);
            dbCmd.Parameters.AddWithValue("@Distribution_Priority", distributionInfo.Distribution_Priority);
            dbCmd.Parameters.AddWithValue("@Distribution_Layout", distributionInfo.Distribution_Layout);
            dbCmd.Parameters.AddWithValue("@Distribution_DisableTeaser", distributionInfo.Distribution_DisableTeaser);
            dbCmd.Parameters.AddWithValue("@Distribution_DisableAvatar", distributionInfo.Distribution_DisableAvatar);
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

        public static void Update(DistributionInfo distributionInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Distributions_Update", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Distribution_ID", distributionInfo.Distribution_ID);
            dbCmd.Parameters.AddWithValue("@Distribution_ContentID", distributionInfo.Distribution_ContentID);
            dbCmd.Parameters.AddWithValue("@Distribution_ZoneID", distributionInfo.Distribution_ZoneID);
            dbCmd.Parameters.AddWithValue("@Distribution_CreateDate", distributionInfo.Distribution_CreateDate);
            dbCmd.Parameters.AddWithValue("@Distribution_Rank", distributionInfo.Distribution_Rank);
            dbCmd.Parameters.AddWithValue("@Distribution_View", distributionInfo.Distribution_View);
            dbCmd.Parameters.AddWithValue("@Distribution_Priority", distributionInfo.Distribution_Priority);
            dbCmd.Parameters.AddWithValue("@Distribution_Layout", distributionInfo.Distribution_Layout);
            dbCmd.Parameters.AddWithValue("@Distribution_DisableTeaser", distributionInfo.Distribution_DisableTeaser);
            dbCmd.Parameters.AddWithValue("@Distribution_DisableAvatar", distributionInfo.Distribution_DisableAvatar);
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

        public static DistributionInfo GetInfo(int distribution_ID)
        {
            DistributionInfo retVal = null;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("CMS_Distributions_GetInfo", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Distribution_ID", distribution_ID);
            try
            {
                dbConn.Open();
                var dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new DistributionInfo();
                    retVal.Distribution_ID = ConvertUtility.ToInt32(dr["Distribution_ID"]);
                    retVal.Distribution_ContentID = ConvertUtility.ToInt32(dr["Distribution_ContentID"]);
                    retVal.Distribution_ZoneID = ConvertUtility.ToInt32(dr["Distribution_ZoneID"]);
                    retVal.Distribution_CreateDate = ConvertUtility.ToDateTime(dr["Distribution_CreateDate"]);
                    retVal.Distribution_Rank = ConvertUtility.ToInt32(dr["Distribution_Rank"]);
                    retVal.Distribution_View = ConvertUtility.ToInt32(dr["Distribution_View"]);
                    retVal.Distribution_Priority = ConvertUtility.ToInt32(dr["Distribution_Priority"]);
                    retVal.Distribution_Layout = ConvertUtility.ToString(dr["Distribution_Layout"]);
                    retVal.Distribution_DisableTeaser = ConvertUtility.ToBoolean(dr["Distribution_DisableTeaser"]);
                    retVal.Distribution_DisableAvatar = ConvertUtility.ToBoolean(dr["Distribution_DisableAvatar"]);
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        private static DistributionInfo CreateEntityFromReader(IDataReader reader)
        {
            var item = new DistributionInfo();
            try { if (!reader.IsDBNull(reader.GetOrdinal("Distribution_ID"))) item.Distribution_ID = ConvertUtility.ToInt32(reader["Distribution_ID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Distribution_ContentID"))) item.Distribution_ContentID = ConvertUtility.ToInt32(reader["Distribution_ContentID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Distribution_ZoneID"))) item.Distribution_ZoneID = ConvertUtility.ToInt32(reader["Distribution_ZoneID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Distribution_CreateDate"))) item.Distribution_CreateDate = ConvertUtility.ToDateTime(reader["Distribution_CreateDate"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Distribution_Rank"))) item.Distribution_Rank = ConvertUtility.ToInt32(reader["Distribution_Rank"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Distribution_View"))) item.Distribution_View = ConvertUtility.ToInt32(reader["Distribution_View"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Distribution_Priority"))) item.Distribution_Priority = ConvertUtility.ToInt32(reader["Distribution_Priority"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Distribution_Layout"))) item.Distribution_Layout = ConvertUtility.ToString(reader["Distribution_Layout"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Distribution_DisableTeaser"))) item.Distribution_DisableTeaser = ConvertUtility.ToBoolean(reader["Distribution_DisableTeaser"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Distribution_DisableAvatar"))) item.Distribution_DisableAvatar = ConvertUtility.ToBoolean(reader["Distribution_DisableAvatar"]); }
            catch { }
            return item;
        }


    }
}
