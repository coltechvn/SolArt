using System;
using System.Data;
using System.Data.SqlClient;
using iDKCMS.Library.Data;

namespace iDKCMS.Library.DataAccess
{
	public class GroupDB
	{
		public static DataTable GetAll()
		{
			DataTable retVal = null;
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_Groups_GetAll", dbConn);
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

		public static void Delete(int _group_ID)
		{
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_Groups_Delete", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
            SqlParameter Group_ID = dbCmd.Parameters.Add("@Group_ID", SqlDbType.Int, 4);
            Group_ID.Value = _group_ID;
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

		public static int Insert(GroupInfo _groupInfo)
		{
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_Groups_Insert", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;

            dbCmd.Parameters.AddWithValue("@Group_Name", _groupInfo.Group_Name);
            dbCmd.Parameters.AddWithValue("@Group_Description", _groupInfo.Group_Description);
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

		public static void Update(GroupInfo _groupInfo)
		{
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_Groups_Update", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
            SqlParameter Group_ID = dbCmd.Parameters.Add("@Group_ID", SqlDbType.Int, 4);
            Group_ID.Value = _groupInfo.Group_ID;            
			SqlParameter Group_Name= dbCmd.Parameters.Add("@Group_Name", SqlDbType.NVarChar, 200);
        	Group_Name.Value = _groupInfo.Group_Name;
            SqlParameter Group_Description = dbCmd.Parameters.Add("@Group_Description", SqlDbType.NVarChar, 200);
            Group_Description.Value = _groupInfo.Group_Description;
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

		public static GroupInfo GetInfo(int _group_ID)
		{
			GroupInfo retVal = null;
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_Groups_GetInfo", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
            SqlParameter Group_ID = dbCmd.Parameters.Add("@Group_ID", SqlDbType.Int, 4);
            Group_ID.Value = _group_ID;            
			
			try
			{
				dbConn.Open();
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.Read())
				{
					retVal = new GroupInfo();
					retVal.Group_ID = Convert.ToInt32(dr["Group_ID"]);
					retVal.Group_Name = Convert.ToString(dr["Group_Name"]);
					retVal.Group_Description = Convert.ToString(dr["Group_Description"]);
				}
				if (dr != null) dr.Close();
			}
			finally
			{
				dbConn.Close();
			}
			return retVal;
		}

	}
}