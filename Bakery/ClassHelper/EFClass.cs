using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.ClassHelper
{
    internal class EFClass
    {
        public static DB.BekaryDBEntities7 ContextDB { get; } = new DB.BekaryDBEntities7();
    }
}
