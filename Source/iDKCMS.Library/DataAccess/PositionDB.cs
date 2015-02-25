using System;
using System.Data;
using System.Data.SqlClient;
using iDKCMS.Library.Data;

namespace iDKCMS.Library.DataAccess
{
    public class PositionDB
    {
        public static DataTable GetAll()
        {
            DataTable retVal;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand("Adv_Positions_GetAll", dbConn);
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
        public static int GetIDByPosition(string _position)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Adv_Positions_GetIDByPosition", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Position = dbCmd.Parameters.Add("@Position", SqlDbType.NVarChar, 50);
            Position.Value = _position;

            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read()) return dr.GetInt32(0);
                else return 0;
            }
            finally
            {
                dbConn.Close();
            }
        }
        public static PositionInfo GetInfoByPosition(string _position)
        {
            return GetInfo(GetIDByPosition(_position));
        }

        public static void Delete(int _Pos_ID)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Adv_Positions_Delete", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Pos_ID = dbCmd.Parameters.Add("@Pos_ID", SqlDbType.Int, 4);
            Pos_ID.Value = _Pos_ID;


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

        public static int Insert(PositionInfo _posInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Adv_Positions_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Pos_Name = dbCmd.Parameters.Add("@Pos_Name", SqlDbType.NVarChar, 500);
            Pos_Name.Value = _posInfo.Pos_Name;
            SqlParameter Pos_Position = dbCmd.Parameters.Add("@Pos_Position", SqlDbType.NVarChar, 500);
            Pos_Position.Value = _posInfo.Pos_Position;
            SqlParameter Pos_Type = dbCmd.Parameters.Add("@Pos_Type", SqlDbType.NVarChar, 500);
            Pos_Type.Value = _posInfo.Pos_Type;
            SqlParameter Pos_SeparateCode = dbCmd.Parameters.Add("@Pos_SeparateCode", SqlDbType.NVarChar, 500);
            Pos_SeparateCode.Value = _posInfo.Pos_SeparateCode;
            SqlParameter Pos_Width = dbCmd.Parameters.Add("@Pos_Width", SqlDbType.Int, 4);
            Pos_Width.Value = _posInfo.Pos_Width;
            SqlParameter Pos_Height = dbCmd.Parameters.Add("@Pos_Height", SqlDbType.Int, 4);
            Pos_Height.Value = _posInfo.Pos_Height;
            //SqlParameter Pos_ID = dbCmd.Parameters.Add("@Pos_ID", SqlDbType.Int, 4);
            //Pos_ID.Value = _posInfo.Pos_ID ;
            SqlParameter RETURN_VALUE = dbCmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int, 4);
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

        public static void Update(PositionInfo _posInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Adv_Positions_Update", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            SqlParameter Pos_Name = dbCmd.Parameters.Add("@Pos_Name", SqlDbType.NVarChar, 500);
            Pos_Name.Value = _posInfo.Pos_Name;
            SqlParameter Pos_Position = dbCmd.Parameters.Add("@Pos_Position", SqlDbType.NVarChar, 500);
            Pos_Position.Value = _posInfo.Pos_Position;
            SqlParameter Pos_Type = dbCmd.Parameters.Add("@Pos_Type", SqlDbType.NVarChar, 500);
            Pos_Type.Value = _posInfo.Pos_Type;
            SqlParameter Pos_SeparateCode = dbCmd.Parameters.Add("@Pos_SeparateCode", SqlDbType.NVarChar, 500);
            Pos_SeparateCode.Value = _posInfo.Pos_SeparateCode;
            SqlParameter Pos_Width = dbCmd.Parameters.Add("@Pos_Width", SqlDbType.Int, 4);
            Pos_Width.Value = _posInfo.Pos_Width;
            SqlParameter Pos_Height = dbCmd.Parameters.Add("@Pos_Height", SqlDbType.Int, 4);
            Pos_Height.Value = _posInfo.Pos_Height;
            SqlParameter Pos_ID = dbCmd.Parameters.Add("@Pos_ID", SqlDbType.Int, 4);
            Pos_ID.Value = _posInfo.Pos_ID;
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

        public static PositionInfo GetInfo(int _Pos_ID)
        {
            PositionInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Adv_Positions_GetInfo", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            SqlParameter Pos_ID = dbCmd.Parameters.Add("@Pos_ID", SqlDbType.Int, 4);
            Pos_ID.Value = _Pos_ID;
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new PositionInfo();
                    retVal.Pos_ID = Convert.ToInt32(dr["Pos_ID"]);
                    retVal.Pos_Name = Convert.ToString(dr["Pos_Name"]);
                    retVal.Pos_Position = Convert.ToString(dr["Pos_Position"]);
                    retVal.Pos_Type = Convert.ToString(dr["Pos_Type"]);
                    retVal.Pos_Width = Convert.ToInt32(dr["Pos_Width"]);
                    retVal.Pos_Height = Convert.ToInt32(dr["Pos_Height"]);
                    retVal.Pos_SeparateCode = Convert.ToString(dr["Pos_SeparateCode"]);
                }
                dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
    }
}