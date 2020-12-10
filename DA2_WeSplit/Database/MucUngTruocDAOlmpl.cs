using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Windows;

namespace DA2_WeSplit.Database
{
    class MucUngTruocDAOlmpl : MucUngTruocDAO
    {
        private List<MucUngTruoc> mucUngTruocList;

        public MucUngTruocDAOlmpl()
        {
            mucUngTruocList = new List<MucUngTruoc>();

            string strConn = $"Server=localhost; Database=QLChuyenDi; Trusted_Connection=True;";
            SqlConnection sqlConnection = new SqlConnection(strConn);
            SqlCommand sqlCommand = new SqlCommand();
            String query = "select * from MUCUNGTRUOC";

            try
            {
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;

                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    MucUngTruoc mucUngTruoc = new MucUngTruoc();

                    var currentFolder = AppDomain.CurrentDomain.BaseDirectory;
                    mucUngTruoc.STT = Int32.Parse(reader[0].ToString());
                    mucUngTruoc.MaChuyenDi = reader[1].ToString();
                    mucUngTruoc.MaNguoiUng = reader[2].ToString();
                    mucUngTruoc.SoTien = Int32.Parse(reader[3].ToString());

                    mucUngTruocList.Add(mucUngTruoc);
                }
                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw ex;
            }
        }

        public void addMucUngTruoc(MucUngTruoc mucUngTruoc)
        {

            using (SqlConnection connection = new SqlConnection("Server=localhost; Database=QLChuyenDi; Trusted_Connection=True;"))
            {
                String query = "INSERT INTO dbo.MUCUNGTRUOC (STT, MACHUYENDI, MANGUOIUNG, SOTIEN)" +
                " VALUES (@STT,@MaChuyenDi, @MaNguoiUng, @SoTien)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@STT", mucUngTruoc.STT);
                    command.Parameters.AddWithValue("@MaChuyenDi", mucUngTruoc.MaChuyenDi);
                    command.Parameters.AddWithValue("@MaNguoiUng", mucUngTruoc.MaNguoiUng);
                    command.Parameters.AddWithValue("@SoTien", mucUngTruoc.SoTien);


                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result < 0)
                    {
                        MessageBox.Show("fail");
                    }
                }
            }
        }

        internal void deleteMucUngTruoc()
        {
            throw new NotImplementedException();
        }

        public List<MucUngTruoc> GetAllMucUngTruoc()
        {
            return mucUngTruocList;
        }

        public void updateMucUngTruoc()
        {
            throw new NotImplementedException();
        }
    }
}
