using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA2_WeSplit.Database
{
    class HinhAnhChuyenDi
    {
        public String MaChuyenDi { get; set; }
        public String HinhAnh { get; set; }

        
        public HinhAnhChuyenDi(string maChuyenDi, string hinhAnh)
        {
            var currentFolder = AppDomain.CurrentDomain.BaseDirectory;
            this.MaChuyenDi = maChuyenDi;
            this.HinhAnh = hinhAnh;
        }

        public HinhAnhChuyenDi() {; }
    }
}
