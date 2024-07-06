using DiamondShopSystem.Business.Business.Implement;
using DiamondShopSystem.Business.Business.Interfaces;
using System.Windows;

namespace DiamondShopSystem.Wpf.UI.OrderDetails
{
    public partial class wOrderDetail : Window
    {
        private readonly IOrderDetailBusiness _orderDetailBusiness;
        private DiamondShopSystem.DataAccess.Models.OrderDetail OrderDetail;

        public wOrderDetail()
        {
            InitializeComponent();
            _orderDetailBusiness = new OrderDetailBusiness(); // Initialize your business logic here
            LoadOrderDetails();
        }

        private async void LoadOrderDetails()
        {
            try
            {
                var result = await _orderDetailBusiness.GetAllOrderDetail();

                if (result.Status > 0 && result.Data != null)
                {
                    grdOrderDetails.ItemsSource = result.Data as List<DiamondShopSystem.DataAccess.Models.OrderDetail>;
                }
                else
                {
                    grdOrderDetails.ItemsSource = new List<DiamondShopSystem.DataAccess.Models.OrderDetail>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading order details: {ex.Message}", "Error");
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

                var item = await _orderDetailBusiness.GetOrderDetailById(int.Parse(txtOrderDetailId.Text));

                if (item.Data == null)
                {
                    var orderDetail = new DiamondShopSystem.DataAccess.Models.OrderDetail
                    {
                        OrderId = int.Parse(txtOrderId.Text),
                        ProductId = int.Parse(txtProductId.Text),
                        Quantity = int.Parse(txtQuantity.Text),
                        Amount = decimal.Parse(txtAmount.Text),
                        Fee = decimal.Parse(txtFee.Text),
                        Discount = decimal.Parse(txtDiscount.Text),
                        OrderDetailNote = txtOrderDetailNotes.Text
                    };

                    var result = await _orderDetailBusiness.CreateOrderDetail(orderDetail);
                    MessageBox.Show(result.Message, "Save");
                }
                else
                {
                    var orderDetail = item.Data as DiamondShopSystem.DataAccess.Models.OrderDetail;
                    orderDetail.OrderId = int.Parse(txtOrderId.Text);
                    orderDetail.ProductId = int.Parse(txtProductId.Text);
                    orderDetail.Quantity = int.Parse(txtQuantity.Text);
                    orderDetail.Amount = decimal.Parse(txtAmount.Text);
                    orderDetail.Fee = decimal.Parse(txtFee.Text);
                    orderDetail.Discount = decimal.Parse(txtDiscount.Text);
                    orderDetail.OrderDetailNote = txtOrderDetailNotes.Text;

                    var result = await _orderDetailBusiness.UpdateOrderDetail(orderDetail);
                    MessageBox.Show(result.Message, "Update");
                }

                ClearInputs();
                LoadOrderDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
            }
        }

        private bool ValidateInputs()
        {
            // Perform validation as needed
            if (string.IsNullOrWhiteSpace(txtOrderId.Text))
                return false;

            if (string.IsNullOrWhiteSpace(txtProductId.Text))
                return false;

            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
                return false;

            if (string.IsNullOrWhiteSpace(txtAmount.Text))
                return false;

            if (string.IsNullOrWhiteSpace(txtFee.Text))
                return false;

            if (string.IsNullOrWhiteSpace(txtDiscount.Text))
                return false;

            return true;
        }

        private void ClearInputs()
        {
            // Clear input fields after save
            txtOrderDetailId.Text = string.Empty;
            txtOrderId.Text = string.Empty;
            txtProductId.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtFee.Text = string.Empty;
            txtDiscount.Text = string.Empty;
            txtOrderDetailNotes.Text = string.Empty;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the window on cancel
        }

        private void grdOrderDetails_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var selectedItem = grdOrderDetails.SelectedItem as DiamondShopSystem.DataAccess.Models.OrderDetail;
            if (selectedItem != null)
            {
                txtOrderDetailId.Text = selectedItem.OrderDetailId.ToString();
                txtOrderId.Text = selectedItem.OrderId.ToString();
                txtProductId.Text = selectedItem.ProductId.ToString();
                txtQuantity.Text = selectedItem.Quantity.ToString();
                txtAmount.Text = selectedItem.Amount.ToString();
                txtFee.Text = selectedItem.Fee.ToString();
                txtDiscount.Text = selectedItem.Discount.ToString();
                txtOrderDetailNotes.Text = selectedItem.OrderDetailNote;
            }
        }

        private void txtDiscount_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
        }
    }
}
