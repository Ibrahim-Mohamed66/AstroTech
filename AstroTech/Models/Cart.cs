using System.ComponentModel.DataAnnotations.Schema;

namespace AstroTech.Models;

public class Cart
{
    public int Id { get; set; }
    [ForeignKey("UserId")]
    public int UserId { get; set; }
    public User User { get; set; }
    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}
