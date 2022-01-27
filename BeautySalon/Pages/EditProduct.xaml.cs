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
    /// Логика взаимодействия для EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Page
    {
        bool LogicRb = false;
        public EditProduct(Product product)
        {
            InitializeComponent();
            ManufacturerCombo.SelectedItem = (int)product.ManufacturerID - 1;
            ManufacturerCombo.SelectedValuePath = "ID";
            ManufacturerCombo.DisplayMemberPath = "Name";
            ManufacturerCombo.ItemsSource = Transition.Context.Manufacturer.ToList();

            ProductObj.ID = product.ID;
            TxtName.Text = product.Title;
            TxtCost.Text = Convert.ToString(product.Cost);
            TxtImage.Text = product.MainImagePath;

            if(product.IsActive != false)
            {
                RbActive.IsChecked = true;
                LogicRb = true;
            }
            else 
            {
                RbNotActive.IsChecked = true;
                LogicRb = false;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IEnumerable<Product> products = Transition.Context.Product.Where(p => p.ID == ProductObj.ID).AsEnumerable().
                    Select(p =>
                    {
                        p.Title = TxtName.Text;
                        p.Cost = Convert.ToDecimal(TxtCost.Text);
                        p.MainImagePath = TxtImage.Text;
                        if (string.IsNullOrWhiteSpace(TxtImage.Text))
                            p.MainImagePath = "";
                        else
                            p.MainImagePath = TxtImage.Text;
                        p.ManufacturerID = (int)ManufacturerCombo.SelectedValue;
                        p.IsActive = LogicRb;

                        return p;
                    });

                foreach (Product prod in products)
                    Transition.Context.Entry(prod).State = System.Data.Entity.EntityState.Modified;
                Transition.Context.SaveChanges();
                MessageBox.Show("Данные успешно изменены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message.ToString());
            }
        }
    }
}
