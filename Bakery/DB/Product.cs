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
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.ProductHistory = new HashSet<ProductHistory>();
            this.ProductPhoto = new HashSet<ProductPhoto>();
            this.PurchaseProduct = new HashSet<PurchaseProduct>();
        }
    
        public int ID { get; set; }
        public string Title { get; set; }
        public double Cost { get; set; }
        public int Quantity { get; set; }
        public int ManufacturerID { get; set; }
        public int TypeID { get; set; }
        public string Description { get; set; }
        public byte[] PhotoProd { get; set; }
    
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ProductType ProductType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductHistory> ProductHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductPhoto> ProductPhoto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseProduct> PurchaseProduct { get; set; }
    }
}
