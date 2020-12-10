using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Windows;

namespace DA2_WeSplit.Database
{
    class MucTraLaiDAOlmpl : MucTraLaiDAO
    {
        private List<MucTraLai> mucTraLaiList;

        public MucTraLaiDAOlmpl()
        {
            mucTraLaiList = new List<MucTraLai>();

            string strConn = $"Server=localhost; Database=QLChuyenDi; Trusted_Connection=True;";
            SqlConnection sqlConnection = new SqlConnection(strConn);
            SqlCommand sqlCommand = new SqlCommand();
            String query = "select * from MUCTRALAI";

            try
            {
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;

                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    MucTraLai mucTraLai = new MucTraLai();

                    var currentFolder = AppDomain.CurrentDomain.BaseDirectory;
                    mucTraLai.STT = Int32.Parse(reader[0].ToString());
                    mucTraLai.MaChuyenDi = reader[1].ToString();
                    mucTraLai.STTUngTruoc = Int32.Parse(reader[2].ToString());
                    mucTraLai.MaNguoiTra = reader[3].ToString();
                    mucTraLai.SoTien = Int32.Parse(reader[4].ToString());

                    mucTraLaiList.Add(mucTraLai);
                }
                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw ex;
            }
        }

        public void addMucTraLai(MucTraLai mucTraLai)
        {

            using (SqlConnection connection = new SqlConnection("Server=localhost; Database=QLChuyenDi; Trusted_Connection=True;"))
            {
                String query = "INSERT INTO dbo.MUCTRALAI (STT, MACHUYENDI, STTUNGTRUOC, MANGUOITRA, SOTIEN)" +
                " VALUES (@STT,@MaChuyenDi, @STTUngTruoc, @MaNguoiTra, @SoTien)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@STT", mucTraLai.STT);
                    command.Parameters.AddWithValue("@MaChuyenDi", mucTraLai.MaChuyenDi);
                    command.Parameters.AddWithValue("@STTUngTruoc", mucTraLai.STTUngTruoc);
                    command.Parameters.AddWithValue("@MaNguoiTra", mucTraLai.MaNguoiTra);
                    command.Parameters.AddWithValue("@SoTien", mucTraLai.SoTien);


                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result < 0)
                    {
                        MessageBox.Show("fail");
                    }
                }
            }
        }

        internal void deleteMucTraLai()
        {
            throw new NotImplementedException();
        }

        public List<MucTraLai> GetAllMucTraLai()
        {
            return mucTraLaiList;
        }

        public void updateMucTraLai()
        {
            throw new NotImplementedException();
        }
    }
}
