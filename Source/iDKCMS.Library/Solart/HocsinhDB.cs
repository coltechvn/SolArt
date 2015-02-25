using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace iDKCMS.Library.Solart
{
    public class HocsinhDB
    {
        public static DataTable GetAll()
        {
            DataTable retVal;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Hocsinh_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };
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
        public static List<HocsinhInfo> GetEntitys()
        {
            var items = new List<HocsinhInfo>();
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Hocsinh_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };

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


        public static void Delete(int hocsinh_ID)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Hocsinh_Delete", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Hocsinh_ID", hocsinh_ID);
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
        public static int Insert(HocsinhInfo hocsinhInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Hocsinh_Insert", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Hocsinh_Name", hocsinhInfo.Hocsinh_Name);
            dbCmd.Parameters.AddWithValue("@Hocsinh_Parent", hocsinhInfo.Hocsinh_Parent);
            dbCmd.Parameters.AddWithValue("@Hocsinh_Email", hocsinhInfo.Hocsinh_Email);
            dbCmd.Parameters.AddWithValue("@Hocsinh_Tel", hocsinhInfo.Hocsinh_Tel);
            dbCmd.Parameters.AddWithValue("@Hocsinh_Address", hocsinhInfo.Hocsinh_Address);
            dbCmd.Parameters.AddWithValue("@Hocsinh_Birthday", hocsinhInfo.Hocsinh_Birthday);
            dbCmd.Parameters.AddWithValue("@Hocsinh_Note", hocsinhInfo.Hocsinh_Note);
            dbCmd.Parameters.AddWithValue("@Hocsinh_CreateDate", hocsinhInfo.Hocsinh_CreateDate);
            dbCmd.Parameters.AddWithValue("@Hocsinh_IsLearning", hocsinhInfo.Hocsinh_IsLearning);
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

        public static void Update(HocsinhInfo hocsinhInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Hocsinh_Update", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Hocsinh_ID", hocsinhInfo.Hocsinh_ID);
            dbCmd.Parameters.AddWithValue("@Hocsinh_Name", hocsinhInfo.Hocsinh_Name);
            dbCmd.Parameters.AddWithValue("@Hocsinh_Parent", hocsinhInfo.Hocsinh_Parent);
            dbCmd.Parameters.AddWithValue("@Hocsinh_Email", hocsinhInfo.Hocsinh_Email);
            dbCmd.Parameters.AddWithValue("@Hocsinh_Tel", hocsinhInfo.Hocsinh_Tel);
            dbCmd.Parameters.AddWithValue("@Hocsinh_Address", hocsinhInfo.Hocsinh_Address);
            dbCmd.Parameters.AddWithValue("@Hocsinh_Birthday", hocsinhInfo.Hocsinh_Birthday);
            dbCmd.Parameters.AddWithValue("@Hocsinh_Note", hocsinhInfo.Hocsinh_Note);
            dbCmd.Parameters.AddWithValue("@Hocsinh_CreateDate", hocsinhInfo.Hocsinh_CreateDate);
            dbCmd.Parameters.AddWithValue("@Hocsinh_IsLearning", hocsinhInfo.Hocsinh_IsLearning);
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

        public static HocsinhInfo GetInfo(int hocsinh_ID)
        {
            HocsinhInfo retVal = null;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Solart_Hocsinh_GetInfo", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Hocsinh_ID", hocsinh_ID);
            try
            {
                dbConn.Open();
                var dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new HocsinhInfo();
                    retVal.Hocsinh_ID = ConvertUtility.ToInt32(dr["Hocsinh_ID"]);
                    retVal.Hocsinh_Name = ConvertUtility.ToString(dr["Hocsinh_Name"]);
                    retVal.Hocsinh_Parent = ConvertUtility.ToString(dr["Hocsinh_Parent"]);
                    retVal.Hocsinh_Email = ConvertUtility.ToString(dr["Hocsinh_Email"]);
                    retVal.Hocsinh_Tel = ConvertUtility.ToString(dr["Hocsinh_Tel"]);
                    retVal.Hocsinh_Address = ConvertUtility.ToString(dr["Hocsinh_Address"]);
                    retVal.Hocsinh_Birthday = ConvertUtility.ToString(dr["Hocsinh_Birthday"]);
                    retVal.Hocsinh_Note = ConvertUtility.ToString(dr["Hocsinh_Note"]);
                    retVal.Hocsinh_CreateDate = ConvertUtility.ToDateTime(dr["Hocsinh_CreateDate"]);
                    retVal.Hocsinh_IsLearning = ConvertUtility.ToBoolean(dr["Hocsinh_IsLearning"]);
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        private static HocsinhInfo CreateEntityFromReader(IDataReader reader)
        {
            var item = new HocsinhInfo();
            try { if (!reader.IsDBNull(reader.GetOrdinal("Hocsinh_ID"))) item.Hocsinh_ID = ConvertUtility.ToInt32(reader["Hocsinh_ID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Hocsinh_Name"))) item.Hocsinh_Name = ConvertUtility.ToString(reader["Hocsinh_Name"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Hocsinh_Parent"))) item.Hocsinh_Parent = ConvertUtility.ToString(reader["Hocsinh_Parent"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Hocsinh_Email"))) item.Hocsinh_Email = ConvertUtility.ToString(reader["Hocsinh_Email"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Hocsinh_Tel"))) item.Hocsinh_Tel = ConvertUtility.ToString(reader["Hocsinh_Tel"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Hocsinh_Address"))) item.Hocsinh_Address = ConvertUtility.ToString(reader["Hocsinh_Address"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Hocsinh_Birthday"))) item.Hocsinh_Birthday = ConvertUtility.ToString(reader["Hocsinh_Birthday"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Hocsinh_Note"))) item.Hocsinh_Note = ConvertUtility.ToString(reader["Hocsinh_Note"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Hocsinh_CreateDate"))) item.Hocsinh_CreateDate = ConvertUtility.ToDateTime(reader["Hocsinh_CreateDate"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Hocsinh_IsLearning"))) item.Hocsinh_IsLearning = ConvertUtility.ToBoolean(reader["Hocsinh_IsLearning"]); }
            catch { }
            return item;
        }


    }
}
