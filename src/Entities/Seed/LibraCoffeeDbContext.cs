using Microsoft.EntityFrameworkCore;
using LibraCoffee.Entities.Models;

namespace LibraCoffee.Entities.Seed
{
    public class LibraCoffeeDbContext : DbContext
    {
        public LibraCoffeeDbContext(DbContextOptions<LibraCoffeeDbContext> options)
            : base(options)
        {
        }

        // 建立表与模型的映射关系
        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CoffeeConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
        }
    }
}