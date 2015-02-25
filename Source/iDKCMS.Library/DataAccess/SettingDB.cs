using System.Data;
using System.Data.SqlClient;

namespace iDKCMS.Library.DataAccess
{
    public class SettingDB
    {
        public static string GetValue(string settingName)
        {
            string retVal = string.Empty;

            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Main_Settings_GetValue", dbConn) {CommandType = CommandType.StoredProcedure};

            dbCmd.Parameters.AddWithValue("@Setting_Name", settingName);
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

        public static void SetValue(string name, string value)
        {
            if (name == string.Empty) return;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Main_Settings_SetValue", dbConn) {CommandType = CommandType.StoredProcedure};
            dbCmd.Parameters.AddWithValue("@Setting_Name", name);
            SqlParameter body = dbCmd.Parameters.AddWithValue("@Setting_Value", SqlDbType.NText);
            body.Value = value;

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

        public static void Delete(int settingId)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Main_Settings_Delete", dbConn) {CommandType = CommandType.StoredProcedure};
            dbCmd.Parameters.AddWithValue("@Setting_Id", settingId);
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