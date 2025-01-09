using Microsoft.EntityFrameworkCore;
using EFCoreAssignment.Data.Models;
using System.Text.Json;

namespace EFCoreAssignment.Data.Data.Contexts
{
    public class EFCoreAssignmentDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;

        public EFCoreAssignmentDbContext() { }
        public EFCoreAssignmentDbContext(DbContextOptions<EFCoreAssignmentDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.Orders).WithOne(o => o.User).HasForeignKey(o => o.UserId);
            modelBuilder.Entity<Order>().HasMany(o => o.OrderDetails).WithOne(od => od.Order).HasForeignKey(od => od.OrderId);
            modelBuilder.Entity<OrderDetail>().HasOne(od => od.Product).WithMany(p => p.OrderDetails).HasForeignKey(od => od.ProductId);
        }
    }
}
