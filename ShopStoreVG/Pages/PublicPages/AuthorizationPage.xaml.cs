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
using static ShopStoreVG.ClassHelper.EFClass;
namespace ShopStoreVG.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }
        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var userAuth = Context.User.ToList()
                .Where(i => i.Login == TbLogin.Text && i.Password == PbPassword.Password)
                .FirstOrDefault();



            if (userAuth != null)
            {
                // сохранияем данные входа
                ClassHelper.UserDataClass.User = userAuth;

                var emplAuth = Context.Employee.Where(i => i.IDUser == userAuth.IDUser).FirstOrDefault();
                var qwe = Context.User.Where(i => i.IDRole == userAuth.IDUser).FirstOrDefault();
                if (qwe.IDRole == 1)
                {
                    // если не пустой то Работник

                    // сохранияем данные входа

                    ClassHelper.UserDataClass.Employee = emplAuth;


                            // переход на страницу директора
                            NavigationService.Navigate(new Uri("/Pages/AdminPages/AdminPage.xaml", UriKind.Relative));



                }
                else
                {
                    // Client

                    // сохраняем клиента
                    ClassHelper.UserDataClass.User = userAuth;
                    NavigationService.Navigate(new Uri("/Pages/PublicPages/ListProductPage.xaml", UriKind.Relative));

                }


            }
            else
            {
                MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
