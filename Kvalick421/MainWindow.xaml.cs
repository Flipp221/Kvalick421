using Kvalick421.DataBase;
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

namespace Kvalick421
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static prog21Entities db = new prog21Entities();
        public static Number_Users vhodUser;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text == "" || tbPassword.Password == "")
            {
                MessageBox.Show("Enter your username or password");
            }
            else
            {
                foreach (var number_User in MainWindow.db.Number_Users)
                {
                    if (number_User.Login == tbLogin.Text.Trim())
                    {
                        if (number_User.Password == tbPassword.Password.Trim() && number_User.id_users == 2)
                        {
                            MessageBox.Show($"Привет Владелец - {number_User.Users.Name}");
                            MainWindow.vhodUser = number_User;

                        }
                        if (number_User.Password == tbPassword.Password.Trim() && number_User.id_users == 1)
                        {
                            MessageBox.Show($"Привет Администратор - {number_User.Users.Name}");
                            MainWindow.vhodUser = number_User;

                        }
                        if (number_User.Password == tbPassword.Password.Trim() && number_User.id_users == 3)
                        {
                            MessageBox.Show($"Привет Работник мастерской - {number_User.Users.Name}");
                            MainWindow.vhodUser = number_User;

                        }
                        if (number_User.Password == tbPassword.Password.Trim() && number_User.id_users == 4)
                        {
                            MessageBox.Show($"Привет Работник склада - {number_User.Users.Name}");
                            MainWindow.vhodUser = number_User;
                        }

                    }
                }
                if (MainWindow.vhodUser == null)
                {
                    MessageBox.Show("Неправильный логин или пароль!");
                }
                else
                {
                    Magazin wd = new Magazin();
                    wd.Show();
                    this.Close();
                }
            }
        }
    }
}
