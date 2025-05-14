
using AstroTech.DAL.Models;

namespace AstroTech.DAL.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<Category> Categories { get; }
        IRepository<Order> Orders { get; }
        IRepository<OrderItem> OrderItems { get; }
        IRepository<Payment> Payments { get; }
        IRepository<Shipping> Shippings { get; }
        IRepository<Review> Reviews { get; }
        IRepository<WishList> WishLists { get; }
        IUserRepository Users { get; }

        Task<int> SaveChangesAsync();
    }
}
