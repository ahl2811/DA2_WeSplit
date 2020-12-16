using DA2_WeSplit.Database;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DA2_WeSplit.Screens
{
    class ThanhVien_TienThu
    {
        public string TenThanhVien { get; set; }
        public string SoTien { get; set; }

        public ThanhVien_TienThu() { }

        public ThanhVien_TienThu(string ten, string tien)
        {
            this.TenThanhVien = ten;
            this.SoTien = tien;
        }
    }
    public partial class NewTripScreen : UserControl
    {
        String maChuyenDi;
        string AvatarName = "";
        string anhbiaChuyenDi = "";
        string newNameAvt = "";
        ObservableCollection<MucChi> extraExpense;
        ObservableCollection<CacMocLoTrinh> milestones;
        ObservableCollection<ThanhVien> members;
        ObservableCollection<HinhAnhChuyenDi> images;
        ObservableCollection<ThanhVien_TienThu> thanhVien_TienThu;
        ObservableCollection<HinhAnhChuyenDi> imagesTemp;
        ObservableCollection<CHUYENDI_THANHVIEN> trip_memberList;
        
        public delegate void DelegateType(int type);
        public event DelegateType ExitHandler;
        public int type;

        ChuyenDiDAOImpl chuyenDiDAOImpl = new ChuyenDiDAOImpl();
        CacMocLoTrinhDAOlmpl cacMocLoTrinhDAOlmpl = new CacMocLoTrinhDAOlmpl();
        MucChiDAOlmpl mucChiDAOlmpl = new MucChiDAOlmpl();
        ThanhVienDAOlmpl thanhVienDAOlmpl = new ThanhVienDAOlmpl();
        HinhAnhChuyenDiDAOlmpl hinhAnhChuyenDiDAOlmpl = new HinhAnhChuyenDiDAOlmpl();
        ChuyenDiThanhVienDAOImpl chuyenDiThanhVienDAOImpl = new ChuyenDiThanhVienDAOImpl();


        public NewTripScreen(int type)
        {
            InitializeComponent();
            this.type = type;

            extraExpense = new ObservableCollection<MucChi>();
            lbCostList.ItemsSource = extraExpense;

            milestones = new ObservableCollection<CacMocLoTrinh>();
            lbMilestones.ItemsSource = milestones;

            members = new ObservableCollection<ThanhVien>();
            thanhVien_TienThu = new ObservableCollection<ThanhVien_TienThu>();
            lbMembers.ItemsSource = thanhVien_TienThu;

            images = new ObservableCollection<HinhAnhChuyenDi>();
            

            imagesTemp = new ObservableCollection<HinhAnhChuyenDi>();
            lbImages.ItemsSource = imagesTemp;
            trip_memberList = new ObservableCollection<CHUYENDI_THANHVIEN>();

            maChuyenDi = (chuyenDiDAOImpl.GetAllChuyenDi().Count() + 1).ToString();
        }
        public NewTripScreen()
        {
            InitializeComponent();

            extraExpense = new ObservableCollection<MucChi>();
            lbCostList.ItemsSource = extraExpense;

            milestones = new ObservableCollection<CacMocLoTrinh>();
            lbMilestones.ItemsSource = milestones;

            members = new ObservableCollection<ThanhVien>();
            thanhVien_TienThu = new ObservableCollection<ThanhVien_TienThu>();
            lbMembers.ItemsSource = thanhVien_TienThu;

            images = new ObservableCollection<HinhAnhChuyenDi>();
            

            imagesTemp = new ObservableCollection<HinhAnhChuyenDi>();
            lbImages.ItemsSource = imagesTemp;

            trip_memberList = new ObservableCollection<CHUYENDI_THANHVIEN>();

            maChuyenDi = (chuyenDiDAOImpl.GetAllChuyenDi().Count() + 1).ToString();
        }

        private void OnAddNewCost(object sender, RoutedEventArgs e)
        {
            String costDetail = txtCostDetail.Text;
            String cost = txtCost.Text;

            if(cost == "")
            {
                MessageBox.Show("Bạn chưa nhập giá");
                return;
            }
            
            if(costDetail == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung chi tiêu");
                return;
            }

            MucChi mucChi = new MucChi();
            mucChi.STT = mucChiDAOlmpl.GetAllMucChi().Count() + extraExpense.Count() + 1;
            mucChi.SoTien = Int32.Parse(cost);
            mucChi.NDChi = costDetail;
            mucChi.MaChuyenDi = maChuyenDi;

            extraExpense.Add(mucChi);

            txtCostDetail.Text = "";
            txtCost.Text = "";
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            if (ExitHandler != null)
            {
                ExitHandler(this.type);
            }
        }

        private void OnAddNewMilestone(object sender, RoutedEventArgs e)
        {
            String milestone = txtMilestone.Text;

            if (milestone == "")
            {
                MessageBox.Show("Bạn chưa nhập mốc lộ trình");
                return;
            }


            CacMocLoTrinh cacMocLoTrinh = new CacMocLoTrinh();
            cacMocLoTrinh.MaChuyenDi = this.maChuyenDi;
            cacMocLoTrinh.MocLoTrinh = milestone;

            foreach (CacMocLoTrinh tmp in milestones)
            {
                if (tmp.MocLoTrinh.Equals(cacMocLoTrinh.MocLoTrinh))
                {
                    MessageBox.Show("Đã tồn tại mốc lộ trình này");
                    txtMilestone.Text = "";
                    return;
                }
            }
            milestones.Add(cacMocLoTrinh);
            txtMilestone.Text = "";
        }

        private void OnAddNewMember(object sender, RoutedEventArgs e)
        {
            String memberName = txtMemberName.Text;
            String memberFee = txtMemberFee.Text;

            if (memberName == "")
            {
                MessageBox.Show("Bạn chưa nhập tên thành viên");
                txtMemberFee.Text = "";
                return;
            } else if(memberFee == "")
            {
                MessageBox.Show("Bạn chưa nhập tiền thu");
                txtMemberName.Text = "";
                return;
            }

            ThanhVien thanhVien = new ThanhVien();

            int memberCount = (thanhVienDAOlmpl.GetAllThanhVien().Count() + members.Count() + 1);

            thanhVien.MaThanhVien = memberCount.ToString();
            thanhVien.TenThanhVien = memberName;

            members.Add(thanhVien);
            trip_memberList.Add(new CHUYENDI_THANHVIEN() { MaChuyenDi = this.maChuyenDi,
                MaThanhVien = thanhVien.MaThanhVien,
                TienThu = Int32.Parse(memberFee)
            });

            thanhVien_TienThu.Add(new ThanhVien_TienThu(thanhVien.TenThanhVien, memberFee));

            txtMemberName.Text = "";
            txtMemberFee.Text = "";
        }

        List<string> fileList = new List<string>();
        private void OnAddNewImage(object sender, RoutedEventArgs e)
        {
            var screen = new OpenFileDialog();
            screen.Multiselect = true;

            if (screen.ShowDialog() == true)
            {
                var files = screen.FileNames;

                foreach (var file in files)
                {

                    var info = new FileInfo(file);
                    //var newName = $"{Guid.NewGuid()}{info.Extension}";

                    //var currentFolder = AppDomain.CurrentDomain.BaseDirectory;
                    //File.Copy(file, $"{currentFolder}Assets\\Images\\{newName}");
                    fileList.Add(file);
                    HinhAnhChuyenDi newImageTemp = new HinhAnhChuyenDi() { HinhAnh = info.ToString(), MaChuyenDi = this.maChuyenDi };
                    //HinhAnhChuyenDi newImage = new HinhAnhChuyenDi() { HinhAnh = newName, MaChuyenDi = this.maChuyenDi };

                    //foreach (HinhAnhChuyenDi image in images)
                    //{
                    //    if(image.HinhAnh.Equals(newImage.HinhAnh))
                    //    {
                    //        MessageBox.Show("Đã tồn tại hình ảnh này");
                    //        return;
                    //    }
                    //}

                    imagesTemp.Add(newImageTemp);
                }
            }
        }
        
        private void OnSubmit(object sender, RoutedEventArgs e)
        {
            String tripName = txtTripName.Text;
            String curStateString = cbTrangThai.Text;
            String location = txtLocation.Text;
            String description = txtDescription.Text;

            if (tripName == "")
            {
                MessageBox.Show("Bạn chưa nhập tên chuyến đi");
            }
            else if (location == "")
            {
                MessageBox.Show("Bạn chưa nhập địa điểm chuyến đi");
            }

            int curState = 1;
            if(curStateString.Equals("Đang đi"))
            {
                curState = 0;
            }

            ChuyenDi newTrip = new ChuyenDi(maChuyenDi, tripName, curState, location, description, anhbiaChuyenDi);
            chuyenDiDAOImpl.addChuyenDi(newTrip);

            if (extraExpense.Count() > 0)
            {
                foreach (MucChi mucChi in extraExpense)
                {
                    mucChiDAOlmpl.addMucChi(mucChi);
                }
            }

            if (milestones.Count() > 0)
            {
                foreach (CacMocLoTrinh milistone in milestones)
                {
                    cacMocLoTrinhDAOlmpl.addCacMocLoTrinh(milistone);
                }
            }

            if(members.Count() > 0)
            { 
                foreach (ThanhVien member in members)
                {
                    thanhVienDAOlmpl.addThanhVien(member);
                }

                foreach(CHUYENDI_THANHVIEN trip_member in trip_memberList)
                {
                    chuyenDiThanhVienDAOImpl.addChuyenDiThanhVien(trip_member);
                }
            }

            

            if (fileList.Count() > 0)
            {
                //foreach(HinhAnhChuyenDi image in images)
                //{
                //    hinhAnhChuyenDiDAOlmpl.addHinhAnhChuyenDi(image);
                //}

                var currentFolder = AppDomain.CurrentDomain.BaseDirectory;
                
                foreach (string file in fileList)
                {
                    var info = new FileInfo(file);
                    var newName = $"{Guid.NewGuid()}{info.Extension}";
                    File.Copy(file, $"{currentFolder}Assets\\Images\\{newName}");
                    HinhAnhChuyenDi newImage = new HinhAnhChuyenDi() { HinhAnh = newName, MaChuyenDi = this.maChuyenDi };
                    hinhAnhChuyenDiDAOlmpl.addHinhAnhChuyenDi(newImage);

                }
            }
            //ChuyenDi newTrip = new ChuyenDi(maChuyenDi, tripName, curState, location, description, anhbia);
            //chuyenDiDAOImpl.addChuyenDi(newTrip);
            if(anhbiaChuyenDi != "")
            {
                var currentFolder = AppDomain.CurrentDomain.BaseDirectory;
                string file = AvatarName;
                File.Copy(file, $"{currentFolder}Assets\\Images\\{newNameAvt}");
            }
            MessageBox.Show("Đã hoàn thành");
        }

        

        private void addAvatar_Click(object sender, RoutedEventArgs e)
        {
            var screen = new OpenFileDialog();
            screen.Multiselect = true;

            if (screen.ShowDialog() == true)
            {
                var files = screen.FileNames;

                foreach (var file in files)
                {

                    var info = new FileInfo(file);
                    AvatarName = file;

                    var newName = $"{Guid.NewGuid()}{info.Extension}";
                    anhbiaChuyenDi = newName;
                    newNameAvt = newName;

                    try
                    {
                        var bitmap = new BitmapImage(new Uri(@file, UriKind.Relative));
                        Avatar.ImageSource = bitmap;
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }
    }
}
