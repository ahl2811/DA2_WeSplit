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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DA2_WeSplit.Screens
{
    /// <summary>
    /// Interaction logic for TripDetailScreen.xaml
    /// </summary>
    public partial class TripDetailScreen : UserControl
    {
        public delegate void DelegateType(int type);
        public event DelegateType ExitHandler;
        public int type;
        public TripDetailScreen(int type)
        {
            InitializeComponent();
            this.type = type;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            if (ExitHandler != null)
            {
                ExitHandler(this.type);
            }
        }
    }
}
