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
using System.Windows.Shapes;

namespace Kvalick421
{
    /// <summary>
    /// Логика взаимодействия для PhoneList.xaml
    /// </summary>
    public partial class PhoneList : Window
    {
        public PhoneList()
        {
            InitializeComponent();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                prog21Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(a => a.Reload());
                DGridKatalog.ItemsSource = prog21Entities.GetContext().phone.ToList();
            }
        }

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Спасибо за покупку, ожидайте свой заказ!!!");
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Magazin magazin = new Magazin();
            magazin.Show();
            Close();
        }
    }
}
