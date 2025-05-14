using AstroTech.BLL.Contracts;
using AstroTech.BLL.DTOs;
using AstroTech.DAL.Contracts;
using AstroTech.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroTech.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;

        public ProductService(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        // Core product operations
        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepo.GetAll();
        }

        public Product GetProductById(int id)
        {
            return _productRepo.GetById(id);
        }

        public void AddProduct(Product product)
        {
            _productRepo.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            _productRepo.Update(product);
        }

        public void DeleteProduct(int id)
        {
            _productRepo.Delete(id);
        }

        // Get new products
        public IEnumerable<Product> GetNewProducts()
        {
            return _productRepo.GetAll()
                .OrderByDescending(p => p.Id)
                .Take(10);
        }

        // Get top-selling products
        public IEnumerable<Product> GetTopSellingProducts()
        {
            return _productRepo.GetAll()
                .OrderByDescending(p => p.StockQuantity)
                .Take(10);
        }

        // Get products with images (convert to ProductDTO)
        public async Task<IEnumerable<ProductDTO>> GetAllWithImagesAsync()
        {
            var products = await _productRepo.GetAllWithImagesAsync();

            return products.Select(p => new ProductDTO
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
                PrimaryImageUrl = p.Images?.FirstOrDefault(i => i.IsPrimary)?.ImageUrl
                    ?? p.Images?.FirstOrDefault()?.ImageUrl,
                AllImageUrls = p.Images?.Select(i => i.ImageUrl).ToList() ?? new List<string>()
            }).ToList();
        }

        // Get single product by Id with images (convert to ProductDTO)
        public async Task<ProductDTO?> GetByIdWithImagesAsync(int id)
        {
            var product = await _productRepo.GetByIdWithImagesAsync(id);
            if (product == null) return null;

            return new ProductDTO
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                BasePrice = product.BasePrice,
                SalePrice = product.SalePrice,
                StockQuantity = product.StockQuantity,
                CategoryId = product.CategoryId,
                CategoryName = product.Category?.CategoryName,
                BrandId = product.BrandId,
                BrandName = product.Brand?.Name,
                PrimaryImageUrl = product.Images?.FirstOrDefault(i => i.IsPrimary)?.ImageUrl
                    ?? product.Images?.FirstOrDefault()?.ImageUrl,
                AllImageUrls = product.Images?.Select(i => i.ImageUrl).ToList() ?? new List<string>()
            };
        }
    }
}
