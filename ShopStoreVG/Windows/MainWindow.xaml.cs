using ShopStoreVG.Pages;
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


namespace ShopStoreVG
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ClassHelper.NavigateClass.frame = MainFrame;
            MainFrame.Navigate(new RegistrationPage());
        }

        private void PersBasket_Click(object sender, RoutedEventArgs e)
        {
            ClassHelper.NavigateClass.frame = MainFrame;
            MainFrame.Navigate(new Basket());
        }
    }
}
