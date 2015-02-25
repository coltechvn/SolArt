using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using iDKCMS.Library.Data;

namespace iDKCMS.Library.DataAccess
{
    public class MemberDB
    {
        public static MemberInfo GetInfoByEmail(string _email)
        {
            return GetInfo(GetIDByEmail(_email));
        }

        public static int GetIDByEmail(string _email)
        {
            int retVal = 0;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("Main_Members_GetIDByEmail", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Email", _email);

            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read()) retVal = dr.GetInt32(0);
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        public static bool CheckAccount(string _email, string _password)
        {
            int userID = 0;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("Main_Members_CheckAccount", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Email", _email);
            dbCmd.Parameters.AddWithValue("@Password", SecurityMethod.MD5Encrypt(_password));

            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read()) userID = dr.GetInt32(0);
                else userID = 0;
            }
            finally
            {
                dbConn.Close();
            }
            return userID > 0;
        }

        public static DataTable GetActive()
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Main_Members_GetActive", dbConn);
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
            var dbCmd = new SqlCommand("Main_Members_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };
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
        public static List<MemberInfo> GetEntitys()
        {
            var items = new List<MemberInfo>();
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Main_Members_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };

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


        public static void Delete(int member_ID)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Main_Members_Delete", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Member_ID", member_ID);
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
        public static int Insert(MemberInfo memberInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Main_Members_Insert", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Member_Email", memberInfo.Member_Email);
            dbCmd.Parameters.AddWithValue("@Member_Password", memberInfo.Member_Password);
            dbCmd.Parameters.AddWithValue("@Member_Fullname", memberInfo.Member_Fullname);
            dbCmd.Parameters.AddWithValue("@Member_Gender", memberInfo.Member_Gender);
            dbCmd.Parameters.AddWithValue("@Member_Avatar", memberInfo.Member_Avatar);
            dbCmd.Parameters.AddWithValue("@Member_Tel", memberInfo.Member_Tel);
            dbCmd.Parameters.AddWithValue("@Member_Address", memberInfo.Member_Address);
            dbCmd.Parameters.AddWithValue("@Member_District", memberInfo.Member_District);
            dbCmd.Parameters.AddWithValue("@Member_City", memberInfo.Member_City);
            dbCmd.Parameters.AddWithValue("@Member_Rank", memberInfo.Member_Rank);
            dbCmd.Parameters.AddWithValue("@Member_Birthday", memberInfo.Member_Birthday);
            dbCmd.Parameters.AddWithValue("@Member_Active", memberInfo.Member_Active);
            dbCmd.Parameters.AddWithValue("@Member_ActiveCode", memberInfo.Member_ActiveCode);
            dbCmd.Parameters.AddWithValue("@Member_IsForgotPassword", memberInfo.Member_IsForgotPassword);
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

        public static void Update(MemberInfo memberInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Main_Members_Update", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Member_ID", memberInfo.Member_ID);
            dbCmd.Parameters.AddWithValue("@Member_Email", memberInfo.Member_Email);
            dbCmd.Parameters.AddWithValue("@Member_Password", memberInfo.Member_Password);
            dbCmd.Parameters.AddWithValue("@Member_Fullname", memberInfo.Member_Fullname);
            dbCmd.Parameters.AddWithValue("@Member_Gender", memberInfo.Member_Gender);
            dbCmd.Parameters.AddWithValue("@Member_Avatar", memberInfo.Member_Avatar);
            dbCmd.Parameters.AddWithValue("@Member_Tel", memberInfo.Member_Tel);
            dbCmd.Parameters.AddWithValue("@Member_Address", memberInfo.Member_Address);
            dbCmd.Parameters.AddWithValue("@Member_District", memberInfo.Member_District);
            dbCmd.Parameters.AddWithValue("@Member_City", memberInfo.Member_City);
            dbCmd.Parameters.AddWithValue("@Member_Rank", memberInfo.Member_Rank);
            dbCmd.Parameters.AddWithValue("@Member_Birthday", memberInfo.Member_Birthday);
            dbCmd.Parameters.AddWithValue("@Member_Active", memberInfo.Member_Active);
            dbCmd.Parameters.AddWithValue("@Member_ActiveCode", memberInfo.Member_ActiveCode);
            dbCmd.Parameters.AddWithValue("@Member_IsForgotPassword", memberInfo.Member_IsForgotPassword);
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

        public static MemberInfo GetInfo(int member_ID)
        {
            MemberInfo retVal = null;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Main_Members_GetInfo", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Member_ID", member_ID);
            try
            {
                dbConn.Open();
                var dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new MemberInfo();
                    retVal.Member_ID = ConvertUtility.ToInt32(dr["Member_ID"]);
                    retVal.Member_Email = ConvertUtility.ToString(dr["Member_Email"]);
                    retVal.Member_Password = ConvertUtility.ToString(dr["Member_Password"]);
                    retVal.Member_Fullname = ConvertUtility.ToString(dr["Member_Fullname"]);
                    retVal.Member_Gender = ConvertUtility.ToInt32(dr["Member_Gender"]);
                    retVal.Member_Avatar = ConvertUtility.ToString(dr["Member_Avatar"]);
                    retVal.Member_Tel = ConvertUtility.ToString(dr["Member_Tel"]);
                    retVal.Member_Address = ConvertUtility.ToString(dr["Member_Address"]);
                    retVal.Member_District = ConvertUtility.ToString(dr["Member_District"]);
                    retVal.Member_City = ConvertUtility.ToString(dr["Member_City"]);
                    retVal.Member_Rank = ConvertUtility.ToInt32(dr["Member_Rank"]);
                    retVal.Member_Birthday = ConvertUtility.ToDateTime(dr["Member_Birthday"]);
                    retVal.Member_Active = ConvertUtility.ToBoolean(dr["Member_Active"]);
                    retVal.Member_ActiveCode = ConvertUtility.ToString(dr["Member_ActiveCode"]);
                    retVal.Member_IsForgotPassword = ConvertUtility.ToBoolean(dr["Member_IsForgotPassword"]);
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        private static MemberInfo CreateEntityFromReader(IDataReader reader)
        {
            var item = new MemberInfo();
            try { if (!reader.IsDBNull(reader.GetOrdinal("Member_ID"))) item.Member_ID = ConvertUtility.ToInt32(reader["Member_ID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Member_Email"))) item.Member_Email = ConvertUtility.ToString(reader["Member_Email"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Member_Password"))) item.Member_Password = ConvertUtility.ToString(reader["Member_Password"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Member_Fullname"))) item.Member_Fullname = ConvertUtility.ToString(reader["Member_Fullname"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Member_Gender"))) item.Member_Gender = ConvertUtility.ToInt32(reader["Member_Gender"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Member_Avatar"))) item.Member_Avatar = ConvertUtility.ToString(reader["Member_Avatar"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Member_Tel"))) item.Member_Tel = ConvertUtility.ToString(reader["Member_Tel"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Member_Address"))) item.Member_Address = ConvertUtility.ToString(reader["Member_Address"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Member_District"))) item.Member_District = ConvertUtility.ToString(reader["Member_District"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Member_City"))) item.Member_City = ConvertUtility.ToString(reader["Member_City"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Member_Rank"))) item.Member_Rank = ConvertUtility.ToInt32(reader["Member_Rank"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Member_Birthday"))) item.Member_Birthday = ConvertUtility.ToDateTime(reader["Member_Birthday"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Member_Active"))) item.Member_Active = ConvertUtility.ToBoolean(reader["Member_Active"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Member_ActiveCode"))) item.Member_ActiveCode = ConvertUtility.ToString(reader["Member_ActiveCode"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Member_IsForgotPassword"))) item.Member_IsForgotPassword = ConvertUtility.ToBoolean(reader["Member_IsForgotPassword"]); }
            catch { }
            return item;
        }
    }
}
