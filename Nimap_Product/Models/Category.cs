using System.ComponentModel.DataAnnotations.Schema;

namespace Nimap_Product.Models
{

    [Table("tblCategory")]
    public class Category
    {
        public int CategoryId { get; set; }
        public string ? CategoryName { get; set; }
    }
}
