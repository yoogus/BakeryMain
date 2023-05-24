using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Bakery.ClassHelper.EFClass;
using Bakery.Windows;
using Bakery.DB;
using System.Diagnostics.Metrics;
using System.Collections.ObjectModel;

namespace Bakery.ClassHelper
{
    internal class CardProductClass
    {
        public static List<Product> products = new List<Product>();
        public static ObservableCollection<Product> productsList = new ObservableCollection<Product>();
    }
}
