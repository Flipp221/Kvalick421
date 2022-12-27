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
    /// Логика взаимодействия для ZakupkaWindow.xaml
    /// </summary>
    public partial class ZakupkaWindow : Window
    {
        public ZakupkaWindow()
        {
            InitializeComponent();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                prog21Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(a => a.Reload());
                DGridKatalog.ItemsSource = prog21Entities.GetContext().Material.ToList();
            }
        }

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            var id = Convert.ToInt32(((Button)sender).CommandParameter);
            var a = MainWindow.db.Material.Where(x => x.id_material == id).FirstOrDefault();
            Stock material = new Stock();
            material.Name = a.Name;
            material.id_Purchase = id;
            material.Amount = new Random().Next(50, 100).ToString();
            prog21Entities.GetContext().Stock.Add(material);
            prog21Entities.GetContext().SaveChanges();
            MessageBox.Show("Успешно заказано!!");
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Magazin magazin = new Magazin();
            magazin.Show();
            Close();
        }

        private void btnRedresh_Click(object sender, RoutedEventArgs e)
        {
            DGridKatalog.ItemsSource = prog21Entities.GetContext().Material.ToList();
        }
    }
}
