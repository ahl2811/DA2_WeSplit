using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA2_WeSplit.Database
{
    class MucChi
    {
        public int STT { get; set; }
        public String MaChuyenDi { get; set; }
        public String NDChi { get; set; }
        public int SoTien { get; set; }

        public MucChi(int sTT, string maChuyenDi, string nDChi, int soTien)
        {
            this.STT = sTT;
            this.MaChuyenDi = maChuyenDi;
            this.NDChi = nDChi;
            this.SoTien = soTien;
        }
        public MucChi() {; }

        
    }
}
