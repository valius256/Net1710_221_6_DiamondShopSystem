using DiamondShopSystem.Business.Business.Implement;
using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.DataAccess.Models;
using Microsoft.IdentityModel.Tokens;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DiamondShopSystem.Wpf.UI
{
    /// <summary>
    /// Interaction logic for wProduct.xaml
    /// </summary>
    public partial class wProduct : Window
    {
        private readonly IProductBusiness _productBusiness;
        private readonly IMainDiamondBusiness _mainDiamondBusiness;
        private readonly ISideStoneBusiness _sideStoneBusiness;
        private readonly IDiamondSettingBusiness _diamondSettingBusiness;
        public Product? Product { get; set; }
        //public List<Product> Products { get; set; }
        public wProduct()
        {
            InitializeComponent();
            ButtonCancel.Visibility = Visibility.Hidden;
            _productBusiness ??= new ProductBusiness();
            _mainDiamondBusiness ??= new MainDiamondBusiness();
            _sideStoneBusiness ??= new SideStoneBusiness();
            _diamondSettingBusiness ??= new DiamondSettingBusiness();
            LoadProducts();
            LoadComboBox();
        }
        private async void LoadComboBox()
        {
            cmbDiamondSetting.ItemsSource = (await _diamondSettingBusiness.GetAllDiamondSettings()).Data as List<DiamondSetting>;
            cmbSideStone.ItemsSource = (await _sideStoneBusiness.GetAllSideStones()).Data as List<SideStone>;
            cmbMainDiamond.ItemsSource = (await _mainDiamondBusiness.GetAllMainDiamonds()).Data as List<MainDiamond>;
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


        public async void grdProduct_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                Product product = button.DataContext as Product;
                if (product != null)
                {
                    if (MessageBox.Show("Do you want to delete this item Id " + product.ProductId + "?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        var result = await _productBusiness.DeleteProduct(product.ProductId);
                        MessageBox.Show($"{result.Message}", "Delete");
                        this.LoadProducts();
                    }
                }
                
            }

            //MessageBox.Show(currencyCode);         
        }

        public void grdProduct_MouseDouble_Click(object sender, RoutedEventArgs e) 
        {
            if (grdProduct.SelectedItem != null)
            {
                if (grdProduct.SelectedItem != null)
                {
                    var selectedProduct = (Product)grdProduct.SelectedItem;
                    Product = selectedProduct;
                    cmbMainDiamond.SelectedValue = Product.MainDiamondId;
                    cmbDiamondSetting.SelectedValue = Product.DiamondSettingId;
                    cmbSideStone.SelectedValue = Product.SideStoneId;

                    ButtonSave.Content = "Save";
                    ButtonCancel.Visibility = Visibility.Visible;
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
                        Price = decimal.Parse(txtPrice.Text),
                        Warranty = txtWarranty.Text,
                        Terms = txtTerm.Text,
                        MainDiamondId = ((MainDiamond)cmbMainDiamond.SelectedItem).MainDiamondId,
                        SideStoneId = ((SideStone)cmbSideStone.SelectedItem).SideStoneId,
                        SideStoneAmount = int.Parse(txtSsAmount.Text),
                        DiamondSettingId = ((DiamondSetting)cmbDiamondSetting.SelectedItem).DiamondSettingId,
                        StartDate = dpkStartDate.SelectedDate ?? DateTime.Now,
                        EndDate = dpkEndDate.SelectedDate ?? DateTime.Now,
                        Status = txtStatus.Text,
                    };

                    var result = await _productBusiness.CreateProduct(product);
                    MessageBox.Show(result.Message, "Create");
                    ClearAllInputs();
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
                    product!.Status = txtStatus.Text;
                    product!.MainDiamondId = (int)cmbMainDiamond.SelectedValue;
                    product!.SideStoneId = (int)cmbSideStone.SelectedValue;
                    product!.DiamondSettingId = (int)cmbDiamondSetting.SelectedValue;
                    product!.StartDate = dpkStartDate.SelectedDate ?? DateTime.Now;
                    product!.EndDate = dpkEndDate.SelectedDate ?? DateTime.Now;
                    product!.SideStoneAmount = int.Parse(txtSsAmount.Text);

                    var result = await _productBusiness.UpdateProduct(product);
                    MessageBox.Show(result.Message, "Update");
                }

                //
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }

        }
        private void ClearAllInputs()
        {
            txtPrice.Text = "";
            txtProductDescription.Text = "";
            txtProductName.Text = "";
            txtTerm.Text = "";
            txtWarranty.Text = "";
            txtSsAmount.Text = "";
            txtStatus.Text = "";
            cmbDiamondSetting.SelectedItem = null;
            cmbMainDiamond.SelectedItem = null;
            cmbSideStone.SelectedItem = null;
            dpkEndDate.Text = "";
            dpkStartDate.Text = "";
        }
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Product = null;
            ClearAllInputs();
            LoadComboBox();
            ButtonSave.Content = "Create";
            ButtonCancel.Visibility = Visibility.Hidden;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
