using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA2_WeSplit.Database
{
    class ChuyenDi
    {
		public String MaChuyenDi { get; set; }
		public String TenChuyenDi { get; set; }
		public String TrangThai { get; set; }
		public String DiaDiem { get; set; }
		public int KhoangChi { get; set; }
		public String MoTa { get; set; }

		public ChuyenDi (string maChuyenDi, string tenChuyenDi, string trangThai, string diaDiem, int khoangChi, string moTa)
        {
			this.MaChuyenDi = maChuyenDi;
			this.TenChuyenDi = tenChuyenDi;
			this.TrangThai = trangThai;
			this.DiaDiem = diaDiem;
			this.KhoangChi = khoangChi;
			this.MoTa = moTa;
        }

		public ChuyenDi() {; }
	}
}
