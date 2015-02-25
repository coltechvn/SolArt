using System;
using System.Data;
using System.Data.SqlClient;
using iDKCMS.Library.Data;

namespace iDKCMS.Library.DataAccess
{
    public class UserDB
    {
        public static int GetIDByEmail(string _email)
        {
            var retVal = 0;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);

            var dbCmd = new SqlCommand("Main_Users_GetIDByEmail", dbConn) {CommandType = CommandType.StoredProcedure};
            dbCmd.Parameters.AddWithValue("@Email", _email);

            try
            {
                dbConn.Open();
                var dr = dbCmd.ExecuteReader();
                if (dr.Read()) retVal = dr.GetInt32(0);
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        public static string GetEmailByID(int _userid)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);

            var dbCmd = new SqlCommand("Main_Users_GetEmailByID", dbConn) {CommandType = CommandType.StoredProcedure};
            dbCmd.Parameters.AddWithValue("@UserID", _userid);
            try
            {
                dbConn.Open();
                var dr = dbCmd.ExecuteReader();
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

        public static UserInfo GetInfoByEmail(string _email)
        {
            return GetInfo(GetIDByEmail(_email));
        }

        public static bool CheckAccount(string _email, string _password)
        {
            int userID;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);

            var dbCmd = new SqlCommand("Main_Users_CheckAccount", dbConn) {CommandType = CommandType.StoredProcedure};
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

        public static DataTable GetAll()
        {
            DataTable retVal;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Main_Users_GetAll", dbConn) {CommandType = CommandType.StoredProcedure};
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

        public static void Delete(int _user_ID)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Main_Users_Delete", dbConn) {CommandType = CommandType.StoredProcedure};
            dbCmd.Parameters.AddWithValue("@User_ID", _user_ID);
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

        public static int Insert(UserInfo _userInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Main_Users_Insert", dbConn) {CommandType = CommandType.StoredProcedure};
            dbCmd.Parameters.AddWithValue("@User_Email", _userInfo.User_Email);
            dbCmd.Parameters.AddWithValue("@User_FullName", _userInfo.User_FullName);
            dbCmd.Parameters.AddWithValue("@User_Password", _userInfo.User_Password);
            dbCmd.Parameters.AddWithValue("@User_Gender", _userInfo.User_Gender);
            dbCmd.Parameters.AddWithValue("@User_Birthday", _userInfo.User_Birthday);
            dbCmd.Parameters.AddWithValue("@User_Address", _userInfo.User_Address);
            dbCmd.Parameters.AddWithValue("@User_Phone", _userInfo.User_Phone);
            dbCmd.Parameters.AddWithValue("@User_SuperAdmin", _userInfo.User_SuperAdmin);
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

        public static void Update(UserInfo _userInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Main_Users_Update", dbConn) {CommandType = CommandType.StoredProcedure};
            dbCmd.Parameters.AddWithValue("@User_ID", _userInfo.User_ID);
            dbCmd.Parameters.AddWithValue("@User_Email", _userInfo.User_Email);
            dbCmd.Parameters.AddWithValue("@User_FullName", _userInfo.User_FullName);
            dbCmd.Parameters.AddWithValue("@User_Password", _userInfo.User_Password);
            dbCmd.Parameters.AddWithValue("@User_Gender", _userInfo.User_Gender);
            dbCmd.Parameters.AddWithValue("@User_Birthday", _userInfo.User_Birthday);
            dbCmd.Parameters.AddWithValue("@User_Address", _userInfo.User_Address);
            dbCmd.Parameters.AddWithValue("@User_Phone", _userInfo.User_Phone);
            dbCmd.Parameters.AddWithValue("@User_SuperAdmin", _userInfo.User_SuperAdmin);
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

        public static UserInfo GetInfo(int _user_ID)
        {
            UserInfo retVal = null;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Main_Users_GetInfo", dbConn) {CommandType = CommandType.StoredProcedure};
            dbCmd.Parameters.AddWithValue("@User_ID", _user_ID);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new UserInfo
                    {
                        User_ID = Convert.ToInt32(dr["User_ID"]),
                        User_Email = Convert.ToString(dr["User_Email"]),
                        User_FullName = Convert.ToString(dr["User_FullName"]),
                        User_Password = Convert.ToString(dr["User_Password"]),
                        User_Gender = Convert.ToBoolean(dr["User_Gender"]),
                        User_Birthday = Convert.ToString(dr["User_Birthday"]),
                        User_Address = Convert.ToString(dr["User_Address"]),
                        User_Phone = Convert.ToString(dr["User_Phone"]),
                        User_SuperAdmin = Convert.ToBoolean(dr["User_SuperAdmin"])
                    };
                }
                dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
    }
}