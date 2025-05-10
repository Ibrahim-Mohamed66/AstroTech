using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace AstroTech.DAL.Models;

public class ProductPromotion
{
    public int Id { get; set; }

    [ForeignKey("Product")]
    public int ProductId { get; set; }

    [ForeignKey("Promotion")]
    public int PromotionId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    [ForeignKey("PromoCode")]
    public int? PromoCodeId { get; set; }
    public Promotion? Promotion { get; set; }
    public Product? Product { get; set; }
    public PromoCode? PromoCode { get; set; }
}