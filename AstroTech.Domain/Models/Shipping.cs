using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AstroTech.Domain.Models;

public class Shipping
{
    [Key]
    public int ShippingId { get; set; }

    [Required(ErrorMessage = "Recipient Name is required.")]
    [StringLength(100, ErrorMessage = "Recipient Name cannot exceed 100 characters.")]
    public string RecipientName { get; set; }

    [Required(ErrorMessage = "Address is required.")]
    [StringLength(255, ErrorMessage = "Address cannot exceed 255 characters.")]
    public string Address { get; set; }

    [Required(ErrorMessage = "City is required.")]
    [StringLength(50, ErrorMessage = "City cannot exceed 50 characters.")]
    public string City { get; set; }

    [Required(ErrorMessage = "Phone number is required.")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must be exactly 11 digits.")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Shipping Method is required.")]
    [StringLength(50, ErrorMessage = "Shipping Method cannot exceed 50 characters.")]
    public string ShippingMethod { get; set; } // e.g., Standard, Express

    [Required(ErrorMessage = "Shipping Cost is required.")]
    [Column(TypeName = "decimal(18,2)")]
    [Range(0.01, 10000, ErrorMessage = "Shipping Cost must be between 0.01 and 10,000.")]
    public decimal ShippingCost { get; set; }

    public DateTime? ShippedDate { get; set; }
    public DateTime? EstimatedDeliveredDate { get; set; }

    [StringLength(50, ErrorMessage = "Tracking Number cannot exceed 50 characters.")]
    public string? TrackingNumber { get; set; }

    [Required(ErrorMessage = "Shipping Status is required.")]
    public String ShippingStatus { get; set; } // Enum for Pending, Shipped, Delivered, etc.

    // Foreign Key Relationship with Order
    [Required(ErrorMessage = "Order is required.")]
    [ForeignKey("OrderId")]
    public int OrderId { get; set; }
    public Order? Order { get; set; }
}
