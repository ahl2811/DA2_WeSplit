using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using DA2_WeSplit.Database;
using DA2_WeSplit.Paging;

namespace DA2_WeSplit.Screens
{
    /// <summary>
    /// Interaction logic for TripScreen.xaml
    /// </summary>
    public partial class TripScreen : UserControl
    {
        public delegate void DelegateType(int type);
        public delegate void Detail_Delegate(int type, string maChuyenDi);
        public event Detail_Delegate LearnMoreHandler;
        public event DelegateType AddNewTripHandler;

        TripViewModel tripVM;
        public int Type;

        ObservableCollection<ChuyenDi> cdList;
        ChuyenDiDAOImpl cdDao = new ChuyenDiDAOImpl();


        public TripScreen(int type)
        {
            InitializeComponent();
            cdList = new ObservableCollection<ChuyenDi>();
            switch (type)
            {
                case 0:
                    Type = 0;
                    foreach(var trip in cdDao.GetAllChuyenDi())
                    {
                        cdList.Add(trip);
                    } 
                    break;

                case 1:
                    Type = 1;
                    foreach (var trip in cdDao.GetCurrentTrip())
                    {
                        cdList.Add(trip);
                    }
                    break;

                case 2:
                    Type = 2;
                    foreach (var trip in cdDao.GetPassedTrip())
                    {
                        cdList.Add(trip);
                    }
                    break;

                default:
                    Type = 0;
                    foreach (var trip in cdDao.GetAllChuyenDi())
                    {
                        cdList.Add(trip);
                    }
                    break;
            }
            this.tripVM = new TripViewModel(cdList);
            this.DataContext = tripVM;
            TripListView.ItemsSource = tripVM.TripList;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            keywordPlaceholderTextBlock.Visibility = Visibility.Hidden;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (keywordTextBox.Text.Length == 0)
            {
                keywordPlaceholderTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (AddNewTripHandler != null)
            {
                AddNewTripHandler(Type);
            }
        }

        private void LearnMoreButton_Click(object sender, RoutedEventArgs e)
        {
            Button sd = sender as Button;
            ChuyenDi cdi = (ChuyenDi)sd.DataContext;
            string maChuyenDi = cdi.MaChuyenDi;
            if (LearnMoreHandler != null)
            {
                LearnMoreHandler(Type, maChuyenDi);
            }
        }

        private void keywordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(cbCatalog.Text.Equals("Theo chuyến đi"))
            {
                filterByTrip();
            }
            else if (cbCatalog.Text.Equals("Theo thành viên"))
            {
                filterByMember();
            }
        }

        private void filterByMember()
        {
            cdList.Clear();
            foreach (var trip in cdDao.GetAllChuyenDi())
            {
                cdList.Add(trip);
            }
            String filterQuery = keywordTextBox.Text;
            if (!filterQuery.Equals(""))
            {
                String unSignLowerMemberName = ConvertToUnSign(filterQuery.ToLower());
                ChuyenDiThanhVienDAOImpl tripMemberDAO = new ChuyenDiThanhVienDAOImpl();
                List<CHUYENDI_THANHVIEN> trip_members = tripMemberDAO.GetCHUYENDI_THANHVIENList();

                ThanhVienDAOlmpl memberDAO = new ThanhVienDAOlmpl();
                List<ThanhVien> members = memberDAO.GetAllThanhVien();

                for (int i = 0; i < members.Count(); i++)
                {
                    ThanhVien member = members[i];
                    String unSignLowerMemberNameItem = ConvertToUnSign(member.TenThanhVien.ToLower());
                    if (!unSignLowerMemberNameItem.Contains(unSignLowerMemberName))
                    {
                        members.Remove(member);
                        i--;
                    }
                }

                for (int i = 0; i < trip_members.Count(); i++)
                {
                    CHUYENDI_THANHVIEN trip_member = trip_members[i];
                    for (int j = 0; j < members.Count(); j++)
                    {
                        if (trip_member.MaThanhVien.Equals(members[j].MaThanhVien))
                        {
                            break;
                        }

                        if (j == members.Count() - 1)
                        {
                            trip_members.Remove(trip_member);
                            i--;
                        }
                    }
                }

                for (int i = 0; i < cdList.Count(); i++)
                {
                    ChuyenDi trip = cdList[i];
                    for (int j = 0; j < trip_members.Count(); j++)
                    {
                        if (trip.MaChuyenDi.Equals(trip_members[j].MaChuyenDi))
                        {
                            break;
                        }

                        if (j == trip_members.Count() - 1)
                        {
                            i--;
                            tripVM.TripList.Remove(trip);
                        }
                    }
                }
            }
        }

        private void filterByTrip()
        {
            cdList.Clear();
            foreach (var trip in cdDao.GetAllChuyenDi())
            {
                cdList.Add(trip);
            }
            String filterQuery = keywordTextBox.Text;
            if (!filterQuery.Equals(""))
            {
                String unSignLowerTripName = ConvertToUnSign(filterQuery.ToLower());
                for (int i = 0; i < cdList.Count(); i++)
                {
                    ChuyenDi trip = cdList[i];
                    if (!ConvertToUnSign(trip.TenChuyenDi.ToLower()).Contains(unSignLowerTripName))
                    {
                        i--;
                        tripVM.TripList.Remove(trip);
                    }
                }
            }
        }


        private string ConvertToUnSign(string input)
        {
            input = input.Trim();
            for (int i = 0x20; i < 0x30; i++)
            {
                input = input.Replace(((char)i).ToString(), " ");
            }
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string str = input.Normalize(NormalizationForm.FormD);
            string str2 = regex.Replace(str, string.Empty).Replace('đ', 'd').Replace('Đ', 'D');
            while (str2.IndexOf("?") >= 0)
            {
                str2 = str2.Remove(str2.IndexOf("?"), 1);
            }
            return str2;
        }
    }
}
