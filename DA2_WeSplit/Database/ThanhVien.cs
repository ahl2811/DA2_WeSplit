using System;

namespace DA2_WeSplit.Database
{
    class ThanhVien
    {
        public String MaThanhVien { get; set; }
        public String TenThanhVien { get; set; }
        public String MaChuyenDi { get; set; }
        public int TienThu { get; set; }

        public ThanhVien(string maThanhVien, string tenThanhVien, string maChuyenDi, int tienThu)
        {
            this.MaThanhVien = maThanhVien;
            this.TenThanhVien = tenThanhVien;
            this.MaChuyenDi = maChuyenDi;
            this.TienThu = tienThu;
        }
        public ThanhVien() {; }
    }
}
