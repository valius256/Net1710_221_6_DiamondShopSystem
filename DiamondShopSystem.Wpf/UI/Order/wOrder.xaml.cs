using DiamondShopSystem.Business.Business.Implement;
using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Data.Models;
using System.Windows;
using System.Windows.Controls;

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
            try
            {

                var item = await _orderBusiness.GetOrderById(Int32.Parse(txtOrderId.Text));

                if (item.Data == null)
                {
                    var order = new Order()
                    {
                        OrderId = Int32.Parse(txtOrderId.Text),
                        CustomerId = Int32.Parse(txtCustomerId.Text),
                        OrderDate = DateTime.Parse(txtOrderDate.Text),
                        OrderStatus = txtOrderStatus.Text
                    };
                    var result = await _orderBusiness.CreateOrder(order);
                    MessageBox.Show(result.Message, "Save");
                }
                else
                {
                    var order = item.Data as Order;
                    //currency.CurrencyCode = txtCurrencyCode.Text;
                    order.OrderId = Int32.Parse(txtOrderId.Text);
                    order.CustomerId = Int32.Parse(txtCustomerId.Text);
                    order.OrderDate = DateTime.Parse(txtOrderDate.Text);
                    order.OrderStatus = txtOrderStatus.Text;
                    var result = await _orderBusiness.UpdateOrder(order);
                    MessageBox.Show(result.Message, "Update");
                }

                txtOrderId.Text = string.Empty;
                txtCustomerId.Text = string.Empty;
                txtOrderDate.Text = string.Empty;
                txtOrderStatus.Text = string.Empty;
                this.LoadGrdOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }

        private async void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void grdOrder_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            string currencyCode = btn.CommandParameter.ToString();

            //MessageBox.Show(currencyCode);

            if (!string.IsNullOrEmpty(currencyCode))
            {
                if (MessageBox.Show("Do you want to delete this item?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    var result = await _orderBusiness.DeleteOrder(Int32.Parse(currencyCode));
                    MessageBox.Show($"{result.Message}", "Delete");
                    this.LoadGrdOrder();
                }
            }
        }


        private async void grdOrder_MouseDouble_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Double Click on Grid");
            DataGrid grd = sender as DataGrid;
            if (grd != null && grd.SelectedItems != null && grd.SelectedItems.Count == 1)
            {
                var row = grd.ItemContainerGenerator.ContainerFromItem(grd.SelectedItem) as DataGridRow;
                if (row != null)
                {
                    var item = row.Item as Order;
                    if (item != null)
                    {
                        var currencyResult = await _orderBusiness.GetOrderById(item.OrderId);

                        if (currencyResult.Status > 0 && currencyResult.Data != null)
                        {
                            item = currencyResult.Data as Order;
                            txtOrderId.Text = item.OrderId.ToString();
                            txtCustomerId.Text = item.CustomerId.ToString();
                            txtOrderDate.Text = item.OrderDate.ToString();
                            txtOrderStatus.Text = item.OrderStatus;
                        }
                    }
                }
            }
        }

        private void grdOrder_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
