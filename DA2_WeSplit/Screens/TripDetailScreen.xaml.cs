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


    public class Population : INotifyPropertyChanged
    {
        private string _name = string.Empty;
        private int _count = 0;

        // Tên hiển thị mỗi thành phần Chart
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }

        // Data cho Chart
        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                NotifyPropertyChanged("Count");
            }

        }

        // Phần dưới là implement của INotifyPropertyChanged - tự động cập nhật data.
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class MainViewModel
    {
        // Property sẽ được Binding từ GUI(View)
        public ObservableCollection<Population> Populations { get; private set; }
        // Add data(Model-Item) cho List

        List<PieSeries> PieChartSeriesCollection { get; set; }
        public MainViewModel()
        {
            Populations = new ObservableCollection<Population>();
            Populations.Add(new Population() { Name = "China", Count = 1340 });
            Populations.Add(new Population() { Name = "India", Count = 1220 });
            Populations.Add(new Population() { Name = "United States", Count = 309 });
            Populations.Add(new Population() { Name = "Indonesia", Count = 240 });
            Populations.Add(new Population() { Name = "Brazil", Count = 195 });
            Populations.Add(new Population() { Name = "Pakistan", Count = 174 });
            Populations.Add(new Population() { Name = "Nigeria", Count = 158 });

            //if (PieChartSeriesCollection != null) PieChartSeriesCollection.Clear(); foreach (KeyValuePair<string, int> pair in DictionaryOfData)
            //{  Dictionary<string, int> PieChartSeriesCollection .Add( new PieSeries { Title = $"{pair.Value} ({pair.Key})", Values = new ChartValues<int> { pair.Value }, DataLabels = true }); }
            //}

            if (PieChartSeriesCollection != null)
            {
                PieChartSeriesCollection.Clear();
            }
            else
            {
                PieChartSeriesCollection = new List<PieSeries>();
            }
            foreach (Population p in Populations)
            {
                PieChartSeriesCollection.Add(new PieSeries(){ Title = $"{p.Name} ({p.Count})", Values = new ChartValues<int> { p.Count }, DataLabels = true });
            }
            foreach(PieSeries p in PieChartSeriesCollection)
            {
                
            }
        }

        private object selectedItem = null;
        public object SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                // selected item has changed
                selectedItem = value;
            }
        }
    }

    public sealed partial class TripDetailScreen : UserControl
    {
        public delegate void DelegateType(int type);
        public event DelegateType ExitHandler;
        public int type;
        ObservableCollection<Population> Populations;
        TripDetailVM tripDetailVM;
        public TripDetailScreen(int type, string maChuyenDi)
        {
            Populations = new ObservableCollection<Population>();
            Populations.Add(new Population() { Name = "China", Count = 1340 });
            Populations.Add(new Population() { Name = "India", Count = 1220 });
            Populations.Add(new Population() { Name = "United States", Count = 309 });
            Populations.Add(new Population() { Name = "Indonesia", Count = 240 });
            Populations.Add(new Population() { Name = "Brazil", Count = 195 });
            Populations.Add(new Population() { Name = "Pakistan", Count = 174 });
            Populations.Add(new Population() { Name = "Nigeria", Count = 158 });

            //if (PieChartSeriesCollection != null) PieChartSeriesCollection.Clear(); foreach (KeyValuePair<string, int> pair in DictionaryOfData)
            //{  Dictionary<string, int> PieChartSeriesCollection .Add( new PieSeries { Title = $"{pair.Value} ({pair.Key})", Values = new ChartValues<int> { pair.Value }, DataLabels = true }); }
            //}
            List<PieSeries> PieChartSeriesCollection;

            ObservableCollection<MucChi> mc = new ObservableCollection<MucChi>();
            MucChiDAOlmpl mcDao = new MucChiDAOlmpl();

            //mainImage.ImageSource = new BitmapImage(new Uri(@"", UriKind.Relative));


            PieChartSeriesCollection = new List<PieSeries>();


            InitializeComponent();

            this.type = type;
            tripDetailVM = new TripDetailVM(maChuyenDi);
            this.DataContext = tripDetailVM;
            PlaceListView.ItemsSource = tripDetailVM.loTrinhList;
            ImageListView.ItemsSource = tripDetailVM.hinhAnhList;
            ThanhVienListView.ItemsSource = tripDetailVM.thanhVienList;
            
            foreach (MucChi m in tripDetailVM.mucChiList)
            {
                PieSeries ps = new PieSeries() { Title = m.NDChi, Values = new ChartValues<int> { m.SoTien }, DataLabels = true };
                myChart.Series.Add(ps);
            }
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
            mainImage.ImageSource = new BitmapImage(new Uri(@imgName, UriKind.Relative));
        }
    }
}
