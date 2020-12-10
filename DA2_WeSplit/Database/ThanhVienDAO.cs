using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA2_WeSplit.Database
{
    interface ThanhVienDAO
    {
        List<ThanhVien> GetAllThanhVien();
        void updateThanhVien();
        void deleteThanhVien(ThanhVien thanhVien);

        void deleteThanhVien(string tenThanhVien);
        void addThanhVien(ThanhVien thanhVien);
    }
}
