using System;

namespace DA2_WeSplit.Database
{
    class CacMocLoTrinh
    {
        public String MaChuyenDi { get; set; }
        public String MocLoTrinh { get; set; }

        public CacMocLoTrinh(string maChuyenDi, string mocLoTrinh)
        {
            this.MaChuyenDi = maChuyenDi;
            this.MocLoTrinh = mocLoTrinh;
        }

        public CacMocLoTrinh() {; }

    }
}
