namespace AstroTech.BLL.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        // Basic Product Info
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        // Pricing
        public decimal BasePrice { get; set; }
        public decimal? SalePrice { get; set; }

        // Inventory
        public int StockQuantity { get; set; }

        // Category & Brand
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }

        // Images
        public string PrimaryImageUrl { get; set; }
        public List<string> AllImageUrls { get; set; } = new List<string>();

        // UI Display Helpers
        public bool IsOnSale => SalePrice.HasValue && SalePrice.Value < BasePrice;

        // Added properties
        public string Color { get; set; }  // Color property
        public int? WarrantyPeriodMonths { get; set; }  // Warranty Period property
    }
}
