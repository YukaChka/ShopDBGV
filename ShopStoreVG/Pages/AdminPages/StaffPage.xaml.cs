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
        Entities ent = new Entities();
        public StaffPage()
        {
            InitializeComponent();
            GetListProduct();

        }
        private void GetListProduct()
        {
            var q = from u in ent.User join emp in ent.Employee on u.IDUser equals emp.IDUser join r in ent.Role on u.IDRole equals r.IDRole
                   select new { LastName = u.LastName, FirstName = u.Firstname, Patronumic = u.Patronumic, Phone = u.Phone, Email = u.Email, Role = r.NameRole, Salary = emp.Salary };



            //List<Employee> staff = new List<Employee>();

            List x = 



            LvStaff.ItemsSource = q;
        }

        private void BtnAddStaff_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/AdminPages/AddStuffPage.xaml", UriKind.Relative));
        }
    }
}
