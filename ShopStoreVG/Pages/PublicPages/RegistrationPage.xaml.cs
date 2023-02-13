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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
            CmbGender.ItemsSource = ClassHelper.EFClass.Context.Gender.ToList();
            CmbGender.SelectedIndex = 0;
            CmbGender.DisplayMemberPath = "GenderName";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/PublicPages/Login.xaml", UriKind.Relative));
        }

        private void RegBtn(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RegLogin.Text))
            {
                MessageBox.Show("Логин не может быть пустым или состоять из пробелов");
                return;

            }

            EFClass.Context.User.Add(new User()
            {
                Login = RegLogin.Text,
                Password = PegPsw.Password,
                Birhday = DpBirthday.SelectedDate.Value,
                IdGender = (CmbGender.SelectedItem as Gender).IdGender,



            });
            //EFClass.Context.Client.Add(new Client()
            //{
            //    LastName = RegLName.Text,
            //    FirstName = RegFName.Text,
            //    Email= RegMail.Text,
            //    Phone = RegPhone.Text,
            //});
            EFClass.Context.SaveChanges();


            // оповещение об успехе
            MessageBox.Show("Ok");


        }
    }
    
}
