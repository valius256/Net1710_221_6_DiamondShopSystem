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
    public partial class wMainDiamond : Window
    {
        private readonly IMainDiamondBusiness _mainDiamondBusiness;
        public MainDiamond? MainDiamond { get; set; }

        public wMainDiamond()
        {
            InitializeComponent();
            _mainDiamondBusiness ??= new MainDiamondBusiness();
            LoadMainDiamonds();
        }

        private async void LoadMainDiamonds()
        {
            var result = await _mainDiamondBusiness.GetAllMainDiamonds();

            if (result.Status > 0 && result.Data != null)
            {
                grdMainDiamond.ItemsSource = result.Data as List<MainDiamond>;
            }
            else
            {
                grdMainDiamond.ItemsSource = new List<MainDiamond>();
            }
        }

        private async void grdMainDiamond_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int mainDiamondId = int.Parse(btn.CommandParameter.ToString());

            if (MessageBox.Show("Do you want to delete this item?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var result = await _mainDiamondBusiness.DeleteMainDiamond(mainDiamondId);
                MessageBox.Show(result.Message, "Delete");
                LoadMainDiamonds();
            }
        }

        private void grdMainDiamond_MouseDouble_Click(object sender, RoutedEventArgs e)
        {
            if (grdMainDiamond.SelectedItem != null)
            {
                var selectedMainDiamond = (MainDiamond)grdMainDiamond.SelectedItem;
                MainDiamond = selectedMainDiamond;
                grdMainDiamondForm.DataContext = MainDiamond;
            }
        }

        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = await _mainDiamondBusiness.GetByIdAsync(MainDiamond?.MainDiamondId ?? -1);

                if (item.Data == null)
                {
                    var mainDiamond = new MainDiamond()
                    {
                        Name = txtMainDiamondName.Text,
                        Description = txtDescription.Text,
                        Price = decimal.Parse(txtPrice.Text),
                        Certificate = txtCertificate.Text,
                        Origin = int.Parse(txtOrigin.Text),
                        Size = int.Parse(txtSize.Text),
                        CaratWeight = decimal.Parse(txtCaratWeight.Text),
                        Color = int.Parse(txtColor.Text),
                        Clarity = int.Parse(txtClarity.Text),
                        Cut = int.Parse(txtCut.Text),
                        CreateAt = DateTime.Now,
                        UpdateAt = DateTime.Now
                    };

                    var result = await _mainDiamondBusiness.CreateMainDiamond(mainDiamond);
                    MessageBox.Show(result.Message, "Save");
                }
                else
                {
                    var mainDiamond = item.Data as MainDiamond;
                    mainDiamond!.Name = txtMainDiamondName.Text;
                    mainDiamond!.Description = txtDescription.Text;
                    mainDiamond!.Price = decimal.Parse(txtPrice.Text);
                    mainDiamond!.Certificate = txtCertificate.Text;
                    mainDiamond!.Origin = int.Parse(txtOrigin.Text);
                    mainDiamond!.Size = int.Parse(txtSize.Text);
                    mainDiamond!.CaratWeight = decimal.Parse(txtCaratWeight.Text);
                    mainDiamond!.Color = int.Parse(txtColor.Text);
                    mainDiamond!.Clarity = int.Parse(txtClarity.Text);
                    mainDiamond!.Cut = int.Parse(txtCut.Text);
                    mainDiamond!.UpdateAt = DateTime.Now;

                    var result = await _mainDiamondBusiness.UpdateMainDiamond(mainDiamond);
                    MessageBox.Show(result.Message, "Update");
                }

                ClearFields();
                LoadMainDiamonds();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtMainDiamondName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtCertificate.Text = string.Empty;
            txtOrigin.Text = string.Empty;
            txtSize.Text = string.Empty;
            txtCaratWeight.Text = string.Empty;
            txtColor.Text = string.Empty;
            txtClarity.Text = string.Empty;
            txtCut.Text = string.Empty;
        }
    }
}
