using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using ShopStoreVG.ClassHelper;
using ShopStoreVG.DB;
using System.IO;
using ShopStoreVG.Pages.AdminPages;

namespace ShopStoreVG.Pages.PublicPages
{
    /// <summary>
    /// Логика взаимодействия для ListProductPage.xaml
    /// </summary>
    public partial class ListProductPage : Page
    {
        //private string pathImageProduct = null;

        public ListProductPage()
        {
            InitializeComponent();

            GetListProduct();
        }   

        private void GetListProduct()
        {
            List<Product> products = new List<Product>();
            products = EFClass.Context.Product.ToList();

            LvProduct.ItemsSource = products;
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/AdminPages/AddProduct.xaml", UriKind.Relative));


        }
         
        private void BtnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            Product selectedProduct = button.DataContext as Product;

            NavigationService.Navigate(new Uri("/Pages/AdminPages/AddProduct.xaml", UriKind.Relative));

            GetListProduct();
        }
    }
}