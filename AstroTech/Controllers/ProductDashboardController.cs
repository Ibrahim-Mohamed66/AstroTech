using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AstroTech.BLL.Contracts;
using AstroTech.DAL.Models;
using AstroTech.DAL.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using OfficeOpenXml;
using System.Linq;
using System.Collections.Generic;

namespace AstroTech.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductDashboardController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly AstroTechAppContext _context;

        public ProductDashboardController(
            IProductService productService,
            ICategoryService categoryService,
            AstroTechAppContext context)
        {
            _productService = productService;
            _categoryService = categoryService;
            _context = context;
        }

        public IActionResult Index(int? categoryId, int? brandId)
        {
            var products = _productService.GetAllWithImagesAsync().Result;

            if (categoryId.HasValue)
                products = products.Where(p => p.CategoryId == categoryId.Value);

            if (brandId.HasValue)
                products = products.Where(p => p.BrandId == brandId.Value);

            ViewBag.Categories = _categoryService.GetMainCategories().ToList();
            ViewBag.Brands = _context.Brands.ToList();

            return View(products);
        }

        [HttpGet]
        public IActionResult FilterProducts(int? categoryId, int? brandId, string? search)
        {
            var products = _productService.GetAllWithImagesAsync().Result;

            if (categoryId.HasValue)
                products = products.Where(p => p.CategoryId == categoryId.Value);

            if (brandId.HasValue)
                products = products.Where(p => p.BrandId == brandId.Value);

            if (!string.IsNullOrWhiteSpace(search))
                products = products.Where(p => p.ProductName.Contains(search));

            return PartialView("_ProductTablePartial", products.ToList());
        }

        [HttpGet]
        public IActionResult ExportToExcel()
        {
            var products = _productService.GetAllWithImagesAsync().Result.ToList();

            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Products");

            worksheet.Cells[1, 1].Value = "Product Name";
            worksheet.Cells[1, 2].Value = "Base Price";
            worksheet.Cells[1, 3].Value = "Sale Price";
            worksheet.Cells[1, 4].Value = "Stock";
            worksheet.Cells[1, 5].Value = "Is On Sale";
            worksheet.Cells[1, 6].Value = "Category";
            worksheet.Cells[1, 7].Value = "Brand";
            worksheet.Cells[1, 8].Value = "Color";
            worksheet.Cells[1, 9].Value = "Warranty (Months)";

            for (int i = 0; i < products.Count; i++)
            {
                var p = products[i];
                int row = i + 2;

                worksheet.Cells[row, 1].Value = p.ProductName;
                worksheet.Cells[row, 2].Value = p.BasePrice;
                worksheet.Cells[row, 3].Value = p.SalePrice ?? 0;
                worksheet.Cells[row, 4].Value = p.StockQuantity;
                worksheet.Cells[row, 5].Value = p.IsOnSale ? "Yes" : "No";
                worksheet.Cells[row, 6].Value = p.CategoryName ?? "—";
                worksheet.Cells[row, 7].Value = p.BrandName ?? "—";
                worksheet.Cells[row, 8].Value = p.Color ?? "—";
                worksheet.Cells[row, 9].Value = p.WarrantyPeriodMonths?.ToString() ?? "—";
            }

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

            var stream = new MemoryStream(package.GetAsByteArray());
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Products.xlsx");
        }

        public IActionResult AddProduct()
        {
            ViewBag.Categories = _categoryService.GetMainCategories().ToList();
            ViewBag.Brands = _context.Brands.ToList();
            return View(new Product());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(Product product, IFormFile ProductImage)
        {
            if (ModelState.IsValid)
            {
                if (ProductImage != null)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "products");
                    Directory.CreateDirectory(uploadsFolder);

                    var filePath = Path.Combine(uploadsFolder, ProductImage.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        ProductImage.CopyTo(stream);
                    }

                    var productImage = new ProductImage
                    {
                        ImageUrl = "/img/products/" + ProductImage.FileName,
                        IsPrimary = true
                    };

                    product.Images = new List<ProductImage> { productImage };
                }

                _productService.AddProduct(product);
                return RedirectToAction("Index");
            }

            ViewBag.Categories = _categoryService.GetMainCategories().ToList();
            ViewBag.Brands = _context.Brands.ToList();
            return View(product);
        }

        public IActionResult EditProduct(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
                return NotFound();

            ViewBag.Categories = _categoryService.GetMainCategories().ToList();
            ViewBag.Brands = _context.Brands.ToList();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProduct(Product product, IFormFile ProductImage)
        {
            if (ModelState.IsValid)
            {
                if (ProductImage != null)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "products");
                    Directory.CreateDirectory(uploadsFolder);

                    var filePath = Path.Combine(uploadsFolder, ProductImage.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        ProductImage.CopyTo(stream);
                    }

                    var newImage = new ProductImage
                    {
                        ImageUrl = "/img/products/" + ProductImage.FileName,
                        IsPrimary = true
                    };

                    product.Images = new List<ProductImage> { newImage };
                }

                _productService.UpdateProduct(product);
                return RedirectToAction("Index");
            }

            ViewBag.Categories = _categoryService.GetMainCategories().ToList();
            ViewBag.Brands = _context.Brands.ToList();
            return View(product);
        }

        public IActionResult DeleteProduct(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
