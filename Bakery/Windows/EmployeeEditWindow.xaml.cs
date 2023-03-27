using Bakery.DB;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
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
    /// Логика взаимодействия для EmployeeEditWindow.xaml
    /// </summary>
    public partial class EmployeeEditWindow : Window
    {

        private string pathPhoto = null;

        private bool isEdit = false;

        private Employee editEmployee;

        public EmployeeEditWindow()
        {
            InitializeComponent();

        }

        public EmployeeEditWindow(Employee employee)
        {
            InitializeComponent();

            tbxName.Text = employee.FirstName.ToString();
            TbLastN.Text = employee.LastName.ToString();
            TbPatr.Text = employee.LastName.ToString();
           
            if (employee.EmployeePhoto != null)
            {
                using (MemoryStream stream = new MemoryStream(employee.EmployeePhoto))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();
                    ImgEmployee.Source = bitmapImage;

                }


            }
        }


        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImgEmployee.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                pathPhoto = openFileDialog.FileName;
            }
        }

        private void BtnAddEdit_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit)
            {
                //изменение товара

                editEmployee.FirstName = tbxName.Text;
                editEmployee.LastName = TbLastN.Text;
                editEmployee.Patronymic = TbPatr.Text;
                if (pathPhoto != null)
                {
                    editEmployee.EmployeePhoto = File.ReadAllBytes(pathPhoto);
                }
                ContextDB.SaveChanges();
                MessageBox.Show("OK");
            }

            this.Close();
        }
    }
}
