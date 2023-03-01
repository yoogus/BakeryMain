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

using static Bakery.ClassHelper.EFClass;
using Bakery.Windows;
using Bakery.ClassHelper;

namespace Bakery.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrWindow.xaml
    /// </summary>
    public partial class RegistrWindow : Window
    {
        public RegistrWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbxPass.Password == "")
            {
                MessageBox.Show("Введите пароль");
            }
            else if (tbxPass.Password.Length < 8)
            {
                MessageBox.Show("Пароль должен состоять не менее чем из 8 символов");
            }

            ContextDB.User.Add(new DB.User
            {
                Login = tbxLogin.Text,
                Password = tbxPass.Password,
                Email = tbxEmail.Text,
            });

            ContextDB.SaveChanges();

            MessageBox.Show("OK");


        }
    }
}
