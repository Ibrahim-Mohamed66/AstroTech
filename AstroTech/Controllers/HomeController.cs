using AstroTech.BLL.Contracts;
using AstroTech.BLL.DTOs;
using AstroTech.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AstroTech.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public HomeController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                FeaturedCategories = _categoryService.GetMainCategories(),
                NewProducts = _productService.GetNewProducts().Select(p => new ProductDTO
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    ProductDescription = p.ProductDescription,
                    BasePrice = p.BasePrice,
                    SalePrice = p.SalePrice,
                    StockQuantity = p.StockQuantity,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category?.CategoryName,
                    BrandId = p.BrandId,
                    BrandName = p.Brand?.Name,
                    PrimaryImageUrl = p.Images?.FirstOrDefault(i => i.IsPrimary)?.ImageUrl ?? p.Images?.FirstOrDefault()?.ImageUrl,
                    AllImageUrls = p.Images?.Select(i => i.ImageUrl).ToList() ?? new List<string>()
                }),
                TopSelling = _productService.GetTopSellingProducts().Select(p => new ProductDTO
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    ProductDescription = p.ProductDescription,
                    BasePrice = p.BasePrice,
                    SalePrice = p.SalePrice,
                    StockQuantity = p.StockQuantity,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category?.CategoryName,
                    BrandId = p.BrandId,
                    BrandName = p.Brand?.Name,
                    PrimaryImageUrl = p.Images?.FirstOrDefault(i => i.IsPrimary)?.ImageUrl ?? p.Images?.FirstOrDefault()?.ImageUrl,
                    AllImageUrls = p.Images?.Select(i => i.ImageUrl).ToList() ?? new List<string>()
                }),
                AllProducts = _productService.GetAllProducts().Select(p => new ProductDTO
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    ProductDescription = p.ProductDescription,
                    BasePrice = p.BasePrice,
                    SalePrice = p.SalePrice,
                    StockQuantity = p.StockQuantity,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category?.CategoryName,
                    BrandId = p.BrandId,
                    BrandName = p.Brand?.Name,
                    PrimaryImageUrl = p.Images?.FirstOrDefault(i => i.IsPrimary)?.ImageUrl ?? p.Images?.FirstOrDefault()?.ImageUrl,
                    AllImageUrls = p.Images?.Select(i => i.ImageUrl).ToList() ?? new List<string>()
                })
            };

            return View(model);
        }
    }
}
