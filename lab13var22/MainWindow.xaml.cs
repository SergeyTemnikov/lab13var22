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

namespace lab13var22
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        CountriesEntities db = new CountriesEntities();

        public MainWindow()
        {
            InitializeComponent();

            dgCities.ItemsSource = db.City.ToList();
        }

        private void btnAddCity_Click(object sender, RoutedEventArgs e)
        {
            WindowAddCity window = new WindowAddCity(db);
            window.ShowDialog();
            dgCities.ItemsSource = null;
            dgCities.ItemsSource = db.City.ToList();
        }

        private void btnCityCount_Click(object sender, RoutedEventArgs e)
        {
            string info = "";
            foreach(var c in db.Country.ToList())
            {
                var count = db.City.Where(x => x.Country.CountryName ==  c.CountryName).Count();
                info += $"{c.CountryName}: {count}\n";
            }
            MessageBox.Show(info);
        }
    }
}
