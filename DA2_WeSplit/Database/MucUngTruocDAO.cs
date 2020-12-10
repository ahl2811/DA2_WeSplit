using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA2_WeSplit.Database
{
    interface MucUngTruocDAO
    {
        List<MucUngTruoc> GetAllMucUngTruoc();
        void updateMucUngTruoc();
        void addMucUngTruoc(MucUngTruoc mucUngTruoc);
    }
}
