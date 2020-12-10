using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA2_WeSplit.Database
{
    interface CacMocLoTrinhDAO
    {
        List<CacMocLoTrinh> GetAllCacMocLoTrinh();
        void updateCacMocLoTrinh();
        void addCacMocLoTrinh(CacMocLoTrinh cacMocLoTrinh);
    }
}
