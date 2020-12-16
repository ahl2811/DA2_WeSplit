using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA2_WeSplit.Database
{
    class ChuyenDi
    {
		public String MaChuyenDi { get; set; }
		public String TenChuyenDi { get; set; }
		public int TrangThai { get; set; }
		public String DiaDiem { get; set; }
		public String MoTa { get; set; }
		public String AnhBia { get; set; }
		public ChuyenDi (string maChuyenDi, string tenChuyenDi, int trangThai, string diaDiem, string moTa, string anhBia)
        {
			Random random = new Random();

			this.MaChuyenDi = maChuyenDi;
			this.TenChuyenDi = tenChuyenDi;
			this.TrangThai = trangThai;
			this.DiaDiem = diaDiem;
			this.MoTa = moTa;
			this.AnhBia = anhBia;
        }

		public ChuyenDi() {; }
	}
}
