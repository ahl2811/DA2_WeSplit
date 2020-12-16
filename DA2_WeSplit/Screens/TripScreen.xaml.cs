using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            //NewTrip newTrip = new NewTrip();
            //newTrip.Show();
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
            cdList.Clear();
            foreach (var trip in cdDao.GetAllChuyenDi())
            {
                cdList.Add(trip);
            }
            String filterQuery = keywordTextBox.Text;
            if (filterQuery == "")
            {
                tripVM.TripList.Clear();
                foreach (var trip in cdDao.GetAllChuyenDi())
                {
                    tripVM.TripList.Add(trip);
                }
            } else
            {
                for (int i = 0; i < cdList.Count(); i++)
                {
                    ChuyenDi trip = cdList[i];
                    if (!trip.TenChuyenDi.ToLower().Contains(filterQuery.ToLower()))
                    {
                        i--;
                        tripVM.TripList.Remove(trip);
                    }
                }
            }
        }
    }
}
