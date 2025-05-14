using AstroTech.DAL.Models;
using System.Collections.Generic;

namespace AstroTech.DAL.Contracts
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetMainCategories(); // Only top-level (non-sub) categories
    }
}