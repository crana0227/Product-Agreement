using System;
using System.Collections.Generic;

namespace Product_Agreements.Entities
{
    public partial class Product
    {
        public Product()
        {
            Agreements = new HashSet<Agreement>();
        }

        public int Id { get; set; }
        public int ProductGroupId { get; set; }
        public string ProductDescription { get; set; } = null!;
        public string ProductNumber { get; set; } = null!;
        public decimal Price { get; set; }
        public bool Active { get; set; }

        public virtual ProductGroup ProductGroup { get; set; } = null!;
        public virtual ICollection<Agreement> Agreements { get; set; }
    }
}
