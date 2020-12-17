using DA2_WeSplit.Database;
using DA2_WeSplit.ViewModel;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
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
    /// <summary>
    /// Interaction logic for TripDetailScreen.xaml
    /// </summary>
    /// 
    
    public sealed partial class TripDetailScreen : UserControl
    {
        public delegate void DelegateType(int type);
        public event DelegateType ExitHandler;
        public int type;
        
        TripDetailVM tripDetailVM;
        public TripDetailScreen(int type, string maChuyenDi)
        {
            ObservableCollection<MucChi> mc = new ObservableCollection<MucChi>();
            MucChiDAOlmpl mcDao = new MucChiDAOlmpl();

            InitializeComponent();

            this.type = type;
            tripDetailVM = new TripDetailVM(maChuyenDi);
            this.DataContext = tripDetailVM;
            PlaceListView.ItemsSource = tripDetailVM.loTrinhList;
            ImageListView.ItemsSource = tripDetailVM.hinhAnhList;
            ThanhVienListView.ItemsSource = tripDetailVM.thanhVienList;
            TongKetListView.ItemsSource = tripDetailVM.tongKet.ThanhVienTraLai;

            foreach (MucChi m in tripDetailVM.mucChiList)
            {
                PieSeries ps = new PieSeries() { Title = m.NDChi, Values = new ChartValues<int> { m.SoTien }, DataLabels = true };
                myChart.Series.Add(ps);
            }
            myChart.FontSize = 12;
            myChart.Foreground = new SolidColorBrush(Colors.DimGray);
        }


        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            if (ExitHandler != null)
            {
                ExitHandler(this.type);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ThanhVienDAOlmpl tv = new ThanhVienDAOlmpl();
            foreach (CHUYENDI_THANHVIEN mt in tripDetailVM.tvThamGiaList)
            {
                ThanhVien tmp = tv.GetMemberById(mt.MaThanhVien);
                PieSeries ps = new PieSeries() { Title = tmp.TenThanhVien, Values = new ChartValues<int> { mt.TienThu }, DataLabels = true };
                myChart2.Series.Add(ps);
            }
            myChart2.FontSize = 12;
            myChart2.Foreground = new SolidColorBrush(Colors.DimGray);
        }

        private void PlaceButton_Checked(object sender, RoutedEventArgs e)
        {
            PlaceBorder.Visibility = Visibility.Visible;
            PlaceButton.Content = "<< Thu gọn";
            PlaceButton.Foreground = new SolidColorBrush(Colors.Red);
        }

        private void MemberButton_Checked(object sender, RoutedEventArgs e)
        {
            MemberBorder.Visibility = Visibility.Visible;
            MemberButton.Content = "<< Thu gọn";
            MemberButton.Foreground = new SolidColorBrush(Colors.Red);
        }

        private void PlaceButton_Unchecked(object sender, RoutedEventArgs e)
        {
            PlaceBorder.Visibility = Visibility.Collapsed;
            PlaceButton.Content = "Mở rộng >>";
            PlaceButton.Foreground = new SolidColorBrush(Colors.Blue);
        }

        private void MemberButton_Unchecked(object sender, RoutedEventArgs e)
        {
            MemberBorder.Visibility = Visibility.Collapsed;
            MemberButton.Content = "Mở rộng >>";
            MemberButton.Foreground = new SolidColorBrush(Colors.Blue);
        }

        private void ImageListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ImageListView.SelectedIndex;
            var imgName = tripDetailVM.hinhAnhList[index].HinhAnh;

            
            try
            {
                var bitmap = new BitmapImage(new Uri(@imgName, UriKind.Relative));
                mainImage.ImageSource = bitmap;
            }
            catch (Exception)
            {
                
            }
            
            //try
            //{
            //    mainImage.ImageSource = new BitmapImage(new Uri(@imgName, UriKind.Relative));
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Anh nay khong ton tai");
            //};

        }
    }
}
