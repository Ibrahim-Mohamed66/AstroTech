using AstroTech.BLL.Contracts;
using AstroTech.DAL.Contracts;
using AstroTech.DAL.Models;

namespace AstroTech.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryService(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public IEnumerable<Category> GetMainCategories()
        {
            return _categoryRepo.GetMainCategories();
        }
    }
}
