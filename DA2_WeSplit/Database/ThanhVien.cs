using System;

namespace DA2_WeSplit.Database
{
    class ThanhVien
    {
        public String MaThanhVien { get; set; }
        public String TenThanhVien { get; set; }

        public ThanhVien(string maThanhVien, string tenThanhVien)
        {
            this.MaThanhVien = maThanhVien;
            this.TenThanhVien = tenThanhVien;
        }
        public ThanhVien() {; }
    }
}
