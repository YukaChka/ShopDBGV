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
        private bool isEdit = false;
        Product editProduct;

        public AddProduct()
        {

            InitializeComponent();
            CmbCategory.ItemsSource = EFClass.Context.Tag.ToList();
            CmbCategory.DisplayMemberPath = "TagName";
            CmbCategory.SelectedIndex = 0;

            CmbGender.ItemsSource = EFClass.Context.GenderProduct.ToList();
            CmbGender.DisplayMemberPath = "GenderName";
            CmbGender.SelectedIndex = 0;
        }

        public AddProduct(Product product)
        {
            InitializeComponent();

            // Заполнение комбобокса

            CmbCategory.ItemsSource = EFClass.Context.Tag.ToList();
            CmbCategory.DisplayMemberPath = "TagName";
            CmbCategory.SelectedIndex = 0;


            CmbGender.ItemsSource = EFClass.Context.GenderProduct.ToList();
            CmbGender.DisplayMemberPath = "GenderName";
            CmbGender.SelectedIndex = 0;

            // заполнение полей значениями 
            TbName.Text = product.ProductName;
            TbPrice.Text = product.Price.ToString();
            CmbCategory.SelectedItem = EFClass.Context.Tag.ToList().Where(i => i.IDTag == product.IDTag).FirstOrDefault();
            CmbGender.SelectedItem = EFClass.Context.GenderProduct.ToList().Where(i => i.IDGender == product.IDGender).FirstOrDefault();

            // вывод фото

            if (product.Photo != null)
            {
                using (MemoryStream ms = new MemoryStream(product.Photo))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bitmapImage.StreamSource = ms;
                    bitmapImage.EndInit();
                    ImgProduct.Source = bitmapImage;
                }
            }


            // Изменение заголовка и кнопки 

            TblockTitle.Text = "Изменение товара";
            BtnAddProduct.Content = "Изменить";

            // флаг на изменение
            isEdit = true;

            // выводим из контекста класса полученный продукт
            editProduct = product;
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

            if (isEdit)
            {
                // редактирование

                editProduct.ProductName = TbName.Text;
                editProduct.Price = Convert.ToDecimal(TbPrice.Text);
                editProduct.IDTag = (CmbCategory.SelectedItem as Tag).IDTag;
                if (pathImageProduct != null)
                {
                    editProduct.Photo = File.ReadAllBytes(pathImageProduct);
                }

                EFClass.Context.SaveChanges();

                MessageBox.Show("Товар успешно изменен");


            }
            else
            {
                // добавление
                Product product = new Product();
                product.ProductName = TbName.Text;
                product.Price = Convert.ToDecimal(TbPrice.Text);
                product.IDTag = (CmbCategory.SelectedItem as Tag).IDTag;
                product.IDGender = (CmbGender.SelectedItem as GenderProduct).IDGender;
                if (pathImageProduct != null)
                {
                    product.Photo = File.ReadAllBytes(pathImageProduct);
                }

                EFClass.Context.Product.Add(product);
                EFClass.Context.SaveChanges();

                MessageBox.Show("Товар добавлен");
            }

            NavigationService.Navigate(new Uri("/Pages/PublicPages/ListProductPage.xaml", UriKind.Relative));

        }


        private void BtnAddProductNazad_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/PublicPages/ListProductPage.xaml", UriKind.Relative));
        }

    }
}