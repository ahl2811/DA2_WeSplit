using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Windows;

namespace DA2_WeSplit.Database
{
    class CacMocLoTrinhDAOlmpl : CacMocLoTrinhDAO
    {
        private List<CacMocLoTrinh> cacMocLoTrinhList;

        public CacMocLoTrinhDAOlmpl()
        {
            cacMocLoTrinhList = new List<CacMocLoTrinh>();

            string strConn = $"Server=localhost; Database=QLChuyenDi; Trusted_Connection=True;";
            SqlConnection sqlConnection = new SqlConnection(strConn);
            SqlCommand sqlCommand = new SqlCommand();
            String query = "select * from CACMOCLOTRINH";

            try
            {
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;

                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    CacMocLoTrinh cacMocLoTrinh = new CacMocLoTrinh();

                    var currentFolder = AppDomain.CurrentDomain.BaseDirectory;
                    cacMocLoTrinh.MaChuyenDi = reader[0].ToString();
                    cacMocLoTrinh.MocLoTrinh = reader[1].ToString();

                    cacMocLoTrinhList.Add(cacMocLoTrinh);
                }
                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw ex;
            }
        }

        public void addCacMocLoTrinh(CacMocLoTrinh cacMocLoTrinh)
        {

            using (SqlConnection connection = new SqlConnection("Server=localhost; Database=QLChuyenDi; Trusted_Connection=True;"))
            {
                String query = "INSERT INTO dbo.CACMOCLOTRINH (MACHUYENDI, MOCLOTRINH)" +
                " VALUES (@MaChuyenDi,@MocLoTrinh)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaChuyenDi", cacMocLoTrinh.MaChuyenDi);
                    command.Parameters.AddWithValue("@MocLoTrinh", cacMocLoTrinh.MocLoTrinh);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result < 0)
                    {
                        MessageBox.Show("fail");
                    }
                }
            }
        }

        internal void deleteCacMocLoTrinh()
        {
            throw new NotImplementedException();
        }

        public List<CacMocLoTrinh> GetAllCacMocLoTrinh()
        {
            return cacMocLoTrinhList;
        }

        public void updateCacMocLoTrinh()
        {
            throw new NotImplementedException();
        }
    }
}
