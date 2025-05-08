using AstroTech.Domain.Models;
using AstroTech.Infrastructure.Contracts;
using AstroTech.Infrastructure.Data;
using AstroTech.Infrastructure.Repositories;

namespace AstroTech.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AstroTechAppContext _context;
        private readonly IUserRepository _userRepository;
        public UnitOfWork(AstroTechAppContext context, IUserRepository userRepository)
        {
            _context = context;

            Products = new Repository<Product>(_context);
            Categories = new Repository<Category>(_context);
            Orders = new Repository<Order>(_context);
            OrderItems = new Repository<OrderItem>(_context);
            Payments = new Repository<Payment>(_context);
            Shippings = new Repository<Shipping>(_context);
            Reviews = new Repository<Review>(_context);
            WishLists = new Repository<WishList>(_context);
            _userRepository = userRepository;
            Users = _userRepository;
        }

        public IRepository<Product> Products { get; }
        public IRepository<Category> Categories { get; }
        public IRepository<Order> Orders { get; }
        public IRepository<OrderItem> OrderItems { get; }
        public IRepository<Payment> Payments { get; }
        public IRepository<Shipping> Shippings { get; }
        public IRepository<Review> Reviews { get; }
        public IRepository<WishList> WishLists { get; }
        public IUserRepository Users { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
