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
using Microsoft.Win32;

namespace ShopStoreVG.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Page
    {
        private string pathImageProduct = null;

        public AddProduct()
        {
            InitializeComponent();

            CmbCategory.ItemsSource = EFClass.Context.Tag.ToList();
            CmbCategory.DisplayMemberPath = "Name";
            CmbCategory.SelectedIndex = 0;
        }

        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImgProduct.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                pathImageProduct = openFileDialog.FileName;
            }
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            // валидация 

            // добавление
            Product product = new Product();
            product.ProductName = TbName.Text;
            product.Price = Convert.ToDecimal(TbPrice.Text);
            product.IDTag = (CmbCategory.SelectedItem as Tag).IDTag;
            if (pathImageProduct != null)
            {
                product.Photo = File.ReadAllBytes(pathImageProduct);
            }


            EFClass.Context.Product.Add(product);
            EFClass.Context.SaveChanges();

            MessageBox.Show("Товар добавлен");


        }
    }
}
