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
    /// Логика взаимодействия для MaterilaWindow.xaml
    /// </summary>
    public partial class MaterilaWindow : Window
    {
        public MaterilaWindow()
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Magazin magazin = new Magazin();
            magazin.Show();
            Close();
        }
    }
}
