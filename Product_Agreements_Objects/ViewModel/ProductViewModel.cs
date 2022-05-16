using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product_Agreements.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public int ProductGroupId { get; set; }
        public string ProductDescription { get; set; } = null!;
        public string ProductNumber { get; set; } = null!;
        public decimal Price { get; set; }
        public bool Active { get; set; }
    }
}