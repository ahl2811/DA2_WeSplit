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
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
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
                var screen = new Dashboard();
                screen.Show();
                this.Close();
            }
            else
            {
                timer = new System.Timers.Timer();
                timer.Elapsed += Timer_Elapsed;
                timer.Interval = 1000;
                timer.Start();
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
