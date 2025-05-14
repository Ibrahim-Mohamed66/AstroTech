using AstroTech.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroTech.DAL.Contracts
{
    public interface IProductRepository
    {
        // Core product operations
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
        IEnumerable<Product> GetByCategoryId(int categoryId);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);

        // Extended read operations
        Task<IEnumerable<Product>> GetAllWithImagesAsync();
        Task<Product?> GetByIdWithImagesAsync(int id);
    }
}