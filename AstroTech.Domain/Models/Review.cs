using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AstroTech.Domain.Models;

public class Review
{

    public int Id { get; set; }

    [ForeignKey("UserId")]
    public int UserId { get; set; }


    [ForeignKey("ProductId")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Rating is required.")]
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
    public int Rating { get; set; }

    [StringLength(1000, ErrorMessage = "Comment cannot exceed 1000 characters.")]
    public string? Comment { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public ApplicationUser? User { get; set; }
    public Product? Product { get; set; }
}
