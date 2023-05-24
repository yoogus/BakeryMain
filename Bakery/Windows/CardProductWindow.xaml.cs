using Bakery.ClassHelper;
using Bakery.DB;
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

using static Bakery.ClassHelper.CardProductClass;
using static Bakery.ClassHelper.UserDataClass;

namespace Bakery.Windows
{
    /// <summary>
    /// Логика взаимодействия для CardProductWindow.xaml
    /// </summary>
    public partial class CardProductWindow : Window
    {
        public CardProductWindow()
        {
            InitializeComponent();
            TotalAmount();

            LvProductCard.ItemsSource = productsList;
            tbxUser.Text = UserDataClass.user.Login;
        }

        private void TotalAmount()
        {
            double TotalCost = 0;

            foreach (Product product in CardProductClass.productsList)
            {
                TotalCost += product.Cost;
                tbxAmount.Text ="Итого: " + Convert.ToString(TotalCost);
            }
        }

        private void btnRemoveCard_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            var product = button.DataContext as Product;

            if (product != null)
            {
                productsList.Remove(product);

                LvProductCard.ItemsSource = productsList;

                MessageBox.Show(product.Title + " Удален из корзины");
            }
        }
    }
}
