using DiamondShopSystem.Business.Business.Implement;
using DiamondShopSystem.Business.Business.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace DiamondShopSystem.Wpf.UI.Order
{
    /// <summary>
    /// Interaction logic for wOrder.xaml
    /// </summary>
    public partial class wOrder : Window
    {
        private readonly IOrderBusiness _orderBusiness;
        private DiamondShopSystem.DataAccess.Models.Order Order;
        public wOrder()
        {
            InitializeComponent();
            _orderBusiness = new OrderBusiness(); // Initialize your business logic here
            LoadGrdOrder();

        }

        private async void LoadGrdOrder()
        {
            try
            {
                var result = await _orderBusiness.GetAllOrder();

                if (result.Status > 0 && result.Data != null)
                {
                    grdOrder.ItemsSource = result.Data as List<DiamondShopSystem.DataAccess.Models.Order>;
                }
                else
                {
                    grdOrder.ItemsSource = new List<DiamondShopSystem.DataAccess.Models.Order>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading orders: {ex.Message}", "Error");
            }
        }

        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validate inputs
                if (!ValidateInputs())
                {
                    MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var item = await _orderBusiness.GetOrderById(int.Parse(txtOrderId.Text));


                if (item.Data == null)
                {
                    var order = new DiamondShopSystem.DataAccess.Models.Order
                    {
                        //OrderId = int.Parse(txtOrderId.Text), // Use txtOrderId for OrderId input
                        CustomerId = int.Parse(txtCustomerId.Text),
                        OrderDate = dpOrderDate.SelectedDate ?? DateTime.Now,
                        OrderStatus = cmbOrderStatus.SelectedItem != null ? ((ComboBoxItem)cmbOrderStatus.SelectedItem).Content.ToString() : null,
                        DeliveryStatus = cmbDeliveryStatus.SelectedItem != null ? ((ComboBoxItem)cmbDeliveryStatus.SelectedItem).Content.ToString() : null,
                        TotalAmount = decimal.Parse(txtTotalAmount.Text),
                        CreateAt = DateTime.Now,
                        UpdateAt = DateTime.Now,
                        Note = txtNote.Text,
                        TotalPrice = decimal.Parse(txtTotalAmount.Text) * 1200,
                    };

                    var result = await _orderBusiness.CreateOrder(order);
                    MessageBox.Show(result.Message, "Save");


                }
                else
                {
                    var order = item.Data as DiamondShopSystem.DataAccess.Models.Order;
                    order.CustomerId = int.Parse(txtCustomerId.Text);
                    order.OrderDate = dpOrderDate.SelectedDate ?? DateTime.Now;
                    order.OrderStatus = cmbOrderStatus.SelectedItem != null ? ((ComboBoxItem)cmbOrderStatus.SelectedItem).Content.ToString() : null;
                    order.DeliveryStatus = cmbDeliveryStatus.SelectedItem != null ? ((ComboBoxItem)cmbDeliveryStatus.SelectedItem).Content.ToString() : null;
                    order.TotalAmount = decimal.Parse(txtTotalAmount.Text);
                    order.UpdateAt = DateTime.Now;
                    order.Note = txtNote.Text;
                    order.TotalPrice = decimal.Parse(txtTotalAmount.Text) * 1200;

                    var result = await _orderBusiness.UpdateOrder(order);
                    MessageBox.Show(result.Message, "Update");
                }


                ClearInputs();
                LoadGrdOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
            }
        }

        private bool ValidateInputs()
        {
            // Perform validation as needed
            if (string.IsNullOrWhiteSpace(txtCustomerId.Text))
                return false;

            if (dpOrderDate.SelectedDate == null)
                return false;

            if (cmbOrderStatus.SelectedItem == null)
                return false;

            return true;
        }

        private void ClearInputs()
        {
            // Clear input fields after save
            txtCustomerId.Text = string.Empty;
            dpOrderDate.SelectedDate = null;
            cmbOrderStatus.SelectedItem = null;
            cmbDeliveryStatus.SelectedItem = null;
            txtTotalAmount.Text = string.Empty;
            txtNote.Text = string.Empty;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the window on cancel
        }

        private async void grdOrder_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int orderId = int.Parse(btn.CommandParameter.ToString());

            if (orderId > 0)
            {
                if (MessageBox.Show("Do you want to delete this item?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    var result = await _orderBusiness.DeleteOrder(orderId);
                    MessageBox.Show($"{result.Message}", "Delete");

                    // Refresh data grid after deletion
                    LoadGrdOrder();
                }
            }
        }

        private async void grdOrder_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            DataGrid grd = sender as DataGrid;
            if (grdOrder.SelectedItem != null)
            {
                var selectedItem = (DiamondShopSystem.DataAccess.Models.Order)grdOrder.SelectedItem;
                Order = selectedItem;
                grdOrder.DataContext = Order;


                txtOrderId.Text = Order.OrderId.ToString();
                txtCustomerId.Text = Order.CustomerId.ToString();
                dpOrderDate.SelectedDate = Order.OrderDate;
                // Set selected items in ComboBoxes based on OrderStatus and DeliveryStatus
                SetComboBoxSelectedItems();
                txtTotalAmount.Text = Order.TotalAmount.ToString();
                txtNote.Text = Order.Note;

            }
        }

        private void SetComboBoxSelectedItems()
        {
            // Set selected items in ComboBoxes based on OrderStatus and DeliveryStatus
            foreach (ComboBoxItem item in cmbOrderStatus.Items)
            {
                if (item.Content.ToString() == Order.OrderStatus)
                {
                    cmbOrderStatus.SelectedItem = item;
                    break;
                }
            }

            foreach (ComboBoxItem item in cmbDeliveryStatus.Items)
            {
                if (item.Content.ToString() == Order.DeliveryStatus)
                {
                    cmbDeliveryStatus.SelectedItem = item;
                    break;
                }
            }
        }

        private void grdOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle selection changed logic if necessary
        }
    }
}
