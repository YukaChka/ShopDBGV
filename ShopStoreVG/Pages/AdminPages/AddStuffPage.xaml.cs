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

            InitializeComponent();


            CmbRole.ItemsSource = EFClass.Context.EmpRole.ToList();
            CmbRole.DisplayMemberPath = "RoleName";
            CmbRole.SelectedIndex = 0;
        }

        public AddStuffPage(Employee user)
        {
            InitializeComponent();


            CmbRole.SelectedItem = EFClass.Context.User.ToList().Where(i => i.IDRole == user.IDUser).FirstOrDefault();

        }





        private void BtnAddStuff_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee();
            //employee.Salary = 
            User user = new User();
            user.Phone = TbPhone.Text;
            user.Email = TbMail.Text;
            user.Login = TbLogin.Text;
            user.Password = TbPsw.Text;
            user.IDRole = (CmbRole.SelectedItem as EmpRole).IDRole;
            employee.LastName = TbLName.Text;
            employee.FirstName = TbFName.Text;
            employee.Patronymic = TbPatronymic.Text;

            EFClass.Context.Employee.Add(employee);
            EFClass.Context.User.Add(user);
            EFClass.Context.SaveChanges();

            NavigationService.Navigate(new Uri("/Pages/AdminPages/StaffPage.xaml", UriKind.Relative));
        }
    }
}
