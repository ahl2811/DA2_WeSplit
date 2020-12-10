using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA2_WeSplit.Database
{
    interface MucChiDAO
    {
        List<MucChi> GetAllMucChi();
        void updateMucChi();
        void addMucChi(MucChi mucChi);
    }
}
