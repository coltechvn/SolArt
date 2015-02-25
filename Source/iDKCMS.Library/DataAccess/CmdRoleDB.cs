using System.Data;
using System.Data.SqlClient;

namespace iDKCMS.Library.DataAccess
{
	public class CmdRoleDB
	{
		public static bool CheckRole(int userID, int cmdID)
		{
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_UserCmdRoles_CheckRole", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.AddWithValue("@UserID", userID);
			dbCmd.Parameters.AddWithValue("@CmdID", cmdID);
			dbCmd.Parameters.AddWithValue("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
			try
			{
				dbConn.Open();
				dbCmd.ExecuteNonQuery();
				return ((int) dbCmd.Parameters["@RETURN_VALUE"].Value) > 0;
			}
			finally
			{
				dbConn.Close();
			}
		}

		public static DataTable GetAllRolesForUser(int userID)
		{
			DataTable retVal = null;
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_Cmds_GetAllRolesForUser", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.AddWithValue("@UserID", userID);
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

		public static DataTable GetUserRoles(int userID)
		{
			DataTable retVal = null;
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_UserCmdRoles_GetRoles", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.AddWithValue("@UserID", userID);
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

		public static void UserAddRole(int userID, int cmdID)
		{
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_UserCmdRoles_Insert", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.AddWithValue("@UserID", userID);
			dbCmd.Parameters.AddWithValue("@CmdID", cmdID);
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

		public static void UserRemoverRole(int userID, int cmdID)
		{
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_UserCmdRoles_Remover", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.AddWithValue("@UserID", userID);
			dbCmd.Parameters.AddWithValue("@CmdID", cmdID);
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

		public static DataTable GetGroupRoles(int groupID)
		{
			DataTable retVal = null;
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_GroupCmdRoles_GetRoles", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.AddWithValue("@GroupID", groupID);
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

		public static void GroupAddRole(int groupID, int cmdID)
		{
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_GroupCmdRoles_Insert", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.AddWithValue("@GroupID", groupID);
			dbCmd.Parameters.AddWithValue("@CmdID", cmdID);
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

		public static void GroupRemoverRole(int groupID, int cmdID)
		{
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_GroupCmdRoles_Remover", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.AddWithValue("@GroupID", groupID);
			dbCmd.Parameters.AddWithValue("@CmdID", cmdID);
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