using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Product_Agreements.Models
{
    public class ProductAgreementModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required(ErrorMessage = "Please Select Product Group Code")]
        public int ProductGroupId { get; set; }
        [Required(ErrorMessage = "Please Select Product Number")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter Effective Date")]
        [Display(Name = "Effective Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime EffectiveDate { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Please enter Expiration Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; } = DateTime.Now;
        [Range(1, 10000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ProductPrice { get; set; }
        [Range(1, 10000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal NewPrice { get; set; }
    }
}
