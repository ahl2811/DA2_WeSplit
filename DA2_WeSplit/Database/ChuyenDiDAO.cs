using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA2_WeSplit.Database
{
    interface ChuyenDiDAO
    {
        List<ChuyenDi> GetAllChuyenDi();
        void updateChuyenDi();
        void deleteChuyenDi(ChuyenDi chuyenDi);

        void deleteChuyenDi(string tenChuyenDi);
        void addChuyenDi(ChuyenDi chuyenDi);

        List<ChuyenDi> GetCurrentTrip();
        List<ChuyenDi> GetPassedTrip();
    }
}
