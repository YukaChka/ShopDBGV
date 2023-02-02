//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopStoreVG.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductSale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductSale()
        {
            this.OrderHistory = new HashSet<OrderHistory>();
        }
    
        public int IDProductSale { get; set; }
        public System.DateTime DateSale { get; set; }
        public int IDClient { get; set; }
        public int IDEmployee { get; set; }
        public int IDProduct { get; set; }
        public int Quantity { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderHistory> OrderHistory { get; set; }
        public virtual Product Product { get; set; }
    }
}