namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Order_detail = new HashSet<Order_detail>();
        }

        public long Id { get; set; }

        public long? Id_Shipper { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        public long? Id_customer { get; set; }

        public DateTime? start_date { get; set; }

        public bool? status { get; set; }

        public long? total { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_detail> Order_detail { get; set; }

        public virtual Worker Worker { get; set; }
    }
}
