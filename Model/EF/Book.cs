namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            Order_detail = new HashSet<Order_detail>();
        }

        public long Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public long? Id_author { get; set; }

        public long? Id_category { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public long? Price { get; set; }

        public long? file_id_image { get; set; }

        public long? file_id_pdf { get; set; }

        public long? id_comment { get; set; }

        public long? Id_NXB { get; set; }

        public long? Number_left { get; set; }

        public long? Page { get; set; }

        public virtual Author Author { get; set; }

        public virtual Category Category { get; set; }

        public virtual File File { get; set; }

        public virtual File File1 { get; set; }

        public virtual NXB NXB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_detail> Order_detail { get; set; }
    }
}
