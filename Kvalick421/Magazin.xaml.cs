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
using System.Windows.Shapes;

namespace Kvalick421
{
    /// <summary>
    /// Логика взаимодействия для Magazin.xaml
    /// </summary>
    public partial class Magazin : Window
    {
        public Magazin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void btnPhone_Click(object sender, RoutedEventArgs e)
        {
            PhoneList phone = new PhoneList();
            phone.Show();
            Close();
        }

        private void btnClient_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClientWindow = new AddClientWindow(null);
            addClientWindow.Show();
            Close();
        }

        private void btnStock_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.vhodUser.id_users != 4)
            {
                MessageBox.Show("Вы не работник склада!");
            }
            else
            {
                StockWindow stockWindow = new StockWindow();
                stockWindow.Show();
                Close();
            }
        }

        private void btnMaterial_Click(object sender, RoutedEventArgs e)
        {
            MaterilaWindow materilaWindow = new MaterilaWindow();
            materilaWindow.Show();
            Close();
        }

        private void Buybtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.vhodUser.id_users != 4)
            {
                MessageBox.Show("Вы не работник склада!");
            }
            else
            {
                ZakupkaWindow zakupka = new ZakupkaWindow();
                zakupka.Show();
                Close();
            }
        }
    }
}
