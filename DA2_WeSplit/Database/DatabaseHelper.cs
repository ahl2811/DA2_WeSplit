using System;
using System.Data;
using System.Data.SqlClient;

namespace DA2_WeSplit.Database
{
    class DatabaseHelper
    {
        public static String Database;

        public static int executeQuery(string query)
        {
            int rowCount = 0;
            string strConn = $"Server=localhost; Database={Database}; Trusted_Connection=True;";
            SqlConnection sqlConnection = new SqlConnection(strConn);
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandTimeout = 12 * 3600;

                sqlConnection.Open();
                rowCount = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw ex;
            }

            return rowCount;
        }
        public static SqlDataReader executeReader(String query)
        {
            SqlDataReader result;

            string strConn = $"Server=localhost; Database=QLChuyenDi; Trusted_Connection=True;";
            SqlConnection sqlConnection = new SqlConnection(strConn);
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.CommandText = query;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;

            try
            {
                sqlConnection.Open();
                result = sqlCommand.ExecuteReader();
                sqlConnection.Close();
                return result;
            }
            catch (Exception)
            {
                sqlConnection.Close();
            }
            return null;
        }
    }
}
