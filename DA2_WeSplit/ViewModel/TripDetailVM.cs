using DA2_WeSplit.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA2_WeSplit.ViewModel
{
    class ThanhVien_TraLai
    {
        public string TenThanhVien { get; set; }
        public int SoTien { get; set; }

        public ThanhVien_TraLai() { }
        public ThanhVien_TraLai(string ten, int tien)
        {
            this.TenThanhVien = ten;
            this.SoTien = tien;
        }

    }
    class TongKet
    {
        public int Tong { get; set; }
        public int TrungBinh { get; set; }
        public List<ThanhVien_TraLai> ThanhVienTraLai { get; set; }

        public TongKet() { 
            ThanhVienTraLai = new List<ThanhVien_TraLai>();
            Tong = 0;
            TrungBinh = 0;
        }

    }
    class TripDetailVM
    {
        public ChuyenDi chuyenDi { get; set; }
        public ObservableCollection<MucChi> mucChiList { get; set; }
        public ObservableCollection<HinhAnhChuyenDi> hinhAnhList { get; set; }
        public ObservableCollection<ThanhVien> thanhVienList { get; set; }
        public ObservableCollection<CacMocLoTrinh> loTrinhList { get; set; }
        public List<CHUYENDI_THANHVIEN> tvThamGiaList { get; set; }
        //Cac khoan thu
        public TongKet tongKet { get; set; }
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

            tongKet = new TongKet();
            int sum = 0;
            foreach(var mc in mucChiList)
            {
                sum += mc.SoTien;
            }
            tongKet.Tong = sum;

            

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

            int count = 0;
            foreach (var tv in thanhVienList)
            {
                count++;
            }
            tongKet.TrungBinh = tongKet.Tong / count;
            //Tien tra lai cua cac thanh vien
            ThanhVienDAOlmpl thanhVienDao = new ThanhVienDAOlmpl();
            foreach (var tvtg in tvThamGiaList)
            {
                ThanhVien tmp = thanhVienDao.GetMemberById(tvtg.MaThanhVien);
                ThanhVien_TraLai tvtl = new ThanhVien_TraLai();
                tvtl.TenThanhVien = tmp.TenThanhVien;
                tvtl.SoTien = tvtg.TienThu - tongKet.TrungBinh;
                tongKet.ThanhVienTraLai.Add(tvtl);
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
