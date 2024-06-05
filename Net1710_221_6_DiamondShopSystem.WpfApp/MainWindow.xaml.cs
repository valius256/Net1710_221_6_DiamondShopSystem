using Net1710_221_6_DiamondShopSystem.WpfApp.UI;
using System.Windows;

namespace Net1710_221_6_DiamondShopSystem.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Open_wOrder_Click(object sender, RoutedEventArgs e)
        {
            var order = new wOrder();
            order.Owner = this;
            order.Show();
        }
    }
}