using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iDKCMS.Library
{
    public class DataHelper
    {
        // Su dung chu yeu voi table
        private static DataTable GetColumnTypes(string tableName)
        {
            string strSQL = "SELECT DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME ='" + tableName + "'";
            return DataHelper.GetDataFromTable(strSQL);
        }

        public static void UpdateField(string tableName, string fieldUpdate, object valueUpdate, SqlDbType updateType, string fieldID, object id)
        {
            string strSQL = "UPDATE " + tableName + " SET " + fieldUpdate + " = @" + fieldUpdate + " WHERE " + fieldID + " = " + id.ToString();
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand(strSQL, dbConn);
            dbCmd.CommandType = CommandType.Text;
            dbCmd.Parameters.Add("@" + fieldUpdate, updateType); dbCmd.Parameters["@" + fieldUpdate].Value = valueUpdate;
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

        public static object GetFieldByID(string tableName, string getFieldName, string idFieldName, object idFieldValue)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            string strSQL = "SELECT " + getFieldName + " FROM " + tableName + " WHERE " + idFieldName + " = " + idFieldValue.ToString();
            SqlCommand dbCmd = new SqlCommand(strSQL, dbConn);
            dbCmd.CommandType = CommandType.Text;
            object retval = null;
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read()) retval = dr.GetValue(0);
            }
            finally
            {
                dbConn.Close();
            }
            return retval;
        }
        // ****
        public static object GetData(string SQL)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            SqlCommand dbCmd = new SqlCommand(SQL, dbConn);
            dbCmd.CommandType = CommandType.Text;
            object retval = null;
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read()) retval = dr.GetValue(0);
            }
            finally
            {
                dbConn.Close();
            }
            return retval;


        }

        public static object GetFieldByIDParameter(string tableName, string getFieldName, string parastring)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            string strSQL = "SELECT " + getFieldName + " FROM " + tableName + " " + parastring;
            SqlCommand dbCmd = new SqlCommand(strSQL, dbConn);
            dbCmd.CommandType = CommandType.Text;
            object retval = null;
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read()) retval = dr.GetValue(0);
            }
            finally
            {
                dbConn.Close();
            }
            return retval;
        }

        public static DataRow GetRowByID(string tableName, string idFieldName, object idFieldValue)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            string strSQL = "SELECT * FROM " + tableName + " WHERE " + idFieldName + " = " + idFieldValue.ToString();
            SqlCommand dbCmd = new SqlCommand(strSQL, dbConn);
            dbCmd.CommandType = CommandType.Text;
            DataTable retval = null;
            try
            {
                retval = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retval);
            }
            finally
            {
                dbConn.Close();
            }
            if (retval.Rows.Count > 0) return retval.Rows[0];
            else return null;
        }

        public static DataRow GetRowByIDParameter(string tableName, string idFieldName, object idFieldValue, string parastring)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);

            string strSQL = "SELECT * FROM " + tableName + " WHERE " + idFieldName + " = " + idFieldValue.ToString() + " " + parastring;
            SqlCommand dbCmd = new SqlCommand(strSQL, dbConn);
            dbCmd.CommandType = CommandType.Text;
            DataTable retval = null;
            try
            {
                retval = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retval);
            }
            finally
            {
                dbConn.Close();
            }
            if (retval.Rows.Count > 0) return retval.Rows[0];
            else return null;
        }

        public static void DeleteFromTable(string tableName, string columnName, object value)
        {
            SqlConnection dbConn = AppEnv.GetConnection;
            SqlCommand dbCmd = new SqlCommand("DELETE " + tableName + " WHERE " + columnName + " = @columValue", dbConn);
            dbCmd.Parameters.Add("@columValue", value);
            dbCmd.CommandType = CommandType.Text;

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

        public static void DeleteFromTableParameter(string tableName, string columnName, object value, string parastring)
        {
            SqlConnection dbConn = AppEnv.GetConnection;
            SqlCommand dbCmd = new SqlCommand("DELETE " + tableName + " WHERE " + columnName + " = @columValue " + parastring, dbConn);
            dbCmd.Parameters.Add("@columValue", value);
            dbCmd.CommandType = CommandType.Text;

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

        public static void Insert(string tableName, object value1, object value2)
        {
            SqlConnection dbConn = AppEnv.GetConnection;
            SqlCommand dbCmd = new SqlCommand("INSERT INTO " + tableName + " VALUES(" + value1 + " , " + value2 + ")", dbConn);
            dbCmd.CommandType = CommandType.Text;

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

        public static void InsertToTable(string tableName, DataRow newData)
        {
            DataTable colTypes = GetColumnTypes(tableName);
            SqlConnection dbConn = AppEnv.GetConnection;
            string strSQL = "INSERT INTO " + tableName + " (";
            for (int i = 1; i < newData.Table.Columns.Count; i++) strSQL += newData.Table.Columns[i].ColumnName + ",";
            strSQL = strSQL.Substring(0, strSQL.Length - 1) + ")";
            strSQL += " VALUES(";
            for (int i = 1; i < newData.Table.Columns.Count; i++) strSQL += "@" + newData.Table.Columns[i].ColumnName + ",";
            strSQL = strSQL.Substring(0, strSQL.Length - 1) + ")";

            SqlCommand dbCmd = new SqlCommand(strSQL, dbConn);
            for (int i = 1; i < newData.Table.Columns.Count; i++)
            {
                string paramName = "@" + newData.Table.Columns[i].ColumnName;
                dbCmd.Parameters.Add(paramName, newData.ItemArray[i]);
                dbCmd.Parameters[paramName].SqlDbType = GetType(colTypes.Rows[i][0].ToString());
            }

            dbCmd.CommandType = CommandType.Text;
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

        private static SqlDbType GetType(string type)
        {
            SqlDbType retVal;
            switch (type.ToLower())
            {
                case "ntext":
                    retVal = SqlDbType.NText;
                    break;
                case "nvarchar":
                    retVal = SqlDbType.NVarChar;
                    break;
                case "text":
                    retVal = SqlDbType.Text;
                    break;
                case "varchar":
                    retVal = SqlDbType.VarChar;
                    break;
                case "image":
                    retVal = SqlDbType.Image;
                    break;
                case "money":
                    retVal = SqlDbType.Money;
                    break;
                case "bigint":
                    retVal = SqlDbType.BigInt;
                    break;
                case "int":
                    retVal = SqlDbType.Int;
                    break;
                case "datetime":
                    retVal = SqlDbType.DateTime;
                    break;
                case "float":
                    retVal = SqlDbType.Float;
                    break;
                case "bit":
                    retVal = SqlDbType.Bit;
                    break;
                case "smallint":
                    retVal = SqlDbType.SmallInt;
                    break;
                default:
                    retVal = SqlDbType.VarChar;
                    break;
            }
            return retVal;
        }

        public static void UpdateToTable(string tableName, DataRow newData)
        {
            DataTable colTypes = GetColumnTypes(tableName);
            SqlConnection dbConn = AppEnv.GetConnection;
            string strSQL = "UPDATE " + tableName + " SET ";
            for (int i = 1; i < newData.Table.Columns.Count; i++) strSQL += newData.Table.Columns[i].ColumnName + " = @" + newData.Table.Columns[i].ColumnName + ",";
            strSQL = strSQL.Substring(0, strSQL.Length - 1);

            strSQL += " WHERE " + newData.Table.Columns[0].ColumnName + " = " + newData.ItemArray[0];

            SqlCommand dbCmd = new SqlCommand(strSQL, dbConn);
            for (int i = 1; i < newData.Table.Columns.Count; i++)
            {
                string paramName = "@" + newData.Table.Columns[i].ColumnName;
                dbCmd.Parameters.Add(paramName, newData.ItemArray[i]);
                dbCmd.Parameters[paramName].SqlDbType = GetType(colTypes.Rows[i][0].ToString());

            }
            dbCmd.CommandType = CommandType.Text;

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

        public static void UpdateToTableParameter(string tableName, DataRow newData, string columnName, object value, string parastring)
        {
            DataTable colTypes = GetColumnTypes(tableName);
            SqlConnection dbConn = AppEnv.GetConnection;
            string strSQL = "UPDATE " + tableName + " SET ";
            for (int i = 1; i < newData.Table.Columns.Count; i++) strSQL += newData.Table.Columns[i].ColumnName + " = @" + newData.Table.Columns[i].ColumnName + ",";
            strSQL = strSQL.Substring(0, strSQL.Length - 1);

            strSQL += " WHERE " + columnName + " = @columValue " + parastring;

            SqlCommand dbCmd = new SqlCommand(strSQL, dbConn);
            dbCmd.Parameters.Add("@columValue", value);
            for (int i = 1; i < newData.Table.Columns.Count; i++)
            {
                string paramName = "@" + newData.Table.Columns[i].ColumnName;
                dbCmd.Parameters.Add(paramName, newData.ItemArray[i]);
                dbCmd.Parameters[paramName].SqlDbType = GetType(colTypes.Rows[i][0].ToString());

            }
            dbCmd.CommandType = CommandType.Text;

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

        public static DataTable GetDataFromTable(string tableName, string sortBy, string orderBy)
        {
            string SQL = "SELECT * FROM " + tableName;
            if (sortBy != string.Empty) SQL += " ORDER BY [" + sortBy + "] " + orderBy;

            SqlConnection dbConn = AppEnv.GetConnection;
            DataTable retVal = new DataTable();
            try
            {
                SqlDataAdapter myDA = new SqlDataAdapter(SQL, dbConn);
                myDA.Fill(retVal);
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static DataTable GetDataFromTable(string strSQL)
        {
            SqlConnection dbConn = AppEnv.GetConnection;
            DataTable retVal = new DataTable();
            try
            {
                SqlDataAdapter myDA = new SqlDataAdapter(strSQL, dbConn);
                myDA.Fill(retVal);
            }
            catch (Exception e)
            {
                string t;
                t = e.Message;
                t = "";
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static DataTable GetDataFromTable(string tableName, string where, string sortBy, string orderBy)
        {
            string SQL = "SELECT * FROM " + tableName + " " + where;
            if (sortBy != string.Empty) SQL += " ORDER BY [" + sortBy + "] " + orderBy;

            SqlConnection dbConn = AppEnv.GetConnection;
            DataTable retVal = new DataTable();
            try
            {
                SqlDataAdapter myDA = new SqlDataAdapter(SQL, dbConn);
                myDA.Fill(retVal);
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
    }
}