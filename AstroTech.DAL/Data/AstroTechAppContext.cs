using AstroTech.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AstroTech.DAL.Data;
public class AstroTechAppContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    public AstroTechAppContext(DbContextOptions<AstroTechAppContext>options) : base(options)
    {   
        
    }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<InventoryLog> InventoryLogs { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<ProductPromotion> ProductPromotions { get; set; }
    public DbSet<PromoCode> PromoCodes { get; set; }
    public DbSet<Promotion> Promotions { get; set; }
    public DbSet<PromotionalHistory> PromotionalHistories { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Shipping> Shippings { get; set; }
    public DbSet<WishList> WishLists { get; set; }

}