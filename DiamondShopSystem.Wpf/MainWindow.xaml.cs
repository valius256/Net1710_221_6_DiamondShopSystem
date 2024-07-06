using DiamondShopSystem.Wpf.UI;
using DiamondShopSystem.Wpf.UI.Order;
using DiamondShopSystem.Wpf.UI.OrderDetails;
using System.Windows;

namespace DiamondShopSystem.Wpf
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
        private void Open_wProduct_Click(object sender, RoutedEventArgs e)
        {
            var p = new wProduct();
            p.Owner = this;
            p.Show();
        }

        private async void Open_wOrder_Click(object sender, RoutedEventArgs e)
        {
            var order = new wOrder();
            order.Owner = this;
            order.Show();
        }
        private async void Open_wCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customer = new wCustomer();
            customer.Owner = this;
            customer.Show();
        }
        private async void Open_wMainDiamond_Click(object sender, RoutedEventArgs e)
        {
            var mainDiamond = new wMainDiamond();
            mainDiamond.Owner = this;
            mainDiamond.Show();
        }
        private async void Open_wDiamondSetting_Click(object sender, RoutedEventArgs e)
        {
            var diamondSetting = new wDiamondSetting();
            diamondSetting.Owner = this;
            diamondSetting.Show();
        }
        private async void Open_wSideStone_Click(object sender, RoutedEventArgs e)
        {
            var sideStone = new wSideStone();
            sideStone.Owner = this;
            sideStone.Show();
        }

        private async void Open_wOrderDetail_Click(object sender, RoutedEventArgs e)
        {
            var sideStone = new wOrderDetail();
            sideStone.Owner = this;
            sideStone.Show();
        }

    }
}