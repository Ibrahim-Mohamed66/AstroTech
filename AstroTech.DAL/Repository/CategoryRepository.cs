using AstroTech.DAL.Contracts;
using AstroTech.DAL.Models;
using AstroTech.DAL.Data;

namespace AstroTech.DAL.Repository
{
    public class CategoryRepository : ICategoryRepository  
    {
        private readonly AstroTechAppContext _context;

        public CategoryRepository(AstroTechAppContext context)
        {
            _context = context;
        }

        // Fetch the main (parent) categories only
        public IEnumerable<Category> GetMainCategories()
        {
            return _context.Categories
                           .Where(c => c.ParentCategoryId == null)  // Only top-level categories
                           .ToList();
        }
    }
}
