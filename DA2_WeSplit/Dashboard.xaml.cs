using System;
using System.Collections.Generic;
using System.Globalization;
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
using DA2_WeSplit.Screens;
namespace DA2_WeSplit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
            TripScreen allTripScreen = new TripScreen();
            MainScreen.Children.Add(allTripScreen);
            allTripScreen.LearnMoreHandler += LearnMoreButtonClick;
            allTripScreen.AddNewTripHandler += AddNewTripClick;
        }

        private void AddNewTripClick()
        {
            var newTrip = new NewTripScreen();
            MainScreen.Children.Clear();
            MainScreen.Children.Add(newTrip);
        }

        private void RowDefinition_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void AllTripButton_Click(object sender, RoutedEventArgs e)
        {
     
            MainScreen.Children.Clear();
            TripScreen allTripScreen = new TripScreen();
            MainScreen.Children.Add(allTripScreen);
            allTripScreen.LearnMoreHandler += LearnMoreButtonClick;
            allTripScreen.AddNewTripHandler += AddNewTripClick;
        }

        private void LearnMoreButtonClick()
        {
            MainScreen.Children.Clear();
            MainScreen.Children.Add(new TripDetailScreen());
        }

        private void CurrentTripButton_Click(object sender, RoutedEventArgs e)
        {
            MainScreen.Children.Clear();
            TripScreen currentTripScreen = new TripScreen();
            MainScreen.Children.Add(currentTripScreen);
            currentTripScreen.LearnMoreHandler += LearnMoreButtonClick;
            currentTripScreen.AddNewTripHandler += AddNewTripClick;
        }

        private void PassedTripButton_Click(object sender, RoutedEventArgs e)
        {
            MainScreen.Children.Clear();
            TripScreen passedTripScreen = new TripScreen();
            MainScreen.Children.Add(passedTripScreen);
            passedTripScreen.LearnMoreHandler += LearnMoreButtonClick;
            passedTripScreen.AddNewTripHandler += AddNewTripClick;
        }

        private void SettingButton_Click(object sender, RoutedEventArgs e)
        {
            MainScreen.Children.Clear();
            MainScreen.Children.Add(new SettingScreen());
        }

        private void SupportButton_Click(object sender, RoutedEventArgs e)
        {
            MainScreen.Children.Clear();
            MainScreen.Children.Add(new SupportScreen());
        }
    }

}
