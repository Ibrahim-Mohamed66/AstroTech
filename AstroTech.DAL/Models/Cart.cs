using System.ComponentModel.DataAnnotations.Schema;

namespace AstroTech.DAL.Models;
public class Cart
{
    public int Id { get; set; }
    [ForeignKey("UserId")]
    public int UserId { get; set; }
    public ApplicationUser? User { get; set; }
    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}
