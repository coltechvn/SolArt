using System;
using System.Data;
using System.Data.SqlClient;
using iDKCMS.Library.Data;
using System.Web.UI.WebControls;

namespace iDKCMS.Library.DataAccess
{
    public class AdvertiseDB
    {
        public static DataTable GetByPositionID(int _positionID, bool _isEnable, string _paramCollections)
        {
            string enable = _isEnable ? "1" : "0";
            string strSelectByOnlyID = " SELECT * FROM Adv_Advertises WHERE Advertise_Lang = '" + AppEnv.GetLanguage() + "' AND Advertise_PositionID = " + _positionID +
                " AND Advertise_Enable = " + enable + " AND PATINDEX('%|' + CAST({0} as varchar) + '|%','|' + Advertise_Params ) >0 ";
            string[] arrParams = _paramCollections.Split(new char[] { '|' });
            string strCommand = string.Empty;
            foreach (string attachID in arrParams)
            {
                int id = ConvertUtility.ToInt32(attachID, -1);
                if (id != -1) strCommand += string.Format(strSelectByOnlyID, id) + " UNION";
            }
            if (strCommand.Length > 0)
            {
                strCommand = strCommand.Substring(0, strCommand.Length - 6) + " ORDER BY Advertise_Priority ASC";
            }
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand(strCommand, dbConn);
            dbCmd.CommandType = CommandType.Text;
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
        public static DataTable GetAvailables(int _positionID, int _paramID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("Adv_Advertises_GetAvailables", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@PositionID", _positionID);
            dbCmd.Parameters.AddWithValue("@AttachID", _paramID);
            dbCmd.Parameters.AddWithValue("@Lang", AppEnv.GetLanguageFrontEnd());
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

        public static DataTable GetLimitedAvailables(int _positionID, int _paramID, int _numberRecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("Adv_Advertises_GetLimitedAvailables", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@PositionID", _positionID);
            dbCmd.Parameters.AddWithValue("@AttachID", _paramID);
            dbCmd.Parameters.AddWithValue("@Lang", AppEnv.GetLanguageFrontEnd());
            dbCmd.Parameters.AddWithValue("@NumberRecord", _numberRecord);
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

        public static void SetPriority(int _advertise_ID, int _newPriority)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Adv_Advertises_SetPriority", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            SqlParameter Advertise_ID = dbCmd.Parameters.Add("@Advertise_ID", SqlDbType.Int, 4);
            Advertise_ID.Value = _advertise_ID;
            SqlParameter Advertise_Priority = dbCmd.Parameters.Add("@Advertise_Priority", SqlDbType.Int, 4);
            Advertise_Priority.Value = _newPriority;

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
        public static void Clicks(int _advertise_ID, int _clickCount)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Adv_Advertises_Clicks", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            SqlParameter Advertise_ID = dbCmd.Parameters.Add("@Advertise_ID", SqlDbType.Int, 4);
            Advertise_ID.Value = _advertise_ID;
            SqlParameter ClickCount = dbCmd.Parameters.Add("@ClickCount", SqlDbType.Int, 4);
            ClickCount.Value = _clickCount;
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

        public static void Delete(int _advertise_ID)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Adv_Advertises_Delete", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            SqlParameter Advertise_ID = dbCmd.Parameters.Add("@Advertise_ID", SqlDbType.Int, 4);
            Advertise_ID.Value = _advertise_ID;
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

        public static int Insert(AdvertiseInfo _advertiseInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Adv_Advertises_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Advertise_Name = dbCmd.Parameters.Add("@Advertise_Name", SqlDbType.NVarChar, 500);
            Advertise_Name.Value = _advertiseInfo.Advertise_Name;
            SqlParameter Advertise_Path = dbCmd.Parameters.Add("@Advertise_Path", SqlDbType.NVarChar, 500);
            Advertise_Path.Value = _advertiseInfo.Advertise_Path;
            SqlParameter Advertise_Type = dbCmd.Parameters.Add("@Advertise_Type", SqlDbType.NVarChar, 500);
            Advertise_Type.Value = _advertiseInfo.Advertise_Type;
            SqlParameter Advertise_RedirectURL = dbCmd.Parameters.Add("@Advertise_RedirectURL", SqlDbType.NVarChar, 500);
            Advertise_RedirectURL.Value = _advertiseInfo.Advertise_RedirectURL;
            SqlParameter Advertise_Params = dbCmd.Parameters.Add("@Advertise_Params", SqlDbType.NVarChar, 500);
            Advertise_Params.Value = _advertiseInfo.Advertise_Params;
            SqlParameter Advertise_Lang = dbCmd.Parameters.Add("@Advertise_Lang", SqlDbType.NVarChar, 500);
            Advertise_Lang.Value = _advertiseInfo.Advertise_Lang;
            SqlParameter Advertise_Enable = dbCmd.Parameters.Add("@Advertise_Enable", SqlDbType.Bit, 1);
            Advertise_Enable.Value = _advertiseInfo.Advertise_Enable;
            SqlParameter Advertise_PositionID = dbCmd.Parameters.Add("@Advertise_PositionID", SqlDbType.Int, 4);
            Advertise_PositionID.Value = _advertiseInfo.Advertise_PositionID;
            SqlParameter Advertise_Width = dbCmd.Parameters.Add("@Advertise_Width", SqlDbType.Int, 4);
            Advertise_Width.Value = _advertiseInfo.Advertise_Width;
            SqlParameter Advertise_Height = dbCmd.Parameters.Add("@Advertise_Height", SqlDbType.Int, 4);
            Advertise_Height.Value = _advertiseInfo.Advertise_Height;
            SqlParameter Advertise_StartDate = dbCmd.Parameters.Add("@Advertise_StartDate", SqlDbType.DateTime, 8);
            Advertise_StartDate.Value = _advertiseInfo.Advertise_StartDate;
            SqlParameter Advertise_EndDate = dbCmd.Parameters.Add("@Advertise_EndDate", SqlDbType.DateTime, 8);
            Advertise_EndDate.Value = _advertiseInfo.Advertise_EndDate;
            SqlParameter Advertise_Embed = dbCmd.Parameters.Add("@Advertise_Embed", SqlDbType.NVarChar, 1000);
            Advertise_Embed.Value = _advertiseInfo.Advertise_Embed;
            SqlParameter RETURN_VALUE = dbCmd.Parameters.Add("@RETURN_VALUE", SqlDbType.NVarChar, 500);
            RETURN_VALUE.Direction = ParameterDirection.ReturnValue;
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

        public static void Update(AdvertiseInfo _advertiseInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Adv_Advertises_Update", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Advertise_Name = dbCmd.Parameters.Add("@Advertise_Name", SqlDbType.NVarChar, 500);
            Advertise_Name.Value = _advertiseInfo.Advertise_Name;
            SqlParameter Advertise_Path = dbCmd.Parameters.Add("@Advertise_Path", SqlDbType.NVarChar, 500);
            Advertise_Path.Value = _advertiseInfo.Advertise_Path;
            SqlParameter Advertise_Type = dbCmd.Parameters.Add("@Advertise_Type", SqlDbType.NVarChar, 500);
            Advertise_Type.Value = _advertiseInfo.Advertise_Type;
            SqlParameter Advertise_RedirectURL = dbCmd.Parameters.Add("@Advertise_RedirectURL", SqlDbType.NVarChar, 500);
            Advertise_RedirectURL.Value = _advertiseInfo.Advertise_RedirectURL;
            SqlParameter Advertise_Params = dbCmd.Parameters.Add("@Advertise_Params", SqlDbType.NVarChar, 500);
            Advertise_Params.Value = _advertiseInfo.Advertise_Params;
            SqlParameter Advertise_Lang = dbCmd.Parameters.Add("@Advertise_Lang", SqlDbType.NVarChar, 500);
            Advertise_Lang.Value = _advertiseInfo.Advertise_Lang;
            SqlParameter Advertise_Enable = dbCmd.Parameters.Add("@Advertise_Enable", SqlDbType.Bit, 1);
            Advertise_Enable.Value = _advertiseInfo.Advertise_Enable;
            SqlParameter Advertise_PositionID = dbCmd.Parameters.Add("@Advertise_PositionID", SqlDbType.Int, 4);
            Advertise_PositionID.Value = _advertiseInfo.Advertise_PositionID;
            SqlParameter Advertise_ID = dbCmd.Parameters.Add("@Advertise_ID", SqlDbType.Int, 4);
            Advertise_ID.Value = _advertiseInfo.Advertise_ID;
            SqlParameter Advertise_Width = dbCmd.Parameters.Add("@Advertise_Width", SqlDbType.Int, 4);
            Advertise_Width.Value = _advertiseInfo.Advertise_Width;
            SqlParameter Advertise_Height = dbCmd.Parameters.Add("@Advertise_Height", SqlDbType.Int, 4);
            Advertise_Height.Value = _advertiseInfo.Advertise_Height;
            SqlParameter Advertise_Priority = dbCmd.Parameters.Add("@Advertise_Priority", SqlDbType.Int, 4);
            Advertise_Priority.Value = _advertiseInfo.Advertise_Priority;
            SqlParameter Advertise_Click = dbCmd.Parameters.Add("@Advertise_Click", SqlDbType.Int, 4);
            Advertise_Click.Value = _advertiseInfo.Advertise_Click;
            SqlParameter Advertise_StartDate = dbCmd.Parameters.Add("@Advertise_StartDate", SqlDbType.DateTime, 8);
            Advertise_StartDate.Value = _advertiseInfo.Advertise_StartDate;
            SqlParameter Advertise_EndDate = dbCmd.Parameters.Add("@Advertise_EndDate", SqlDbType.DateTime, 8);
            Advertise_EndDate.Value = _advertiseInfo.Advertise_EndDate;
            SqlParameter Advertise_Embed = dbCmd.Parameters.Add("@Advertise_Embed", SqlDbType.NVarChar, 1000);
            Advertise_Embed.Value = _advertiseInfo.Advertise_Embed;

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

        public static AdvertiseInfo GetInfo(int _advertise_ID)
        {
            AdvertiseInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Adv_Advertises_GetInfo", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            SqlParameter Advertise_ID = dbCmd.Parameters.Add("@Advertise_ID", SqlDbType.Int, 4);
            Advertise_ID.Value = _advertise_ID;

            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new AdvertiseInfo();
                    retVal.Advertise_ID = Convert.ToInt32(dr["Advertise_ID"]);
                    retVal.Advertise_Name = Convert.ToString(dr["Advertise_Name"]);
                    retVal.Advertise_Path = Convert.ToString(dr["Advertise_Path"]);
                    retVal.Advertise_Width = Convert.ToInt32(dr["Advertise_Width"]);
                    retVal.Advertise_Height = Convert.ToInt32(dr["Advertise_Height"]);
                    retVal.Advertise_StartDate = Convert.ToDateTime(dr["Advertise_StartDate"]);
                    retVal.Advertise_EndDate = Convert.ToDateTime(dr["Advertise_EndDate"]);
                    retVal.Advertise_Type = Convert.ToString(dr["Advertise_Type"]);
                    retVal.Advertise_Priority = Convert.ToInt32(dr["Advertise_Priority"]);
                    retVal.Advertise_Click = Convert.ToInt32(dr["Advertise_Click"]);
                    retVal.Advertise_PositionID = Convert.ToInt32(dr["Advertise_PositionID"]);
                    retVal.Advertise_RedirectURL = Convert.ToString(dr["Advertise_RedirectURL"]);
                    retVal.Advertise_Enable = Convert.ToBoolean(dr["Advertise_Enable"]);
                    retVal.Advertise_Params = Convert.ToString(dr["Advertise_Params"]);
                    retVal.Advertise_Lang = Convert.ToString(dr["Advertise_Lang"]);
                    retVal.Advertise_Embed = Convert.ToString(dr["Advertise_Embed"]);
                }
                dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        public static string GetPos_NameByID(int posID)
        {

            string posName = "";

            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("Adv_Advertises_GetPos_NameByID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Pos_ID", posID);

            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
                posName = retVal.Rows[0]["Pos_Name"].ToString();

            }
            finally
            {
                dbConn.Close();
            }
            return posName;
        }


        public static void LoadPos_Name(ListItemCollection lstZones)
        {

            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("Adv_Positions_GetAll", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;

            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);

                foreach (DataRow row in retVal.Rows)
                {
                    ListItem item = new ListItem();
                    item.Value = row["Pos_ID"].ToString();
                    item.Text = row["Pos_Name"].ToString();
                    lstZones.Add(item);
                }
            }
            finally
            {
                dbConn.Close();
            }
        }
    }
}