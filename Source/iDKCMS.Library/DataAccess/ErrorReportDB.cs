using System;
using System.Data;
using System.Data.SqlClient;
using iDKCMS.Library.Data;

namespace iDKCMS.Library.DataAccess
{
    public class ErrorReportDB
    {
        public static int NewReport (string _url, string _exception)
		{
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_ErrorReport_Insert", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.AddWithValue("@Error_Url", _url);
			dbCmd.Parameters.AddWithValue("@Error_String", _exception);
			dbCmd.Parameters.AddWithValue("@Error_Datetime", DateTime.Now);
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

		public static DataTable GetAll ()  
		{
			DataTable retVal = null;
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_ErrorReport_GetAll", dbConn);
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
		public static void Delete (int _error_ID)
		{
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_ErrorReport_Delete", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.AddWithValue("@Error_ID",_error_ID);
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
		public static int Insert (ErrorReportInfo _errorReporInfo)
		{
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_ErrorReport_Insert", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.AddWithValue("@Error_Url",_errorReporInfo.Error_Url);
			dbCmd.Parameters.AddWithValue("@Error_String",_errorReporInfo.Error_String);
			dbCmd.Parameters.AddWithValue("@Error_Datetime",_errorReporInfo.Error_Datetime);
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
 
		public static void Update (ErrorReportInfo _errorReporInfo)
		{
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_ErrorReport_Update", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.AddWithValue("@Error_ID",_errorReporInfo.Error_ID);
			dbCmd.Parameters.AddWithValue("@Error_Url",_errorReporInfo.Error_Url);
			dbCmd.Parameters.AddWithValue("@Error_String",_errorReporInfo.Error_String);
			dbCmd.Parameters.AddWithValue("@Error_Datetime",_errorReporInfo.Error_Datetime);
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
 
		public static ErrorReportInfo GetInfo ( int _error_ID )
		{
			ErrorReportInfo retVal = null;
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_ErrorReport_GetInfo", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.AddWithValue("@Error_ID", _error_ID);
			try 
			{
				dbConn.Open();
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.Read()) 
				{
					retVal = new ErrorReportInfo();
					retVal.Error_ID=Convert.ToInt32(dr["Error_ID"]);
					retVal.Error_Url=Convert.ToString(dr["Error_Url"]);
					retVal.Error_String=Convert.ToString(dr["Error_String"]);
					retVal.Error_Datetime=Convert.ToDateTime(dr["Error_Datetime"]);
				}
				if (dr != null)	dr.Close();
			}
			finally
			{
				dbConn.Close();
			}
			return retVal;
		}
    }
}
