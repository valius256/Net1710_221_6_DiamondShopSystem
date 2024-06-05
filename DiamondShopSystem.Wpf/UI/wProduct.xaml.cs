using DiamondShopSystem.Business.Business.Implement;
using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Data.Models;
using System.Windows;

namespace DiamondShopSystem.Wpf.UI
{
    /// <summary>
    /// Interaction logic for wProduct.xaml
    /// </summary>
    public partial class wProduct : Window
    {
        private readonly IProductBusiness _productBusiness;
        public Product Product { get; set; }
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


        public void grdCurrency_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        public void grdCurrency_MouseDouble_Click(object sender, RoutedEventArgs e) 
        {
            if (grdProduct.SelectedItem != null)
            {
                // Assuming that your GroupBox is named 'groupBoxProductForm'
                // and the DataContext of the GroupBox binds to a single Product object.
                var selectedProduct = (Product)grdProduct.SelectedItem;
                this.DataContext = selectedProduct;
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
