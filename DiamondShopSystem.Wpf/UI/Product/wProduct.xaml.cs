using DiamondShopSystem.Business.Business.Implement;
using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.DataAccess.Models;
using Microsoft.IdentityModel.Tokens;
using System.Windows;
using System.Windows.Controls;

namespace DiamondShopSystem.Wpf.UI
{
    /// <summary>
    /// Interaction logic for wProduct.xaml
    /// </summary>
    public partial class wProduct : Window
    {
        private readonly IProductBusiness _productBusiness;
        public Product? Product { get; set; }
        //public List<Product> Products { get; set; }
        public wProduct()
        {
            InitializeComponent();
            _productBusiness ??= new ProductBusiness();
            LoadProducts();
        }

        private async void LoadProducts()
        {
            var result = await _productBusiness.GetAllProducts();

            if (result.Status > 0 && result.Data != null)
            {
                grdProduct.ItemsSource = result.Data as List<Product>;
            }
            else
            {
                grdProduct.ItemsSource = new List<Product>();
            }
        }


        public async Task grdProduct_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            int productId = int.Parse(btn.CommandParameter.ToString());

            //MessageBox.Show(currencyCode);

            if (MessageBox.Show("Do you want to delete this item?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var result = await _productBusiness.DeleteProduct(productId);
                MessageBox.Show($"{result.Message}", "Delete");
                this.LoadProducts();
            }           
        }

        public void grdProduct_MouseDouble_Click(object sender, RoutedEventArgs e) 
        {
            if (grdProduct.SelectedItem != null)
            {
                if (grdProduct.SelectedItem != null)
                {
                    var selectedProduct = (Product)grdProduct.SelectedItem;
                    Product = selectedProduct;

                    // Update the DataContext of the GroupBox
                    grdProductForm.DataContext = Product;
                }
            }
        }

        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = await _productBusiness.GetByIdAsync(Product?.ProductId ?? -1);

                if (item.Data == null)
                {
                    var product = new Product()
                    {
                        ProductName = txtProductName.Text,
                        Description = txtProductDescription.Text,
                        Price = int.Parse(txtPrice.Text),
                        Warranty = txtWarranty.Text,
                        Terms = txtTerm.Text,
                        MainDiamondId = 1,
                        SideStoneId = 1,
                        SideStoneAmount = 1,
                        DiamondSettingId = 1,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now,
                        Status = "Available",
                    };

                    var result = await _productBusiness.CreateProduct(product);
                    MessageBox.Show(result.Message, "Save");
                }
                else
                {
                    var product = item.Data as Product;
                    //currency.CurrencyCode = txtCurrencyCode.Text;
                    product!.ProductName = txtProductName.Text;
                    product!.Description = txtProductDescription.Text;
                    product!.Price = decimal.Parse(txtPrice.Text);
                    product!.Warranty = txtWarranty.Text;
                    product!.Terms = txtTerm.Text;
                    product!.Status = Product?.Status;
                    product!.MainDiamondId = Product?.MainDiamondId ?? 1;
                    product!.SideStoneId = Product?.SideStoneId ?? 1;
                    product!.DiamondSettingId = Product?.DiamondSettingId ?? 1;

                    var result = await _productBusiness.UpdateProduct(product);
                    MessageBox.Show(result.Message, "Update");
                }

                txtProductName.Text = string.Empty;
                txtProductDescription.Text = string.Empty;
                txtPrice.Text = string.Empty;
                txtWarranty.Text = string.Empty;
                txtTerm.Text = string.Empty;
                this.LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }

        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Product = null;
        }
    }
}
