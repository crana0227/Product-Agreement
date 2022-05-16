using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product_Agreements.ViewModel
{
    public class ProductGroupViewModel
    {
        public int Id { get; set; }
        public string GroupDescription { get; set; } = null!;
        public string GroupCode { get; set; } = null!;
        public bool Active { get; set; }
    }
}