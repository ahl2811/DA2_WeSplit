using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Windows;

namespace DA2_WeSplit.Database
{
    class MucChiDAOlmpl : MucChiDAO
    {
        private List<MucChi> mucChiList;

        public MucChiDAOlmpl()
        {
            mucChiList = new List<MucChi>();

            string strConn = $"Server=localhost; Database=QLChuyenDi; Trusted_Connection=True;";
            SqlConnection sqlConnection = new SqlConnection(strConn);
            SqlCommand sqlCommand = new SqlCommand();
            String query = "select * from MUCCHI";

            try
            {
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;

                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    MucChi mucChi = new MucChi();

                    var currentFolder = AppDomain.CurrentDomain.BaseDirectory;
                    mucChi.STT = Int32.Parse(reader[0].ToString());
                    mucChi.MaChuyenDi = reader[1].ToString();
                    mucChi.NDChi = reader[2].ToString();
                    mucChi.SoTien = Int32.Parse(reader[3].ToString());

                    mucChiList.Add(mucChi);
                }
                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw ex;
            }
        }

        public void addMucChi(MucChi mucChi)
        {

            using (SqlConnection connection = new SqlConnection("Server=localhost; Database=QLChuyenDi; Trusted_Connection=True;"))
            {
                String query = "INSERT INTO dbo.MUCCHI (STT, MACHUYENDI, NDCHI, SOTIEN)" +
                " VALUES (@STT,@MaChuyenDi, @NDChi, @SoTien)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@STT", mucChi.STT);
                    command.Parameters.AddWithValue("@MaChuyenDi", mucChi.MaChuyenDi);
                    command.Parameters.AddWithValue("@NDChi", mucChi.NDChi);
                    command.Parameters.AddWithValue("@SoTien", mucChi.SoTien);


                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result < 0)
                    {
                        MessageBox.Show("fail");
                    }
                }
            }
        }

        internal void deleteMucChi()
        {
            throw new NotImplementedException();
        }

        public List<MucChi> GetAllMucChi()
        {
            return mucChiList;
        }

        public void updateMucChi()
        {
            throw new NotImplementedException();
        }
    }
}
