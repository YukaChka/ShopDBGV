﻿using System;
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
using System.Text.RegularExpressions;

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
            CmbGender.ItemsSource = EFClass.Context.Gender.ToList();
            CmbGender.SelectedIndex = 0;
            CmbGender.DisplayMemberPath = "GenderName";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/PublicPages/AuthorizationPage.xaml", UriKind.Relative));
        }


        //валидация
        private void RegBtn(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RegLogin.Text))
            {
                MessageBox.Show("Логин не может быть пустым или состоять из пробелов");
                return;

            }



            if (string.IsNullOrWhiteSpace(RegMail.Text))
            {
                MessageBox.Show("Почта должна быть указана");
                return;
            }



            if (string.IsNullOrWhiteSpace(PegPsw.Password))
            {
                MessageBox.Show("Поле Пароль не может быть пустым");
                return;
            }



            if (string.IsNullOrWhiteSpace(RegLName.Text))
            {
                MessageBox.Show("Поле Фамилия не может быть пустым или состоять из пробелов");
                return;
            }
            



            if (string.IsNullOrWhiteSpace(RegPhone.Text))
            {
                 MessageBox.Show("Номер телефона должен быть указан");
                 return;
            }




            if (string.IsNullOrWhiteSpace(DpBirthday.Text))
            {
                 MessageBox.Show("Дата рождения должна быть указана");
                 return;
            }



            if (string.IsNullOrWhiteSpace(CmbGender.Text))
            {
                 MessageBox.Show("Пол должен быть указан");
                 return;
            }
           


            EFClass.Context.User.Add(new User()
            {
                Login = RegLogin.Text,
                Password = PegPsw.Password,
                Birhday = DpBirthday.SelectedDate.Value,
                IdGender = (CmbGender.SelectedItem as Gender).IdGender,
                LastName = RegLName.Text,
                FirstName = RegFName.Text,
                Email = RegMail.Text,
                Phone = RegPhone.Text,

            });
            EFClass.Context.Client.Add(new Client()
            {


            });
            EFClass.Context.SaveChanges();

            //перемещение по страницам
            NavigationService.Navigate(new Uri("/Pages/PublicPages/ListProductPage.xaml", UriKind.Relative));


        }
    }
    
}
