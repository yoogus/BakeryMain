using Bakery.DB;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {


        private string pathPhoto = null;

        private bool isEdit = false;

        private Product editProduct;

        public AddEditWindow()
        {
            InitializeComponent();


            CMBTypeProduct.ItemsSource = ContextDB.ProductType.ToList();
            CMBTypeProduct.SelectedIndex = 0;
            CMBTypeProduct.DisplayMemberPath = "TypeName";
        }

        public AddEditWindow(Product product)
        {
            InitializeComponent();

            CMBTypeProduct.ItemsSource = ContextDB.ProductType.ToList();
            CMBTypeProduct.SelectedIndex = 0;
            CMBTypeProduct.DisplayMemberPath = "TypeName";

            tbxName.Text = product.Title.ToString();
            TbDisc.Text = product.Description.ToString();
            CMBTypeProduct.SelectedItem = ContextDB.ProductType.Where(i => i.ID == product.TypeID).FirstOrDefault();

            if (product.ProductPhoto != null)
            {
                using (MemoryStream stream = new MemoryStream(product.PhotoProd))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();
                    ImgProduct.Source = bitmapImage;

                }
            }


            isEdit = true;

            editProduct = product;

        }

        private void BtnAddEdit_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit)
            {
                //изменение товара

                editProduct.Title = tbxName.Text;
                editProduct.Description = TbDisc.Text;
                editProduct.ID = (CMBTypeProduct.SelectedItem as ProductType).ID;
                if (pathPhoto != null)
                {
                    editProduct.PhotoProd = File.ReadAllBytes(pathPhoto);
                }
                ContextDB.SaveChanges();
                MessageBox.Show("OK");
            }
            else
            {
                //добавление товара
                Product product = new Product();
                product.Title = tbxName.Text;
                product.Description = TbDisc.Text;
                product.ID = (CMBTypeProduct.SelectedItem as ProductType).ID;
                if (pathPhoto != null)
                {
                    product.PhotoProd = File.ReadAllBytes(pathPhoto);
                }

                ContextDB.Product.Add(product);

                ContextDB.SaveChanges();
                MessageBox.Show("OK");
            }

            this.Close();
        }

        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImgProduct.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                pathPhoto = openFileDialog.FileName;
            }
        }
    }
}
