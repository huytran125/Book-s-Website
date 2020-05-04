namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
	[Serializable]
	public partial class Order_detail
    {
        public long Id { get; set; }

        public long? Id_book { get; set; }

        public long? Number { get; set; }

        public long? Money { get; set; }

        public long? Id_order { get; set; }

        public virtual Book Book { get; set; }

        public virtual Order Order { get; set; }
    }
}
