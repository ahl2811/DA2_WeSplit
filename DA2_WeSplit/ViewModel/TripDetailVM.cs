using DA2_WeSplit.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA2_WeSplit.ViewModel
{
    class TripDetailVM
    {
        public ChuyenDi chuyenDi { get; set; }
        public ObservableCollection<MucChi> mucChiList { get; set; }
        public ObservableCollection<HinhAnhChuyenDi> hinhAnhList { get; set; }
        public ObservableCollection<ThanhVien> thanhVienList { get; set; }
        public ObservableCollection<CacMocLoTrinh> loTrinhList { get; set; }
        public List<CHUYENDI_THANHVIEN> tvThamGiaList { get; set; }
        //Cac khoan thu

        public TripDetailVM() { }
        public TripDetailVM(string maChuyenDi)
        {
            ChuyenDiDAOImpl cdDao = new ChuyenDiDAOImpl();
            chuyenDi = cdDao.getChuyenDiById(maChuyenDi);

            MucChiDAOlmpl mcDao = new MucChiDAOlmpl();
            mucChiList = mcDao.GetMucChiByTripId(maChuyenDi);

            hinhAnhList = new ObservableCollection<HinhAnhChuyenDi>();
            
            hinhAnhList.Add(new HinhAnhChuyenDi() { HinhAnh =  chuyenDi.AnhBia});
            HinhAnhChuyenDiDAOlmpl haDao = new HinhAnhChuyenDiDAOlmpl();
            List<HinhAnhChuyenDi> haList = haDao.GetAllHinhAnhChuyenDi();

            foreach (var ha in haList)
            {
                if(ha.MaChuyenDi == maChuyenDi)
                {
                    hinhAnhList.Add(ha);
                }
            }

            thanhVienList = new ObservableCollection<ThanhVien>();
            ChuyenDiThanhVienDAOImpl tvDao = new ChuyenDiThanhVienDAOImpl();
            List<CHUYENDI_THANHVIEN> cdtvList = tvDao.GetCHUYENDI_THANHVIENList();
            tvThamGiaList = new List<CHUYENDI_THANHVIEN>();
            ThanhVienDAOlmpl memDao = new ThanhVienDAOlmpl();
            foreach(var tv in cdtvList)
            {
                if (tv.MaChuyenDi == maChuyenDi)
                {
                    tvThamGiaList.Add(tv);
                    ThanhVien tmp = memDao.GetMemberById(tv.MaThanhVien);
                    thanhVienList.Add(tmp);
                }
            }

            loTrinhList = new ObservableCollection<CacMocLoTrinh>();
            CacMocLoTrinhDAOlmpl ltDao = new CacMocLoTrinhDAOlmpl();
            List<CacMocLoTrinh> ltList = ltDao.GetAllCacMocLoTrinh();

            foreach(var lt in ltList)
            {
                if(lt.MaChuyenDi == maChuyenDi)
                {
                    loTrinhList.Add(lt);
                }
            }
        }
    }
}
