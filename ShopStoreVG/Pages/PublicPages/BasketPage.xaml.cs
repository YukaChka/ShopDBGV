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

namespace ShopStoreVG.Pages
{
    /// <summary>
    /// Логика взаимодействия для Basket.xaml
    /// </summary>
    public partial class Basket : Page
    {
     
            public Basket()
            {
                InitializeComponent();
                GetListProduct();
            }

            private void GetListProduct()
            {
                LvCartProduct.ItemsSource = ClassHelper.CartClass.products;
            }

        private void BtnGoToProduct_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/PublicPages/ListProductPage.xaml", UriKind.Relative));
        }

        private void BtnRemoveProduct_Click(object sender, RoutedEventArgs e)
        {

            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            Product selectedProduct = button.DataContext as Product;

            ClassHelper.CartClass.products.Remove(selectedProduct);

            GetRemoveCartProduct();
        }
    }
}
