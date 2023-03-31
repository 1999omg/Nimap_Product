using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nimap_Product.Models
{
    [Table("tblProduct")]
    public class Products
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string ? ProductName { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }


    }
}
