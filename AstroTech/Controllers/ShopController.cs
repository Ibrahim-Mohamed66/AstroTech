using AstroTech.BLL.Contracts;
using AstroTech.BLL.DTOs;
using AstroTech.DAL.Data;
using AstroTech.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AstroTech.Web.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly AstroTechAppContext _context;

        public ShopController(
            IProductService productService,
            ICategoryService categoryService,
            AstroTechAppContext context)
        {
            _productService = productService;
            _categoryService = categoryService;
            _context = context;
        }

        public IActionResult All()
        {
            var products = _productService.GetAllProducts()
                .Select(p => new ProductDTO
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
                    PrimaryImageUrl = p.Images?.FirstOrDefault(i => i.IsPrimary)?.ImageUrl ?? "/img/default-product.png",
                    AllImageUrls = p.Images?.Select(i => i.ImageUrl).ToList() ?? new List<string>()
                }).ToList();

            ViewBag.CategoryName = "All Products";
            return View("ProductList", products);
        }

        public IActionResult Category(int id)
        {
            var category = _categoryService.GetMainCategories().FirstOrDefault(c => c.Id == id);
            if (category == null)
                return NotFound();

            var products = _productService.GetAllProducts()
                .Where(p => p.CategoryId == id)
                .Select(p => new ProductDTO
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
                    PrimaryImageUrl = p.Images?.FirstOrDefault(i => i.IsPrimary)?.ImageUrl ?? "/img/default-product.png",
                    AllImageUrls = p.Images?.Select(i => i.ImageUrl).ToList() ?? new List<string>()
                }).ToList();

            ViewBag.CategoryName = category.CategoryName;
            return View("ProductList", products);
        }

        public IActionResult ProductDetails(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
                return NotFound();

            var dto = new ProductDTO
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
                PrimaryImageUrl = product.Images?.FirstOrDefault(i => i.IsPrimary)?.ImageUrl ?? "/img/default-product.png",
                AllImageUrls = product.Images?.Select(i => i.ImageUrl).ToList() ?? new List<string>(),
                Color = product.Color,
                WarrantyPeriodMonths = product.WarrantyPeriodMonths
            };

            return View("ProductDetails", dto);
        }

        [HttpGet]
        public IActionResult Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return Json(new List<object>());

            var results = _productService.GetAllProducts()
                .Where(p => p.ProductName.Contains(query, StringComparison.OrdinalIgnoreCase))
                .Select(p => new
                {
                    id = p.Id,
                    productName = p.ProductName,
                    primaryImageUrl = p.Images?.FirstOrDefault(i => i.IsPrimary)?.ImageUrl ?? "/img/default-product.png"
                })
                .Take(10)
                .ToList();

            return Json(results);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCart(int productId, int quantity = 1)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userIdString == null)
                return RedirectToAction("Login", "Account");

            if (!int.TryParse(userIdString, out int userId))
            {
                return BadRequest("Invalid User ID format.");
            }

            // Check for or create the cart
            var cart = _context.Carts.FirstOrDefault(c => c.UserId == userId);
            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId
                };
                _context.Carts.Add(cart);
                _context.SaveChanges();
            }

            // Check if item already exists
            var cartItem = _context.CartItems
                .FirstOrDefault(ci => ci.CartId == cart.Id && ci.ProductId == productId);

            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
                _context.Update(cartItem);
            }
            else
            {
                _context.CartItems.Add(new CartItem
                {
                    CartId = cart.Id,
                    ProductId = productId,
                    Quantity = quantity
                });
            }

            _context.SaveChanges();
            return RedirectToAction("Cart");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateQuantity(int cartItemId, string operation)
        {
            var cartItem = _context.CartItems
                .Include(ci => ci.Product)
                .FirstOrDefault(ci => ci.Id == cartItemId);

            if (cartItem == null)
                return NotFound();

            if (operation == "increase")
                cartItem.Quantity += 1;
            else if (operation == "decrease")
                cartItem.Quantity = Math.Max(1, cartItem.Quantity - 1); // prevent 0

            _context.SaveChanges();
            return RedirectToAction("Cart");
        }

        [HttpPost]
        public IActionResult UpdateCartQuantity(int productId, string action)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrWhiteSpace(userIdString))
                return Json(new { success = false, message = "Not authenticated" });

            if (!int.TryParse(userIdString, out int userId))
            {
                return Json(new { success = false, message = "Invalid User ID format" });
            }

            var userCart = _context.Carts.Include(c => c.CartItems)
                                         .ThenInclude(ci => ci.Product)
                                         .FirstOrDefault(c => c.UserId == userId);

            if (userCart == null)
                return Json(new { success = false });

            var cartItem = userCart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

            if (cartItem == null)
                return Json(new { success = false });

            if (action == "increase")
                cartItem.Quantity++;
            else if (action == "decrease" && cartItem.Quantity > 1)
                cartItem.Quantity--;

            _context.SaveChanges();

            var subtotal = cartItem.Product?.BasePrice * cartItem.Quantity ?? 0;
            var total = userCart.CartItems.Sum(i => i.Product?.BasePrice * i.Quantity ?? 0);

            return Json(new
            {
                success = true,
                quantity = cartItem.Quantity,
                subtotal,
                total
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveItem(int productId)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdString, out int userId))
            {
                return BadRequest("Invalid User ID.");
            }

            var cart = _context.Carts
                .Include(c => c.CartItems)
                .FirstOrDefault(c => c.UserId == userId);

            if (cart == null)
            {
                return NotFound();
            }

            var itemToRemove = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

            if (itemToRemove != null)
            {
                _context.CartItems.Remove(itemToRemove);
                _context.SaveChanges();
            }

            return RedirectToAction("Cart");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ClearCart()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdString, out int userId))
            {
                return BadRequest("Invalid User ID.");
            }

            var cart = _context.Carts
                .Include(c => c.CartItems)
                .FirstOrDefault(c => c.UserId == userId);

            if (cart == null)
            {
                return NotFound();
            }

            _context.CartItems.RemoveRange(cart.CartItems);
            _context.SaveChanges();

            return RedirectToAction("Cart");
        }


        public IActionResult Cart()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userIdString == null)
                return RedirectToAction("Login", "Account");

            if (!int.TryParse(userIdString, out int userId))
            {
                return BadRequest("Invalid User ID format.");
            }

            var cart = _context.Carts
                .Include(c => c.User)
                .FirstOrDefault(c => c.UserId == userId);

            if (cart == null)
                return View(new List<CartItem>());

            var items = _context.CartItems
                .Where(ci => ci.CartId == cart.Id)
                .Include(ci => ci.Product)
                .ToList();

            return View(items);
        }
    }
}