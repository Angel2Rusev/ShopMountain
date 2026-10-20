using Microsoft.EntityFrameworkCore;
using PROJECT_ANGEL.Models;

namespace PROJECT_ANGEL.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(ci => ci.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
