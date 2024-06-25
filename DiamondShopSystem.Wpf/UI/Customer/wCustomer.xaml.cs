using DiamondShopSystem.Business.Business.Implement;
using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DiamondShopSystem.Wpf.UI
{
    /// <summary>
    /// Interaction logic for wCustomer.xaml
    /// </summary>
    public partial class wCustomer : Window
    {
        private readonly ICustomerBusiness _customerBusiness;
        public Customer? Customer { get; set; }

        public wCustomer()
        {
            InitializeComponent();
            _customerBusiness ??= new CustomerBusiness();
            LoadCustomers();
        }

        private async void LoadCustomers()
        {
            var result = await _customerBusiness.GetAllCustomerAsync();

            if (result.Status > 0 && result.Data != null)
            {
                grdCustomer.ItemsSource = result.Data as List<Customer>;
            }
            else
            {
                grdCustomer.ItemsSource = new List<Customer>();
            }
        }

        public async Task grdCustomer_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int customerId = int.Parse(btn.CommandParameter.ToString());

            if (MessageBox.Show("Do you want to delete this item?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var result = await _customerBusiness.DeleteCustomerAsync(customerId);
                MessageBox.Show($"{result.Message}", "Delete");
                LoadCustomers();
            }
        }

        public void grdCustomer_MouseDouble_Click(object sender, RoutedEventArgs e)
        {
            if (grdCustomer.SelectedItem != null)
            {
                var selectedCustomer = (Customer)grdCustomer.SelectedItem;
                Customer = selectedCustomer;
                grdCustomerForm.DataContext = Customer;
            }
        }

        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = await _customerBusiness.GetCustomerByIdAsync(Customer?.CustomerId ?? -1);

                if (item.Data == null)
                {
                    var customer = new Customer()
                    {
                        Name = txtCustomerName.Text,
                        Email = txtEmail.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        Address = txtAddress.Text,
                        CompanyName = txtCompanyName.Text,
                        Gender = int.Parse(txtGender.Text),
                        Birthday = txtBirthday.Text,
                        CreateAt = DateTime.Now,
                        UpdateAt = DateTime.Now,
                    };

                    var result = await _customerBusiness.CreateCustomerAsync(customer);
                    MessageBox.Show(result.Message, "Save");
                }
                else
                {
                    var customer = item.Data as Customer;
                    customer!.Name = txtCustomerName.Text;
                    customer!.Email = txtEmail.Text;
                    customer!.PhoneNumber = txtPhoneNumber.Text;
                    customer!.Address = txtAddress.Text;
                    customer!.CompanyName = txtCompanyName.Text;
                    customer!.Gender = int.Parse(txtGender.Text);
                    customer!.Birthday = txtBirthday.Text;
                    customer!.UpdateAt = DateTime.Now;

                    var result = await _customerBusiness.UpdateCustomerAsync(customer);
                    MessageBox.Show(result.Message, "Update");
                }

                txtCustomerName.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtPhoneNumber.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtCompanyName.Text = string.Empty;
                txtGender.Text = string.Empty;
                txtBirthday.Text = string.Empty;
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Customer = null;
        }
    }
}
