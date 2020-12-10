using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA2_WeSplit.Database
{
    interface HinhAnhChuyenDiDAO
    {
        List<HinhAnhChuyenDi> GetAllHinhAnhChuyenDi();
        void updateHinhAnhChuyenDi();
        void addHinhAnhChuyenDi(HinhAnhChuyenDi hinhAnhChuyenDi);
    }
}
