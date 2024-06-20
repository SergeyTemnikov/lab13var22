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

namespace lab13var22
{
    /// <summary>
    /// Логика взаимодействия для WindowAddCity.xaml
    /// </summary>
    public partial class WindowAddCity : Window
    {

        CountriesEntities db;

        public WindowAddCity(CountriesEntities db)
        {
            InitializeComponent();
            this.db=db;

            cmbCountry.ItemsSource = db.Country.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            City city = new City()
            {
                Name = txbName.Text,
                Mayor = txbMayor.Text,
                Population = decimal.Parse(txbPopulation.Text),
                Country = cmbCountry.SelectedValue as Country
            };

            try
            {
                db.City.Add(city);
                db.SaveChanges();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Не удалось добавить город");
            }
        }

        private void btnCancrl_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
