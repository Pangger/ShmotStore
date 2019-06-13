using System.Data.Entity;

namespace ShmotStore.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext() : base("DefaultConnection") { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}