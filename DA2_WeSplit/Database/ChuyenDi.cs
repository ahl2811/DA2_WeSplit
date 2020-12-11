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
		public String MoTa { get; set; }

		public ChuyenDi (string tenChuyenDi, string trangThai, string diaDiem, string moTa)
        {
			ChuyenDiDAOImpl chuyenDiDAOImpl = new ChuyenDiDAOImpl();
			
			Random random = new Random();

            while(true)
            {
				int tmpCode = -1;
				tmpCode = random.Next();
				foreach(ChuyenDi chuyenDi in chuyenDiDAOImpl.GetAllChuyenDi())
                {
					if(chuyenDi.MaChuyenDi.Equals(tmpCode.ToString()))
                    {
						continue;
                    }
                }
				this.MaChuyenDi = tmpCode.ToString();
            }

			this.TenChuyenDi = tenChuyenDi;
			this.TrangThai = trangThai;
			this.DiaDiem = diaDiem;
			this.MoTa = moTa;
        }

		public ChuyenDi() {; }
	}
}
