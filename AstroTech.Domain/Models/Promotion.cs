using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AstroTech.Domain.Models;

public class Promotion
{
    public int PromotionId { get; set; }

    [Required(ErrorMessage = "Promotion name is required.")]
    [StringLength(100, ErrorMessage = "Promotion name cannot exceed 100 characters.")]
    public string Name { get; set; }

    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string? Description { get; set; }

    [Range(5, 100, ErrorMessage = "Discount percentage must be between 0 and 100.")]
    public int? DiscountPercentage { get; set; }

    [Required(ErrorMessage = "Start date is required.")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "End date is required.")]
    public DateTime EndDate { get; set; }

    // Calculated Property to check if the promotion is currently active
    public bool IsActive => DateTime.UtcNow >= StartDate && DateTime.UtcNow <= EndDate;
}
