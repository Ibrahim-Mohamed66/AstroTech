using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AstroTech.Domain.Models;
public class CartItem
{
    public int Id { get; set; }

    [ForeignKey("CartId")]
    public int CartId { get; set; }


    [ForeignKey("ProductId")]
    public int ProductId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
    public int Quantity { get; set; }

    public Cart? Cart { get; set; }
    public Product? Product { get; set; }
}
