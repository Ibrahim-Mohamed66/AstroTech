using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace AstroTech.DAL.Models;
public class WishList
{
    public int Id { get; set; }

    [Required]
    [ForeignKey("UserId")]
    public int UserId { get; set; }

    [Required]
    [ForeignKey("ProductId")]
    public int ProductId { get; set; } // Foreign key to Product

    [DataType(DataType.DateTime)]
    public DateTime AddedAt { get; set; } = DateTime.UtcNow;
    public Product? Product { get; set; } // Navigation property
    public ApplicationUser? User { get; set; }
}
