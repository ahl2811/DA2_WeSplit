using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA2_WeSplit.Database
{
    class MucUngTruoc
    {
        public int STT { get; set; }
        public String MaChuyenDi { get; set; }
        public String MaNguoiUng { get; set; }
        public int SoTien { get; set; }
        
        public MucUngTruoc(int sTT, string maChuyenDi, string maNguoiUng, int soTien)
        {
            this.STT = sTT;
            this.MaChuyenDi = maChuyenDi;
            this.MaNguoiUng = maNguoiUng;
            this.SoTien = soTien;
        }

        public MucUngTruoc() {; }
    }
}
