using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using iDKCMS.Library.Data;

namespace iDKCMS.Library.DataAccess
{
	public class CmdDB
	{
		public static void SetIndex(int cmdID, int index)
		{
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_Cmds_SetIndex", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
            SqlParameter CmdID = dbCmd.Parameters.Add("CmdID", SqlDbType.Int, 4);
            CmdID.Value = cmdID;
            SqlParameter Index = dbCmd.Parameters.Add("Index", SqlDbType.Int, 4);
            Index.Value = index;
			
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

		public static CmdInfo GetInfoByCmd(string cmd)
		{
			return GetInfo(GetIDByCmd(cmd));
		}

		public static int GetIDByCmd(string cmd)
		{
			int retVal = 0;
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_Cmds_GetIDByCmd", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
            SqlParameter Cmd_Value = dbCmd.Parameters.Add("Cmd_Value", SqlDbType.NVarChar , 200);
            Cmd_Value.Value = cmd;
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
			return retVal;
		}

		public static int GetParentID(int cmdID)
		{
			int retVal = 0;
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_Cmds_GetParentID", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
            SqlParameter CmdID = dbCmd.Parameters.Add("CmdID", SqlDbType.Int, 4);
            CmdID.Value = cmdID;
           
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
			return retVal;
		}

		public static int GetChildCount(int cmdID)
		{
			int retVal = 0;
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_Cmds_GetChildCount", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
            SqlParameter CmdID = dbCmd.Parameters.Add("CmdID", SqlDbType.Int, 4);
            CmdID.Value = cmdID;
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
			return retVal;
		}

		public static DataTable GetByParentID(int parentID)
		{
			DataTable retVal = null;
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_Cmds_GetByParentID", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
            SqlParameter ParentID = dbCmd.Parameters.Add("@ParentID", SqlDbType.Int, 4);
            ParentID.Value = parentID;
           
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
			DataTable retVal = null;
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_Cmds_GetAll", dbConn);
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

		public static void Delete(int _cmd_ID)
		{
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_Cmds_Delete", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
            SqlParameter CmdID = dbCmd.Parameters.Add("@Cmd_ID", SqlDbType.Int, 4);
            CmdID.Value = _cmd_ID;
            try
			{
				dbConn.Open();
				dbCmd.ExecuteNonQuery();
			}
            catch(Exception ex)
            {
                string error = ex.Message;
            }
			finally
			{
				dbConn.Close();
			}
		}

		public static int Insert(CmdInfo _cmdInfo)
		{
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_Cmds_Insert", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Cmd_Name = dbCmd.Parameters.Add("@Cmd_Name", SqlDbType.NVarChar, 200);
            Cmd_Name.Value = _cmdInfo.Cmd_Name;
            SqlParameter Cmd_Value = dbCmd.Parameters.Add("@Cmd_Value", SqlDbType.NVarChar, 200);
            Cmd_Value.Value = _cmdInfo.Cmd_Value;
            SqlParameter Cmd_Params = dbCmd.Parameters.Add("@Cmd_Params", SqlDbType.NVarChar, 200);
            Cmd_Params.Value = _cmdInfo.Cmd_Params;
            SqlParameter Cmd_Url = dbCmd.Parameters.Add("@Cmd_Url", SqlDbType.NVarChar, 200);
            Cmd_Url.Value = _cmdInfo.Cmd_Url;
            SqlParameter Cmd_Path = dbCmd.Parameters.Add("@Cmd_Path", SqlDbType.NVarChar, 200);
            Cmd_Path.Value = _cmdInfo.Cmd_Path;           
            SqlParameter RETURN_VALUE = dbCmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int, 4);
            RETURN_VALUE.Direction = ParameterDirection.ReturnValue;
            SqlParameter Cmd_ParentID = dbCmd.Parameters.Add("@Cmd_ParentID", SqlDbType.Int, 4);
            Cmd_ParentID.Value = _cmdInfo.Cmd_ParentID;
            SqlParameter Cmd_Enable = dbCmd.Parameters.Add("@Cmd_Enable", SqlDbType.Bit, 1);
            Cmd_Enable.Value = _cmdInfo.Cmd_Enable;
            SqlParameter Cmd_Visible = dbCmd.Parameters.Add("@Cmd_Visible", SqlDbType.Bit, 1);
            Cmd_Visible.Value = _cmdInfo.Cmd_Visible;
          

			try
			{
				dbConn.Open();
				dbCmd.ExecuteNonQuery();
			}
            catch(Exception ex)
            {
                string s = ex.Message;
            }
			finally
			{
				dbConn.Close();
			}
            return (int)dbCmd.Parameters["@RETURN_VALUE"].Value;
		}

		public static void Update(CmdInfo _cmdInfo)
		{
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_Cmds_Update", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
            SqlParameter Cmd_ID = dbCmd.Parameters.Add("@Cmd_ID", SqlDbType.Int, 4);
            Cmd_ID.Value = _cmdInfo.Cmd_ID;           
            SqlParameter Cmd_Name = dbCmd.Parameters.Add("@Cmd_Name", SqlDbType.NVarChar, 200);
            Cmd_Name.Value = _cmdInfo.Cmd_Name;
            SqlParameter Cmd_Value = dbCmd.Parameters.Add("@Cmd_Value", SqlDbType.NVarChar, 200);
            Cmd_Value.Value = _cmdInfo.Cmd_Value;
            SqlParameter Cmd_Params = dbCmd.Parameters.Add("@Cmd_Params", SqlDbType.NVarChar, 200);
            Cmd_Params.Value = _cmdInfo.Cmd_Params;
            SqlParameter Cmd_Url = dbCmd.Parameters.Add("@Cmd_Url", SqlDbType.NVarChar, 200);
            Cmd_Url.Value = _cmdInfo.Cmd_Url;
            SqlParameter Cmd_Path = dbCmd.Parameters.Add("@Cmd_Path", SqlDbType.NVarChar, 200);
            Cmd_Path.Value = _cmdInfo.Cmd_Path;
            SqlParameter RETURN_VALUE = dbCmd.Parameters.Add("RETURN_VALUE", SqlDbType.Int, 4);
            RETURN_VALUE.Direction = ParameterDirection.ReturnValue;
            SqlParameter Cmd_ParentID = dbCmd.Parameters.Add("@Cmd_ParentID", SqlDbType.Int, 4);
            Cmd_ParentID.Value = _cmdInfo.Cmd_ParentID;
            SqlParameter Cmd_Enable = dbCmd.Parameters.Add("@Cmd_Enable", SqlDbType.Bit, 1);
            Cmd_Enable.Value = _cmdInfo.Cmd_Enable;
            SqlParameter Cmd_Index = dbCmd.Parameters.Add("@Cmd_Index", SqlDbType.Int, 4);
            Cmd_Index.Value = _cmdInfo.Cmd_Index ;
            SqlParameter Cmd_Visible = dbCmd.Parameters.Add("@Cmd_Visible", SqlDbType.Bit, 1);
            Cmd_Visible.Value = _cmdInfo.Cmd_Visible;
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

		public static CmdInfo GetInfo(int _cmd_ID)
		{
			CmdInfo retVal = null;
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Main_Cmds_GetInfo", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
            SqlParameter Cmd_ID = dbCmd.Parameters.Add("@Cmd_ID", SqlDbType.Int, 4);
            Cmd_ID.Value = _cmd_ID;           
           
			try
			{
				dbConn.Open();
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.Read())
				{
					retVal = new CmdInfo();
					retVal.Cmd_ID = Convert.ToInt32(dr["Cmd_ID"]);
					retVal.Cmd_Name = Convert.ToString(dr["Cmd_Name"]);
					retVal.Cmd_Value = Convert.ToString(dr["Cmd_Value"]);
					retVal.Cmd_Params = Convert.ToString(dr["Cmd_Params"]);
					retVal.Cmd_ParentID = Convert.ToInt32(dr["Cmd_ParentID"]);
					retVal.Cmd_Index = Convert.ToInt32(dr["Cmd_Index"]);
					retVal.Cmd_Url = Convert.ToString(dr["Cmd_Url"]);
					retVal.Cmd_Path = Convert.ToString(dr["Cmd_Path"]);
					retVal.Cmd_Enable = Convert.ToBoolean(dr["Cmd_Enable"]);
					retVal.Cmd_Visible = Convert.ToBoolean(dr["Cmd_Visible"]);
				}
				if (dr != null) dr.Close();
			}
			finally
			{
				dbConn.Close();
			}
			return retVal;
		}

		public static void FillToListBox(ListItemCollection lstCmds)
		{
			lstCmds.Clear();
			DataTable dtItems = GetByParentID(0);
			foreach (DataRow row in dtItems.Rows)
			{
				ListItem item = new ListItem();
				item.Value = row["Cmd_ID"].ToString();
				item.Text = row["Cmd_Name"].ToString();
				item.Attributes.Add("Level", "0");
				lstCmds.Add(item);
				LoadCmdItem(lstCmds, item);
			}
		}

		private static void LoadCmdItem(ListItemCollection lstCmds, ListItem curItem)
		{
			int level = Convert.ToInt32(curItem.Attributes["Level"]);
			level += 1;
			int curID = Convert.ToInt32(curItem.Value);
			DataTable dtChild = GetByParentID(curID);
			foreach (DataRow row in dtChild.Rows)
			{
				ListItem childItem = new ListItem();
				childItem.Text = MiscUtility.StringIndent(level) + row["Cmd_Name"].ToString();
				childItem.Value = row["Cmd_ID"].ToString();
				childItem.Attributes.Add("Level", level.ToString());
				lstCmds.Add(childItem);
				LoadCmdItem(lstCmds, childItem);
			}
		}

	}
}