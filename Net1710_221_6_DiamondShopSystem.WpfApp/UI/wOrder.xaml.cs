using DiamondShopSystem.Business.Business.Implement;
using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Data.Models;
using System.Windows;

namespace Net1710_221_6_DiamondShopSystem.WpfApp.UI
{
    /// <summary>
    /// Interaction logic for wOrder.xaml
    /// </summary>
    ///

    public partial class wOrder : Window
    {

        private readonly IOrderBusiness _orderBusiness;
        public wOrder()
        {
            InitializeComponent();
            _orderBusiness ??= new OrderBusiness();
            this.LoadGrdOrder();
        }

        private async void LoadGrdOrder()
        {
            var result = await _orderBusiness.GetAllOrder();

            if (result.Status > 0 && result.Data != null)
            {
                grdOrder.ItemsSource = result.Data as List<Order>;
            }
            else
            {
                grdOrder.ItemsSource = new List<Order>();
            }
        }

        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void grdOrder_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {


        }

        private async void grdOrder_MouseDouble_Click(object sender, RoutedEventArgs e)
        {


        }

        private void grdOrder_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
