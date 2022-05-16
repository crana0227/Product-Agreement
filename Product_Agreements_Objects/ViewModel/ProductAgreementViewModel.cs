using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product_Agreements.ViewModel
{
    public class ProductAgreementViewModel
    {
        public int id { get; set; }
        public string userid { get; set; } = null!;
        public string username { get; set; }
        public string productgroupcode { get; set; }
        public string productgroupdescription { get; set; }
        public string productdescription { get; set; }
        public string productnumber { get; set; }
        public DateTime effectivedate { get; set; }
        public DateTime expirationdate { get; set; }
        public decimal productprice { get; set; }
        public decimal newprice { get; set; }
        public int filtertotalcount { get; set; }

    }

}