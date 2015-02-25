using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace iDKCMS.Library
{
    public class OrderDB
    {
        public static DataTable GetProductByOrderID(int _orderid)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Main_Order_GetProductByOrderID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@OrderID", _orderid);
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
            DataTable retVal;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Main_Order_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };
            try
            {
                retVal = new DataTable();
                var da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static List<OrderInfo> GetEntitys()
        {
            var items = new List<OrderInfo>();
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Main_Order_GetAll", dbConn) { CommandType = CommandType.StoredProcedure };

            try
            {
                dbConn.Open();
                IDataReader reader = dbCmd.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        var item = CreateEntityFromReader(reader);
                        items.Add(item);
                    }
                    reader.Close();
                }
            }
            finally
            {
                dbConn.Close();
            }
            return items;
        }


        public static void Delete(int order_ID)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Main_Order_Delete", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Order_ID", order_ID);
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
        public static int Insert(OrderInfo orderInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Main_Order_Insert", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Member_ID", orderInfo.Member_ID);
            dbCmd.Parameters.AddWithValue("@Order_Fullname", orderInfo.Order_Fullname);
            dbCmd.Parameters.AddWithValue("@Order_Email", orderInfo.Order_Email);
            dbCmd.Parameters.AddWithValue("@Order_Tel", orderInfo.Order_Tel);
            dbCmd.Parameters.AddWithValue("@Order_Address", orderInfo.Order_Address);
            dbCmd.Parameters.AddWithValue("@Order_District", orderInfo.Order_District);
            dbCmd.Parameters.AddWithValue("@Order_City", orderInfo.Order_City);
            dbCmd.Parameters.AddWithValue("@Order_Note", orderInfo.Order_Note);
            dbCmd.Parameters.AddWithValue("@Order_CreateDate", orderInfo.Order_CreateDate);
            dbCmd.Parameters.AddWithValue("@Order_Status", orderInfo.Order_Status);
            dbCmd.Parameters.AddWithValue("@Order_Price", orderInfo.Order_Price);
            dbCmd.Parameters.AddWithValue("@Order_Quantity", orderInfo.Order_Quantity);
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

        public static void Update(OrderInfo orderInfo)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Main_Order_Update", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Order_ID", orderInfo.Order_ID);
            dbCmd.Parameters.AddWithValue("@Member_ID", orderInfo.Member_ID);
            dbCmd.Parameters.AddWithValue("@Order_Fullname", orderInfo.Order_Fullname);
            dbCmd.Parameters.AddWithValue("@Order_Email", orderInfo.Order_Email);
            dbCmd.Parameters.AddWithValue("@Order_Tel", orderInfo.Order_Tel);
            dbCmd.Parameters.AddWithValue("@Order_Address", orderInfo.Order_Address);
            dbCmd.Parameters.AddWithValue("@Order_District", orderInfo.Order_District);
            dbCmd.Parameters.AddWithValue("@Order_City", orderInfo.Order_City);
            dbCmd.Parameters.AddWithValue("@Order_Note", orderInfo.Order_Note);
            dbCmd.Parameters.AddWithValue("@Order_CreateDate", orderInfo.Order_CreateDate);
            dbCmd.Parameters.AddWithValue("@Order_Status", orderInfo.Order_Status);
            dbCmd.Parameters.AddWithValue("@Order_Price", orderInfo.Order_Price);
            dbCmd.Parameters.AddWithValue("@Order_Quantity", orderInfo.Order_Quantity);
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

        public static OrderInfo GetInfo(int order_ID)
        {
            OrderInfo retVal = null;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Main_Order_GetInfo", dbConn) { CommandType = CommandType.StoredProcedure };
            dbCmd.Parameters.AddWithValue("@Order_ID", order_ID);
            try
            {
                dbConn.Open();
                var dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new OrderInfo();
                    retVal.Order_ID = ConvertUtility.ToInt32(dr["Order_ID"]);
                    retVal.Member_ID = ConvertUtility.ToInt32(dr["Member_ID"]);
                    retVal.Order_Fullname = ConvertUtility.ToString(dr["Order_Fullname"]);
                    retVal.Order_Email = ConvertUtility.ToString(dr["Order_Email"]);
                    retVal.Order_Tel = ConvertUtility.ToString(dr["Order_Tel"]);
                    retVal.Order_Address = ConvertUtility.ToString(dr["Order_Address"]);
                    retVal.Order_District = ConvertUtility.ToString(dr["Order_District"]);
                    retVal.Order_City = ConvertUtility.ToString(dr["Order_City"]);
                    retVal.Order_Note = ConvertUtility.ToString(dr["Order_Note"]);
                    retVal.Order_CreateDate = ConvertUtility.ToDateTime(dr["Order_CreateDate"]);
                    retVal.Order_Status = ConvertUtility.ToInt32(dr["Order_Status"]);
                    retVal.Order_Price = ConvertUtility.ToDouble(dr["Order_Price"]);
                    retVal.Order_Quantity = ConvertUtility.ToInt32(dr["Order_Quantity"]);
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        private static OrderInfo CreateEntityFromReader(IDataReader reader)
        {
            var item = new OrderInfo();
            try { if (!reader.IsDBNull(reader.GetOrdinal("Order_ID"))) item.Order_ID = ConvertUtility.ToInt32(reader["Order_ID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("User_ID"))) item.Member_ID = ConvertUtility.ToInt32(reader["Member_ID"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Order_Fullname"))) item.Order_Fullname = ConvertUtility.ToString(reader["Order_Fullname"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Order_Email"))) item.Order_Email = ConvertUtility.ToString(reader["Order_Email"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Order_Tel"))) item.Order_Tel = ConvertUtility.ToString(reader["Order_Tel"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Order_Address"))) item.Order_Address = ConvertUtility.ToString(reader["Order_Address"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Order_District"))) item.Order_District = ConvertUtility.ToString(reader["Order_District"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Order_City"))) item.Order_City = ConvertUtility.ToString(reader["Order_City"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Order_Note"))) item.Order_Note = ConvertUtility.ToString(reader["Order_Note"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Order_CreateDate"))) item.Order_CreateDate = ConvertUtility.ToDateTime(reader["Order_CreateDate"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Order_Status"))) item.Order_Status = ConvertUtility.ToInt32(reader["Order_Status"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Order_Price"))) item.Order_Price = ConvertUtility.ToDouble(reader["Order_Price"]); }
            catch { }
            try { if (!reader.IsDBNull(reader.GetOrdinal("Order_Quantity"))) item.Order_Quantity = ConvertUtility.ToInt32(reader["Order_Quantity"]); }
            catch { }
            return item;
        }


    }
}
