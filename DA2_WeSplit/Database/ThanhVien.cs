using System;

namespace DA2_WeSplit.Database
{
    class ThanhVien
    {
        public String MaThanhVien { get; set; }
        public String TenThanhVien { get; set; }

        public ThanhVien(string maThanhVien, string tenThanhVien, int tienThu)
        {
            ThanhVienDAOlmpl thanhVienDAOlmpl = new ThanhVienDAOlmpl();
            Random random = new Random();

            while (true)
            {
                int tmpCode = -1;
                tmpCode = random.Next();
                foreach (ThanhVien thanhVien in thanhVienDAOlmpl.GetAllThanhVien())
                {
                    if (thanhVien.MaThanhVien.Equals(tmpCode.ToString()))
                    {
                        continue;
                    }
                }
                this.MaThanhVien = tmpCode.ToString();
            }
            this.TenThanhVien = tenThanhVien;
        }
        public ThanhVien() {; }
    }
}
