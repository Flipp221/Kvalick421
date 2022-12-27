using Kvalick421.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kvalick421
{
    /// <summary>
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        private Users _users = new Users();
        public AddClientWindow(Users selected)
        {
            InitializeComponent();
            if (selected != null)
                _users = selected;

            DataContext = _users;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(tbName.Text))
                errors.AppendLine("укажите Имя");
            if (string.IsNullOrWhiteSpace(tbSurname.Text))
                errors.AppendLine("укажите Фамилию");
            if (string.IsNullOrWhiteSpace(tbPatronymic.Text))
                errors.AppendLine("укажите Отчество");
            if (string.IsNullOrWhiteSpace(tbPhone.Text))
                errors.AppendLine("укажите Телефон");
            if (string.IsNullOrWhiteSpace(tbRoll.Text))
                errors.AppendLine("укажите Роль");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_users.id_users == 0)
            {
                prog21Entities.GetContext().Users.Add(_users);
            }
            try
            {
                prog21Entities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
