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

using Bakery.ClassHelper;
using Bakery.Windows;
using Bakery;
using System.Runtime.Remoting.Contexts;

namespace Bakery
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RegistrWindow registrWindow = new RegistrWindow();
            registrWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var userAuth = EFClass.ContextDB.User.ToList()
                .Where(i => i.Login == tbxLogin.Text &&
                i.Password == tbxPass.Password)
                .FirstOrDefault();

            if (userAuth != null)
            {
                UserDataClass.user = userAuth;

                MenuWindow menuWindow = new MenuWindow();   
                menuWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
            }
            
        }
    }
}
