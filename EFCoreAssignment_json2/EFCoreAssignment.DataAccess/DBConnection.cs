using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment.DataAccess
{
    public class DBConnection : DbContext
    {
        private readonly string _connectionString;

        public DBConnection(DbContextOptions<DBConnection> options) : base(options)
        {
        }
        
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Sales> Sales { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}