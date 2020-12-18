using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Windows;

namespace DA2_WeSplit.Database
{
    class ChuyenDiDAOImpl : ChuyenDiDAO
    {
        private List<ChuyenDi> chuyenDiList;
        private List<ChuyenDi> currentTripList;
        private List<ChuyenDi> passedTripList;
        public ChuyenDiDAOImpl()
        {
            chuyenDiList = new List<ChuyenDi>();
            currentTripList = new List<ChuyenDi>();
            passedTripList = new List<ChuyenDi>();

            string strConn = $"Server=localhost; Database=QLChuyenDi; Trusted_Connection=True;";
            SqlConnection sqlConnection = new SqlConnection(strConn);
            SqlCommand sqlCommand = new SqlCommand();
            String query = "select * from CHUYENDI";

            try
            {
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;

                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    ChuyenDi chuyenDi = new ChuyenDi();
                    var currentFolder = AppDomain.CurrentDomain.BaseDirectory;
                    chuyenDi.MaChuyenDi = reader[0].ToString();
                    chuyenDi.TenChuyenDi= reader[1].ToString();
                    //chuyenDi.TrangThai = Int32.Parse(reader[2].ToString());
                    chuyenDi.DiaDiem = reader[3].ToString();
                    chuyenDi.MoTa = reader[4].ToString();
                    chuyenDi.AnhBia = $"{currentFolder}Assets\\Images\\{reader[5].ToString()}";
                    
                    int rs;
                    bool success = Int32.TryParse(reader[2].ToString(), out rs);

                    if (success)
                    {
                        chuyenDi.TrangThai = rs;
                    }
                    else
                    {
                        chuyenDi.TrangThai = 0;
                    }

                    chuyenDiList.Add(chuyenDi);

                    if (success && rs == 1)
                    {
                        passedTripList.Add(chuyenDi);
                    }
                    else if(success && rs ==0)
                    {
                        currentTripList.Add(chuyenDi);
                    }
                }
                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                    throw ex;
            }
        }

        public void addChuyenDi(ChuyenDi chuyenDi)
        {

            using (SqlConnection connection = new SqlConnection("Server=localhost; Database=QLChuyenDi; Trusted_Connection=True;"))
            {
                String query = "INSERT INTO dbo.CHUYENDI (MACHUYENDI,TENCHUYENDI,TRANGTHAI,DIADIEM,MOTA,ANHBIA)" +
                " VALUES (@MaChuyenDi,@TenChuyenDi,@TrangThai,@DiaDiem,@MoTa, @AnhBia)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaChuyenDi", chuyenDi.MaChuyenDi);
                    command.Parameters.AddWithValue("@TenChuyenDi", chuyenDi.TenChuyenDi);
                    command.Parameters.AddWithValue("@TrangThai", chuyenDi.TrangThai);
                    command.Parameters.AddWithValue("@DiaDiem", chuyenDi.DiaDiem);
                    command.Parameters.AddWithValue("@MoTa", chuyenDi.MoTa);
                    command.Parameters.AddWithValue("@AnhBia", chuyenDi.AnhBia);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result < 0)
                    {
                        MessageBox.Show("fail");
                    }
                }
            }
        }

        internal void deleteChuyenDi()
        {
            throw new NotImplementedException();
        }

        public void deleteChuyenDi(ChuyenDi chuyenDi)
        {
            String delQuery = $"DELETE FROM CHUYENDI WHERE MACHUYENDI = '{chuyenDi.MaChuyenDi}';";
            DatabaseHelper.executeQuery(delQuery);
        } 
        public void deleteChuyenDi(string tenChuyenDi)
        {
            String delQuery = $"DELETE FROM CHUYENDI WHERE TENCHUYENDI = '{tenChuyenDi}';";
            DatabaseHelper.executeQuery(delQuery);
        }

        public List<ChuyenDi> GetAllChuyenDi()
        {
            return chuyenDiList;
        }

        public List<ChuyenDi> GetCurrentTrip()
        {
            return currentTripList;
        }

        public List<ChuyenDi> GetPassedTrip()
        {
            return passedTripList;
        }
        public void updateChuyenDi()
        {
            throw new NotImplementedException();
        }

        public ChuyenDi getChuyenDiById(string Id)
        {
            ChuyenDi result = new ChuyenDi();
            foreach(var cd in chuyenDiList)
            {
                if(cd.MaChuyenDi == Id)
                {
                    result = new ChuyenDi(cd.MaChuyenDi, cd.TenChuyenDi, cd.TrangThai, cd.DiaDiem, cd.MoTa, cd.AnhBia);
                    break;
                }
            }
            return result;
        }

        public void updateTrangThai(string maChuyenDi, int trangThai)
        {

            using (SqlConnection connection = new SqlConnection("Server=localhost; Database=QLChuyenDi; Trusted_Connection=True;"))
            {
                String query = "UPDATE dbo.CHUYENDI SET TRANGTHAI = @TrangThai WHERE MACHUYENDI = @MaChuyenDi;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaChuyenDi", maChuyenDi);
                    command.Parameters.AddWithValue("@TrangThai", trangThai);
                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result < 0)
                    {
                        MessageBox.Show("fail");
                    }
                }
            }
        }
    }
}
