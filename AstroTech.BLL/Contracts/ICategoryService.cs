
using AstroTech.DAL.Models;


namespace AstroTech.BLL.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetMainCategories();
    }
}
