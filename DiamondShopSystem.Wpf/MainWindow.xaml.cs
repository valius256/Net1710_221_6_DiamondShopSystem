﻿using DiamondShopSystem.Wpf.UI;
using Net1710_221_6_DiamondShopSystem.WpfApp.UI;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiamondShopSystem.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Open_wProduct_Click(object sender, RoutedEventArgs e)
        {
            var p = new wProduct();
            p.Owner = this;
            p.Show();
        }

            private async void Open_wOrder_Click(object sender, RoutedEventArgs e)
        {
            var order = new wOrder();
            order.Owner = this;
            order.Show();
        }
    }
}