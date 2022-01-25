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
using BeautySalon.DataBase;
using BeautySalon.Pages;

namespace BeautySalon.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditProduct.xaml
    /// </summary>
    public partial class AddEditProduct : Page
    {
        public AddEditProduct()
        {
            InitializeComponent();
            var filtItems = Transition.Context.Manufacturer.ToList();
            filtItems.Insert(0, new Manufacturer { Name = "Все элементы" });
            ManufacturerCombo.ItemsSource = filtItems;
            ManufacturerCombo.SelectedIndex = 0;
        }
        private void DataView()
        {
            var tempDataProduct = Transition.Context.Product.ToList();

            if (ManufacturerCombo.SelectedIndex > 0)
                tempDataProduct = tempDataProduct
                    .Where(p => p.ManufacturerID == (ManufacturerCombo.SelectedItem as Manufacturer).ID)
                    .ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ManufacturerCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataView();
        }
    }
}
