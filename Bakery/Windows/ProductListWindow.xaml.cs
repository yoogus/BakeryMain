using Bakery.ClassHelper;
using Bakery.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

using static Bakery.ClassHelper.EFClass;

namespace Bakery.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        public ProductListWindow()
        {
            InitializeComponent();
        }

        private void GetListProduct()
        {
            List<Product> products = new List<Product>();
            products = EFClass.ContextDB.Product.ToList();


            products = products.Where(i => i.Title.ToLower().Contains(tbxPoisk.Text.ToLower())).ToList();

            LvProduct.ItemsSource = products;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow addEditWindow = new AddEditWindow();  
            addEditWindow.ShowDialog();
        }

        private void tbxPoisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetListProduct();
        }
    }
}
