using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
namespace AstroTech.Models;
public class Product
{

    public int Id { get; set; }

    [Required(ErrorMessage = "Product Name is required.")]
    [StringLength(100, ErrorMessage = "Product Name cannot exceed 100 characters.")]
    public string ProductName { get; set; }

    [Required(ErrorMessage = "Product Description is required.")]
    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string ProductDescription { get; set; }

    // Original price
    [Required(ErrorMessage = "Base Price is required.")]
    [Column(TypeName = "decimal(18,2)")]
    [Range(5, 1000000, ErrorMessage = "Base Price must be between 0.01 and 1,000,000.")]
    public decimal BasePrice { get; set; }


    [Required(ErrorMessage = "Specifications are required.")]
    public JsonDocument Specifications { get; set; }

    // Price after applying a sale (optional)
    [Column(TypeName = "decimal(18,2)")]
    [Range(1, 1000000, ErrorMessage = "Sale Price must be between 1 and 1,000,000.")]
    public decimal? SalePrice { get; set; }

    public bool IsOnSale { get; set; } = false;

    [Required(ErrorMessage = "Stock Quantity is required.")]
    [Range(0, int.MaxValue, ErrorMessage = "Stock Quantity cannot be negative.")]
    public int StockQuantity { get; set; }

    // Foreign Key with Category
    [Required(ErrorMessage = "Category is required.")]
    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Brand is required.")]
    [ForeignKey("BrandId")]
    public int BrandId  { get; set; }

    // Optional Discount
    [Column(TypeName = "decimal(18,2)")]
    [Range(1, 1000000, ErrorMessage = "Discount Price must be between 0.01 and 1,000,000.")]
    public decimal? DiscountPrice { get; set; }

    // Warranty in Months (Optional)
    [Range(0, 120, ErrorMessage = "Warranty cannot exceed 120 months (10 years).")]
    public int? WarrantyPeriodMonths { get; set; }

    // Optional Color
    [StringLength(30, ErrorMessage = "Color name cannot exceed 30 characters.")]
    public string? Color { get; set; }
    public Category? Category { get; set; }
    public Brand? Brand { get; set; }

}