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

namespace ShopStoreVG.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для StaffPage.xaml
    /// </summary>
    public partial class StaffPage : Page
    {
        Entities e = new Entities();
        public StaffPage()
        {
            InitializeComponent();

            GetListProduct();
        }
        private void GetListProduct()
        {
            var query =

                from U in e.Employee join R in e.EmpRole on U.IDRole equals R.IDRole
                where U.IDRole == 1 || U.IDRole == 2
                orderby U.LastName
                select new {LastName = U.LastName, U.FirstName, U.Patronymic, R.RoleName };


            List<Employee> staff = new List<Employee>();
            staff = EFClass.Context.Employee.ToList();

            LvStaff.ItemsSource = staff;
        }

        private void BtnAddStaff_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/AdminPages/AddStuffPage.xaml", UriKind.Relative));
        }
    }
}
