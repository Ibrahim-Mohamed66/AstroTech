using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AstroTech.Domain.Models;

public class PromotionalHistory
{
    public int Id { get; set; }

    [ForeignKey("ProductId")]
    public int ProductId { get; set; }


    [Required(ErrorMessage = "Old price is required.")]
    [Column(TypeName = "decimal(18,2)")]
    [Range(1, 100000, ErrorMessage = "Old price must be between 0.01 and 100,000.")]
    public decimal OldPrice { get; set; }

    [Required(ErrorMessage = "New price is required.")]
    [Column(TypeName = "decimal(18,2)")]
    [Range(0.01, 100000, ErrorMessage = "New price must be between 0.01 and 100,000.")]
    public decimal NewPrice { get; set; }

    [Required(ErrorMessage = "Applied date is required.")]
    public DateTime AppliedDate { get; set; } = DateTime.UtcNow;


    [StringLength(255, ErrorMessage = "Reason cannot exceed 255 characters.")]
    public string? Reason { get; set; } // Example: "Black Friday Sale"


    public Product? Product { get; set; }
}
