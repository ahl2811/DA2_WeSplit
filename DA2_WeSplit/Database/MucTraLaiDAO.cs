using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA2_WeSplit.Database
{
    interface MucTraLaiDAO
    {
        List<MucTraLai> GetAllMucTraLai();
        void updateMucTraLai();
        void addMucTraLai(MucTraLai mucTraLai);
    }
}
