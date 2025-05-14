using AstroTech.DAL.Repositories;
using AstroTech.DAL.Contracts;
using AstroTech.DAL.Data;
using AstroTech.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroTech.DAL.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AstroTechAppContext _context;

        public ProductRepository(AstroTechAppContext context) : base(context)
        {
            _context = context;
        }

        // Core product operations
        public IEnumerable<Product> GetAll()
        {
            return _context.Products
                .Include(p => p.Images) // Load associated images
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .ToList();
        }

        public Product? GetById(int id)
        {
            return _context.Products
                .Include(p => p.Images)
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetByCategoryId(int categoryId)
        {
            return _context.Products
                .Include(p => p.Images)
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Where(p => p.CategoryId == categoryId)
                .ToList();
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            // Make sure existing images are preserved or replaced properly
            var existingProduct = _context.Products
                .Include(p => p.Images)
                .FirstOrDefault(p => p.Id == product.Id);

            if (existingProduct != null)
            {
                _context.Entry(existingProduct).CurrentValues.SetValues(product);

                // If new images are provided, replace the collection
                if (product.Images != null && product.Images.Any())
                {
                    existingProduct.Images.Clear();
                    foreach (var image in product.Images)
                    {
                        existingProduct.Images.Add(image);
                    }
                }

                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        // Extended read operations
        public async Task<IEnumerable<Product>> GetAllWithImagesAsync()
        {
            return await _context.Products
                .Include(p => p.Images)
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdWithImagesAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Images)
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
