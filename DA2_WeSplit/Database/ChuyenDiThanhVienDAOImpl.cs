using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DA2_WeSplit.Database
{
    class ChuyenDiThanhVienDAOImpl
    {
        private List<CHUYENDI_THANHVIEN> chuyenDiThanhVienList;

        public ChuyenDiThanhVienDAOImpl()
        {
            chuyenDiThanhVienList = new List<CHUYENDI_THANHVIEN>();

            string strConn = $"Server=localhost; Database=QLChuyenDi; Trusted_Connection=True;";
            SqlConnection sqlConnection = new SqlConnection(strConn);
            SqlCommand sqlCommand = new SqlCommand();
            String query = "select * from CHUYENDI_THANHVIEN";

            try
            {
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;

                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    CHUYENDI_THANHVIEN cHUYENDI_THANHVIEN = new CHUYENDI_THANHVIEN();

                    var currentFolder = AppDomain.CurrentDomain.BaseDirectory;
                    cHUYENDI_THANHVIEN.MaChuyenDi = reader[0].ToString();
                    cHUYENDI_THANHVIEN.MaThanhVien = reader[1].ToString();
                    cHUYENDI_THANHVIEN.TienThu = (int)reader[2];

                    chuyenDiThanhVienList.Add(cHUYENDI_THANHVIEN);
                }
                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw ex;
            }
        }

        public void addChuyenDiThanhVien(CHUYENDI_THANHVIEN cHUYENDI_THANHVIEN)
        {

            using (SqlConnection connection = new SqlConnection("Server=localhost; Database=QLChuyenDi; Trusted_Connection=True;"))
            {
                String query = "INSERT INTO dbo.CHUYENDI_THANHVIEN (MACHUYENDI, MATHANHVIEN, TIENTHU)" +
                " VALUES (@MaChuyenDi,@MaThanhVien,@TienThu)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaChuyenDi", cHUYENDI_THANHVIEN.MaChuyenDi);
                    command.Parameters.AddWithValue("@MaThanhVien", cHUYENDI_THANHVIEN.MaThanhVien);
                    command.Parameters.AddWithValue("@TienThu", cHUYENDI_THANHVIEN.TienThu);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result < 0)
                    {
                        MessageBox.Show("fail");
                    }
                }
            }
        }

        public List<CHUYENDI_THANHVIEN> GetCHUYENDI_THANHVIENList()
        {
            return chuyenDiThanhVienList;
        }
    }
}
