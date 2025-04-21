using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AstroTech.Models;

public class InventoryLog
{
    public int Id { get; set; }

    [Required]
    [ForeignKey("Product")]
    public int ProductId { get; set; }

    [Required]
    public int QuantityChanged { get; set; } // Positive for adding, Negative for removing

    [Required]
    public DateTime ChangeDate { get; set; } = DateTime.UtcNow;

    [Required]
    [MaxLength(250, ErrorMessage = "Reason cannot exceed 250 characters.")]
    public string Reason { get; set; } // Example: "Purchase", "Return", "Stock Adjustment"
    public Product? Product { get; set; }
}
