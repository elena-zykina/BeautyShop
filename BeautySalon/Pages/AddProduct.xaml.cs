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

namespace BeautySalon.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Page
    {
        bool LogicRb = false;
        public AddProduct()
        {
            InitializeComponent();
            var filtItems = Transition.Context.Manufacturer.ToList();
            filtItems.Insert(0, new Manufacturer { Name = "Все элементы" });
            ManufacturerCombo.ItemsSource = filtItems;
            ManufacturerCombo.SelectedIndex = 0;
            if (RbActive.IsChecked != false)
                LogicRb = true;
            else
                LogicRb = false;
            if (RbNotActive.IsChecked != false)
                LogicRb = false;
            else
                LogicRb = true;
        }

        private void DataView()
        {
            var tempDataProduct = Transition.Context.Product.ToList();

            if (ManufacturerCombo.SelectedIndex > 0)
                tempDataProduct = tempDataProduct
                    .Where(p => p.ManufacturerID == (ManufacturerCombo.SelectedItem as Manufacturer).ID)
                    .ToList();
        }

        private void ManufacturerCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataView();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = new Product()
                {
                    Title = TxtName.Text,
                    Cost = Convert.ToDecimal(TxtCost.Text),
                    MainImagePath = TxtImage.Text,
                    Manufacturer = ManufacturerCombo.SelectedItem as Manufacturer,
                    IsActive = LogicRb,    
                };
                Transition.Context.Product.Add(product);
                Transition.Context.SaveChanges();
                MessageBox.Show("Данные успешно добавлены.", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message.ToString());
            }
            Transition.MainFrame.GoBack();
        }
    }
}
