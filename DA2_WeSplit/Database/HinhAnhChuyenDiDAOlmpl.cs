using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Windows;

namespace DA2_WeSplit.Database
{
    class HinhAnhChuyenDiDAOlmpl : HinhAnhChuyenDiDAO
    {
        private List<HinhAnhChuyenDi> hinhAnhChuyenDiList;

        public HinhAnhChuyenDiDAOlmpl()
        {
            hinhAnhChuyenDiList = new List<HinhAnhChuyenDi>();

            string strConn = $"Server=localhost; Database=QLChuyenDi; Trusted_Connection=True;";
            SqlConnection sqlConnection = new SqlConnection(strConn);
            SqlCommand sqlCommand = new SqlCommand();
            String query = "select * from HINHANHCHUYENDI";

            try
            {
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;

                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    HinhAnhChuyenDi hinhAnhChuyenDi = new HinhAnhChuyenDi();

                    var currentFolder = AppDomain.CurrentDomain.BaseDirectory;
                    hinhAnhChuyenDi.MaChuyenDi = reader[0].ToString();
                    hinhAnhChuyenDi.HinhAnh = $"{currentFolder}Assets\\Images\\{reader[1].ToString()}";

                    hinhAnhChuyenDiList.Add(hinhAnhChuyenDi);
                }
                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw ex;
            }
        }

        public void addHinhAnhChuyenDi(HinhAnhChuyenDi hinhAnhChuyenDi)
        {

            using (SqlConnection connection = new SqlConnection("Server=localhost; Database=QLChuyenDi; Trusted_Connection=True;"))
            {
                String query = "INSERT INTO dbo.HINHANHCHUYENDI (MACHUYENDI, HINHANH)" +
                " VALUES (@MaChuyenDi,@HinhAnh)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaChuyenDi", hinhAnhChuyenDi.MaChuyenDi);
                    command.Parameters.AddWithValue("@HinhAnh", hinhAnhChuyenDi.HinhAnh);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result < 0)
                    {
                        MessageBox.Show("fail");
                    }
                }
            }
        }

        internal void deleteHinhAnhChuyenDi()
        {
            throw new NotImplementedException();
        }

        public List<HinhAnhChuyenDi> GetAllHinhAnhChuyenDi()
        {
            return hinhAnhChuyenDiList;
        }

        public HinhAnhChuyenDi getTripImageByTripCode(String tripCode)
        {
            HinhAnhChuyenDi hinhAnhChuyenDi = null;

            foreach(HinhAnhChuyenDi tmp in hinhAnhChuyenDiList)
            {
                if(tmp.MaChuyenDi == tripCode)
                {
                    hinhAnhChuyenDi = new HinhAnhChuyenDi(tmp.MaChuyenDi, tmp.HinhAnh);
                    break;
                }
            }

            return hinhAnhChuyenDi;
        }

        public List<HinhAnhChuyenDi>GetImageListByTripId(string id)
        {
            List<HinhAnhChuyenDi> rs = new List<HinhAnhChuyenDi>();
            foreach(HinhAnhChuyenDi ha in hinhAnhChuyenDiList)
            {
                if(ha.MaChuyenDi == id)
                {
                    rs.Add(ha);
                }
            }
            return rs;
        }

        public void updateHinhAnhChuyenDi()
        {
            throw new NotImplementedException();
        }
    }
}

