//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bakery.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class PurchaseProduct
    {
        public int ID { get; set; }
        public int PurchaseID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Purchase Purchase { get; set; }
    }
}