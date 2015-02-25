using System.Data;
using System.Data.SqlClient;

namespace iDKCMS.Library.DataAccess
{
	public class GroupMemberDB
	{
		public static DataTable GetUserGroups(int userID)
		{
			DataTable retVal = null;
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_GroupMembers_GetUserGroups", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
            SqlParameter UserID = dbCmd.Parameters.Add("@UserID", SqlDbType.Int, 4);
            UserID.Value = userID;            
			
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

		public static void AddUser(int userID, int groupID)
		{
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_GroupMembers_AddUser", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
            SqlParameter UserID = dbCmd.Parameters.Add("@UserID", SqlDbType.Int, 4);
            UserID.Value = userID;
            SqlParameter GroupID = dbCmd.Parameters.Add("@GroupID", SqlDbType.Int, 4);
            GroupID.Value = groupID;            
			
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

		public static void RemoverUser(int userID, int groupID)
		{
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_GroupMembers_RemoverUser", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
            SqlParameter UserID = dbCmd.Parameters.Add("@UserID", SqlDbType.Int, 4);
            UserID.Value = userID;
            SqlParameter GroupID = dbCmd.Parameters.Add("@GroupID", SqlDbType.Int, 4);
            GroupID.Value = groupID;     
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

		public static DataTable GetGroupMembers(int groupID)
		{
			DataTable retVal = null;
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_GroupMembers_GetGroupMembers", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
            SqlParameter GroupID = dbCmd.Parameters.Add("@GroupID", SqlDbType.Int, 4);
            GroupID.Value = groupID;     
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

	}
}