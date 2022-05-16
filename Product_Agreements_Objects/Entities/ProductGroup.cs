using System;
using System.Collections.Generic;

namespace Product_Agreements.Entities
{
    public partial class ProductGroup
    {
        public ProductGroup()
        {
            Agreements = new HashSet<Agreement>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string GroupDescription { get; set; } = null!;
        public string GroupCode { get; set; } = null!;
        public bool Active { get; set; }

        public virtual ICollection<Agreement> Agreements { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
