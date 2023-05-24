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
using Bakery.Windows;

namespace Bakery.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {

        List<string> strings = new List<string>() 
        {
            "По умолчанию",
            "По возрастанию",
            "По убыванию",
            "По цене",
            "В наличии"

        };

        public ProductListWindow()
        {
            InitializeComponent();

            CmdSort.ItemsSource = strings;
            CmdSort.SelectedIndex = 0;

            GetListProduct();
        }

        private void GetListProduct()
        {
            List<Product> products = new List<Product>();
            products = EFClass.ContextDB.Product.ToList();

            var StartIndex = CmdSort.SelectedIndex;

            //Поиск

            products = products.Where(i => i.Title.ToLower().Contains(tbxPoisk.Text.ToLower())).ToList();

            //Сортировка

            switch (StartIndex)
            {
                case 0:
                    products = products.OrderBy(i => i.ID).ToList();
                    break;
                case 1:
                    products = products.OrderBy(i => i.Title.ToLower()).ToList();
                    break;
                case 2:
                    products = products.OrderByDescending(i => i.Title.ToLower()).ToList();
                    break;
                case 3:
                    products = products.OrderBy(i => i.Cost).ToList();
                    break;
                case 4:
                    products = products.OrderBy(i => i.Quantity).ToList();
                    break;

                default:
                    break;
            }

            LvProduct.ItemsSource = products;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            var product = button.DataContext as Product;

            AddEditWindow editProductWindow = new AddEditWindow(product);
            editProductWindow.ShowDialog();

            GetListProduct();
        }

        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow addEditWindow = new AddEditWindow();
            addEditWindow.ShowDialog();
        }

        private void tbxPoisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetListProduct();
        }

        private void CmdSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetListProduct();
        }

        private void btnAddCard_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            var product = button.DataContext as Product;

            if (product.Quantity <= 0)
            {
                MessageBox.Show("К сожалению товар закончился");
            } else
            {
                CardProductClass.productsList.Add(product);
                MessageBox.Show($"Товар {product.Title} успешно добавлен в корзину");
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CardProductWindow cardProductWindow = new CardProductWindow(); 
            cardProductWindow.ShowDialog();
        }
    }
}
