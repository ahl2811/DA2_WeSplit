using DA2_WeSplit.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DA2_WeSplit.Screens
{
    public partial class SplashScreen : Window
    {
        public SplashScreen()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var value = ConfigurationManager.AppSettings["ShowSplashScreen"];
            var showSplash = bool.Parse(value);

            if (showSplash == false)
            {
                this.Hide();
                var screen = new Dashboard();
                screen.Show();
                this.Close();
            }
            else
            {
                loadUI();
                timer = new System.Timers.Timer();
                timer.Elapsed += Timer_Elapsed;
                timer.Interval = 1000;
                timer.Start();
            }
        }

        private void loadUI()
        {
            String db = "QLChuyenDi";
            String con = $"Server=localhost; Database= master; Trusted_Connection=True;";
            bool isHasDatabase = DatabaseHelper.isDatabaseExists(con, db);
            if(!isHasDatabase)
            {
                return;
            }

            ChuyenDiDAOImpl chuyenDiDAOImpl = new ChuyenDiDAOImpl();
            if(chuyenDiDAOImpl.GetAllChuyenDi().Count() > 0)
            {
                Random random = new Random();
                int index = random.Next(chuyenDiDAOImpl.GetAllChuyenDi().Count());

                ChuyenDi trip = chuyenDiDAOImpl.GetAllChuyenDi()[index];
                txtTripTittle.Text = trip.TenChuyenDi;
                txtTripDescription.Text = trip.MoTa;

                HinhAnhChuyenDiDAOlmpl hinhAnhChuyenDiDAOlmpl = new HinhAnhChuyenDiDAOlmpl();
                HinhAnhChuyenDi tripImage = hinhAnhChuyenDiDAOlmpl.getTripImageByTripCode(trip.MaChuyenDi);

                if (tripImage == null || tripImage.HinhAnh == null || tripImage.HinhAnh == "")
                {
                    Uri uri = new Uri("../Assets/Images/default_trip_image.jpg", UriKind.RelativeOrAbsolute);
                    imgTrip.Source = new BitmapImage(uri);
                }
                else
                {
                    Uri uri = new Uri(tripImage.HinhAnh, UriKind.RelativeOrAbsolute);
                    imgTrip.Source = new BitmapImage(uri);
                }
            } else
            {
                //do nothing. use default screen in xml
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            count++;
            if (count == target)
            {
                timer.Stop();
                Dispatcher.Invoke(() =>
                {
                    var screen = new Dashboard();
                    screen.Show();
                    if (btnUnSubcript.IsChecked == true)
                    {
                        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        config.AppSettings.Settings["ShowSplashScreen"].Value = "false";
                        config.Save(ConfigurationSaveMode.Minimal);
                    }
                    this.Close();
                });

            }
            Dispatcher.Invoke(() =>
            {
                progress.Value = count;
            });
        }

        int count = 0;
        int target = 8;
        System.Timers.Timer timer;
    }
}
