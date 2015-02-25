using System;
using System.Data;
using System.Data.SqlClient;
using iDKCMS.Library.Data;

namespace iDKCMS.Library.DataAccess
{
    public class OrderProductDB
    {
        public static int GetProductBought(int contentId)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Main_OrderProduct_GetProductBought", dbConn);
            dbCmd.Parameters.AddWithValue("@ContentID", contentId);
            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    if(dr.IsDBNull(0))
                    {
                        return 0;
                    }
                    else
                    {
                        return dr.GetInt32(0);
                    }
                }
                else
                {
                    return 0;
                }
            }
            finally
            {
                dbConn.Close();
            }
        }
        public static DataTable GetAll()
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Main_OrderProduct_GetAll", dbConn);
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
        public static void Delete(int _order_ID, int _content_ID)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Main_OrderProduct_Delete", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Order_ID", _order_ID);
            dbCmd.Parameters.AddWithValue("@Content_ID", _content_ID);
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
        public static int Insert(OrderProductInfo _orderDetailInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Main_OrderProduct_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Order_ID", _orderDetailInfo.Order_ID);
            dbCmd.Parameters.AddWithValue("@Content_ID", _orderDetailInfo.Content_ID);
            dbCmd.Parameters.AddWithValue("@Quantity", _orderDetailInfo.Quantity);
            dbCmd.Parameters.AddWithValue("@Price", _orderDetailInfo.Price);
            dbCmd.Parameters.AddWithValue("@PriceSum", _orderDetailInfo.PriceSum);
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

        public static void Update(OrderProductInfo _orderDetailInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Main_OrderProduct_Update", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Order_ID", _orderDetailInfo.Order_ID);
            dbCmd.Parameters.AddWithValue("@Content_ID", _orderDetailInfo.Content_ID);
            dbCmd.Parameters.AddWithValue("@Quantity", _orderDetailInfo.Quantity);
            dbCmd.Parameters.AddWithValue("@Price", _orderDetailInfo.Price);
            dbCmd.Parameters.AddWithValue("@PriceSum", _orderDetailInfo.PriceSum);
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

        public static OrderProductInfo GetInfo(int _order_ID, int _content_ID)
        {
            OrderProductInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Main_OrderProduct_GetInfo", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Order_ID", _order_ID);
            dbCmd.Parameters.AddWithValue("@Content_ID", _content_ID);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new OrderProductInfo();
                    retVal.Order_ID = Convert.ToInt32(dr["Order_ID"]);
                    retVal.Content_ID = Convert.ToInt32(dr["Content_ID"]);
                    retVal.Quantity = Convert.ToInt32(dr["Quantity"]);
                    retVal.Price = Convert.ToDouble(dr["Price"]);
                    retVal.PriceSum = Convert.ToDouble(dr["PriceSum"]);
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