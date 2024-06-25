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
    public partial class wDiamondSetting : Window
    {
        private readonly IDiamondSettingBusiness _diamondSettingBusiness;
        public DiamondSetting? DiamondSetting { get; set; }

        public wDiamondSetting()
        {
            InitializeComponent();
            _diamondSettingBusiness ??= new DiamondSettingBusiness();
            LoadDiamondSettings();
        }

        private async void LoadDiamondSettings()
        {
            var result = await _diamondSettingBusiness.GetAllDiamondSettings();

            if (result.Status > 0 && result.Data != null)
            {
                grdDiamondSetting.ItemsSource = result.Data as List<DiamondSetting>;
            }
            else
            {
                grdDiamondSetting.ItemsSource = new List<DiamondSetting>();
            }
        }

        private async void grdDiamondSetting_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int diamondSettingId = int.Parse(btn.CommandParameter.ToString());

            if (MessageBox.Show("Do you want to delete this item?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var result = await _diamondSettingBusiness.DeleteDiamondSetting(diamondSettingId);
                MessageBox.Show(result.Message, "Delete");
                LoadDiamondSettings();
            }
        }

        private void grdDiamondSetting_MouseDouble_Click(object sender, RoutedEventArgs e)
        {
            if (grdDiamondSetting.SelectedItem != null)
            {
                var selectedDiamondSetting = (DiamondSetting)grdDiamondSetting.SelectedItem;
                DiamondSetting = selectedDiamondSetting;
                grdDiamondSettingForm.DataContext = DiamondSetting;
            }
        }

        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = await _diamondSettingBusiness.GetByIdAsync(DiamondSetting?.DiamondSettingId ?? -1);

                if (item.Data == null)
                {
                    var diamondSetting = new DiamondSetting()
                    {
                        Name = txtDiamondSettingName.Text,
                        Description = txtDescription.Text,
                        Price = decimal.Parse(txtPrice.Text),
                        Image = txtImage.Text,
                        DiamondSettingMaterial = txtMaterial.Text,
                        DiamondSettingWeight = string.IsNullOrEmpty(txtWeight.Text) ? null : (decimal?)decimal.Parse(txtWeight.Text),
                        DiamondSettingSize = txtSize.Text,
                        CreateAt = DateTime.Now,
                        UpdateAt = DateTime.Now,
                    };

                    var result = await _diamondSettingBusiness.CreateDiamondSetting(diamondSetting);
                    MessageBox.Show(result.Message, "Save");
                }
                else
                {
                    var diamondSetting = item.Data as DiamondSetting;
                    diamondSetting!.Name = txtDiamondSettingName.Text;
                    diamondSetting!.Description = txtDescription.Text;
                    diamondSetting!.Price = decimal.Parse(txtPrice.Text);
                    diamondSetting!.Image = txtImage.Text;
                    diamondSetting!.DiamondSettingMaterial = txtMaterial.Text;
                    diamondSetting!.DiamondSettingWeight = string.IsNullOrEmpty(txtWeight.Text) ? null : (decimal?)decimal.Parse(txtWeight.Text);
                    diamondSetting!.DiamondSettingSize = txtSize.Text;
                    diamondSetting!.UpdateAt = DateTime.Now;

                    var result = await _diamondSettingBusiness.UpdateDiamondSetting(diamondSetting);
                    MessageBox.Show(result.Message, "Update");
                }

                ClearFields();
                LoadDiamondSettings();
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
            txtDiamondSettingName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtImage.Text = string.Empty;
            txtMaterial.Text = string.Empty;
            txtWeight.Text = string.Empty;
            txtSize.Text = string.Empty;
        }
    }
}
