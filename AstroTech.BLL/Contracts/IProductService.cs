using AstroTech.BLL.DTOs;
using AstroTech.DAL.Models;


namespace AstroTech.BLL.Contracts
{
    public interface IProductService
    {
        // Core product operations
        IEnumerable<Product> GetAllProducts();              
        Product GetProductById(int id);                      
        void AddProduct(Product product);                     
        void UpdateProduct(Product product);                  
        void DeleteProduct(int id);                           

        Task<IEnumerable<ProductDTO>> GetAllWithImagesAsync();  
        Task<ProductDTO?> GetByIdWithImagesAsync(int id);       

        // Get new products
        IEnumerable<Product> GetNewProducts();               
        IEnumerable<Product> GetTopSellingProducts();       
    }
}
