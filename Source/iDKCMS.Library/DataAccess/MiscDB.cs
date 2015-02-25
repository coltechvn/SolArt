using System.Data;
using System.Data.SqlClient;

namespace iDKCMS.Library.DataAccess
{
	public class MiscDB
	{
		public static int GetActiveUsers(string ip)
		{
			int retVal;
			var dbConn = new SqlConnection(AppEnv.ConnectionString);

		    var dbCmd = new SqlCommand("Main_GetActiveUsers", dbConn) {CommandType = CommandType.StoredProcedure};
		    dbCmd.Parameters.AddWithValue("@IP", ip);

		    var prmActiveUsers = new SqlParameter("@ActiveUsers", SqlDbType.Int) {Direction = ParameterDirection.Output};
		    dbCmd.Parameters.Add(prmActiveUsers);

			try
			{
				dbConn.Open();
				dbCmd.ExecuteNonQuery();
				retVal = (int) dbCmd.Parameters["@ActiveUsers"].Value;
			}
			finally
			{
				dbConn.Close();
			}
			return retVal;
		}
	}
}