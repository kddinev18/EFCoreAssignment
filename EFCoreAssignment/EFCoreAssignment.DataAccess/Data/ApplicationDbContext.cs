using EFCoreAssignment.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment.DataAccess.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; } = null!;
    
    public DbSet<Product> Products { get; set; } = null!;
    
    public DbSet<Order> Orders { get; set; } = null!;
    
    public DbSet<OrderDetail> OrderDetails { get; set; } = null!;
}
