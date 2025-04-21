using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AstroTech.Models;

public class ProductImage
{
    public int Id { get; set; }
    [Required]
    public string ImageUrl { get; set; } 

    [ForeignKey("Product")]
    public int ProductId { get; set; }

    public bool IsPrimary { get; set; } = false;
    public Product? Product { get; set; }

}
