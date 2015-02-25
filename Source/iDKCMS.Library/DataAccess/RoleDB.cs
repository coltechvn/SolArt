using System.Data;
using System.Data.SqlClient;

namespace iDKCMS.Library.DataAccess
{
    public class RoleDB
    {
        public static bool CheckRole(int userID, int role)
        {
            int retVal = 0;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("CMS_UserRoles_CheckRole", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@UserID", userID);
            dbCmd.Parameters.Add("@Role", role);
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
            return retVal == 0 ? false : true;
        }

        public static DataTable GetByUserID(int userID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("CMS_UserRoles_GetByUserID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@UserID", userID);
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

        public static void SetUserCMSRoles(int userID, string lang, string cmsRoles)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("CMS_UserCMSRoles_SetUserCMSRoles", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@UserID", userID);
            dbCmd.Parameters.Add("@Lang", lang);
            dbCmd.Parameters.Add("@CMSRoles", cmsRoles);
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

        public static string GetUserCMSRoles(int userID, string lang)
        {
            string retVal = string.Empty;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("CMS_UserCMSRoles_GetUserCMSRoles", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@UserID", userID);
            dbCmd.Parameters.Add("@Lang", lang);
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

        public static void AddUserRole(int userID, int role)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("CMS_UserRoles_AddUserRole", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@UserID", userID);
            dbCmd.Parameters.Add("@Role", role);
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

        public static void RemoverUserRole(int userID, int role)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("CMS_UserRoles_RemoverUserRole", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@UserID", userID);
            dbCmd.Parameters.Add("@Role", role);
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
    }
}