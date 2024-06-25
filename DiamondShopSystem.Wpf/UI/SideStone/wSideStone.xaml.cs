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
    public partial class wSideStone : Window
    {
        private readonly ISideStoneBusiness _sideStoneBusiness;
        public SideStone? SideStone { get; set; }

        public wSideStone()
        {
            InitializeComponent();
            _sideStoneBusiness ??= new SideStoneBusiness();
            LoadSideStones();
        }

        private async void LoadSideStones()
        {
            var result = await _sideStoneBusiness.GetAllSideStones();

            if (result.Status > 0 && result.Data != null)
            {
                grdSideStone.ItemsSource = result.Data as List<SideStone>;
            }
            else
            {
                grdSideStone.ItemsSource = new List<SideStone>();
            }
        }

        private async void grdSideStone_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int sideStoneId = int.Parse(btn.CommandParameter.ToString());

            if (MessageBox.Show("Do you want to delete this item?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var result = await _sideStoneBusiness.DeleteSideStone(sideStoneId);
                MessageBox.Show(result.Message, "Delete");
                LoadSideStones();
            }
        }

        private void grdSideStone_MouseDouble_Click(object sender, RoutedEventArgs e)
        {
            if (grdSideStone.SelectedItem != null)
            {
                var selectedSideStone = (SideStone)grdSideStone.SelectedItem;
                SideStone = selectedSideStone;
                grdSideStoneForm.DataContext = SideStone;
            }
        }

        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = await _sideStoneBusiness.GetByIdAsync(SideStone?.SideStoneId ?? -1);

                if (item.Data == null)
                {
                    var sideStone = new SideStone()
                    {
                        Name = txtSideStoneName.Text,
                        Description = txtDescription.Text,
                        Price = decimal.Parse(txtPrice.Text),
                        SideStoneWeight = decimal.Parse(txtSideStoneWeight.Text),
                        SideStoneSize = txtSideStoneSize.Text,
                        SideStoneMaterial = txtSideStoneMaterial.Text,
                        SideStoneCategory = txtSideStoneCategory.Text,
                        CreateAt = DateTime.Now,
                        UpdateAt = DateTime.Now
                    };

                    var result = await _sideStoneBusiness.CreateSideStone(sideStone);
                    MessageBox.Show(result.Message, "Save");
                }
                else
                {
                    var sideStone = item.Data as SideStone;
                    sideStone!.Name = txtSideStoneName.Text;
                    sideStone!.Description = txtDescription.Text;
                    sideStone!.Price = decimal.Parse(txtPrice.Text);
                    sideStone!.SideStoneWeight = decimal.Parse(txtSideStoneWeight.Text);
                    sideStone!.SideStoneSize = txtSideStoneSize.Text;
                    sideStone!.SideStoneMaterial = txtSideStoneMaterial.Text;
                    sideStone!.SideStoneCategory = txtSideStoneCategory.Text;
                    sideStone!.UpdateAt = DateTime.Now;

                    var result = await _sideStoneBusiness.UpdateSideStone(sideStone);
                    MessageBox.Show(result.Message, "Update");
                }

                ClearFields();
                LoadSideStones();
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
            txtSideStoneName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtSideStoneWeight.Text = string.Empty;
            txtSideStoneSize.Text = string.Empty;
            txtSideStoneMaterial.Text = string.Empty;
            txtSideStoneCategory.Text = string.Empty;
        }
    }
}
