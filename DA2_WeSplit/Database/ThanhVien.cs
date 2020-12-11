using System;

namespace DA2_WeSplit.Database
{
    class ThanhVien
    {
        public String MaThanhVien { get; set; }
        public String TenThanhVien { get; set; }
        public int TienThu { get; set; }

        public ThanhVien(string maThanhVien, string tenThanhVien, int tienThu)
        {
            this.MaThanhVien = maThanhVien;
            this.TenThanhVien = tenThanhVien;
            this.TienThu = tienThu;
        }
        public ThanhVien() {; }
    }
}
