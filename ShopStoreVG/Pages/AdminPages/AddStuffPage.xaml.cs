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
    /// Логика взаимодействия для AddStuffPage.xaml
    /// </summary>
    public partial class AddStuffPage : Page
    {
        public AddStuffPage()
        {
            CmbRole.ItemsSource = EFClass.Context.EmpRole.ToList();
            CmbRole.DisplayMemberPath = "RoleName";
            CmbRole.SelectedIndex = 0;
            InitializeComponent();
        }

        public AddStuffPage(Employee employee)
        {
            InitializeComponent();
            CmbRole.ItemsSource = EFClass.Context.EmpRole.ToList();
            CmbRole.DisplayMemberPath = "RoleName";
            CmbRole.SelectedIndex = 0;

        }





        private void BtnAddStuff_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee();
        }
    }
}
