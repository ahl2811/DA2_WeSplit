using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA2_WeSplit.Database
{
    class MucTraLai
    {
        public int STT { get; set; }
        public String MaChuyenDi { get; set; }

        public int STTUngTruoc { get; set; }
        public String MaNguoiTra { get; set; }
        public int SoTien { get; set; }
        public MucTraLai(int sTT, string maChuyenDi,int sTTUngTruoc, string maNguoiTra, int soTien)
        {
            this.STT = sTT;
            this.MaChuyenDi = maChuyenDi;
            this.STTUngTruoc = sTTUngTruoc;
            this.MaNguoiTra = maNguoiTra;
            this.SoTien = soTien;
        }

        public MucTraLai() {; }
    }
}
