using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AstroTech.Models
{
    public class ProductSpecification
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required, MaxLength(100)]
        public string Key { get; set; } // Example: "RAM", "Storage", "Processor"

        [Required, MaxLength(100)]
        public string Value { get; set; } // Example: "16GB", "512GB SSD", "Intel i7"
    }
}