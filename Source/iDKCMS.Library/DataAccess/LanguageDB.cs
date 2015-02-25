using System.Data;
using System.Data.SqlClient;

namespace iDKCMS.Library.DataAccess
{
	public class LanguageDB
	{
		public static DataTable GetAll()
		{
			DataTable retVal = null;
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_Languages_GetAll", dbConn);
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
	}
}