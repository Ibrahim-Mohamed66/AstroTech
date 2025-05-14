// File: CategoryMenuViewComponent.cs
using AstroTech.BLL.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AstroTech.ViewComponents
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoryMenuViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = _categoryService.GetMainCategories();
            return View("_CategoryNav", categories);
        }
    }
}
