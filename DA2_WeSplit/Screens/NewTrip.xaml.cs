using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace DA2_WeSplit.Screens
{
    /// <summary>
    /// Interaction logic for NewTrip.xaml
    /// </summary>
    public partial class NewTrip : Window
    {
        public NewTrip()
        {
            InitializeComponent();
        }
        private void RowDefinition_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            String tripName = txtTripName.Text;
            String location = txtLocation.Text;


            if (txtTripName.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên chuyến đi");
            } else if (txtLocation.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa điểm chuyến đi");
            }

            //chua xong
        }
    }
}
