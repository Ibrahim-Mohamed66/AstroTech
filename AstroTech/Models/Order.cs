using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace AstroTech.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    [Column(TypeName = "decimal(18,2)")]
    [Range(1, double.MaxValue, ErrorMessage = "Total price must be a positive number.")]
    public decimal TotalPrice { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }

    public String Status { get; set; }

    [Required]
    [MaxLength(250, ErrorMessage = "Shipping address cannot exceed 250 characters.")]
    public string ShippingAddress { get; set; }

    [ForeignKey("Shipping")]
    public int? ShippingId { get; set; }

    public String PaymentMethod { get; set; }
    public Shipping? Shipping { get; set; }
    public Payment? Payment { get; set; }
    public ApplicationUser? User { get; set; }

}
