using System.ComponentModel.DataAnnotations;
namespace AstroTech.Domain.Models;


public class PromoCode
{
    public int PromoCodeId { get; set; }

    [Required(ErrorMessage = "Promo code is required.")]
    [StringLength(20, ErrorMessage = "Promo code cannot exceed 20 characters.")]
    public string Code { get; set; } // e.g., "SUMMER25"

    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string? Description { get; set; }

    [Range(5, 100, ErrorMessage = "Discount percentage must be between 0 and 100.")]
    public int? DiscountPercentage { get; set; }

    [Required(ErrorMessage = "Maximum usage limit is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Max usage limit must be at least 1.")]
    public int MaxUsageLimit { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Current usage cannot be negative.")]
    public int CurrentUsage { get; set; } = 0;

    [Required(ErrorMessage = "Expiration date is required.")]
    public DateTime? ExpirationDate { get; set; }

    // Calculated Property to check if the promo code is active
    public bool IsActive => CurrentUsage < MaxUsageLimit && DateTime.UtcNow <= ExpirationDate;
}
