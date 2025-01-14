using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonTRI.Domain.Entities;

namespace JsonTRI.Infrastucture.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowRecord> BorrowRecords { get; set; }
        public DbSet<Library> Libraries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasKey(u => u.AuthorId);
            modelBuilder.Entity<Book>().HasKey(p => p.BookId);
            modelBuilder.Entity<BorrowRecord>().HasKey(o => o.BorrowRecordId);
            modelBuilder.Entity<Library>().HasKey(od => od.LibraryId);

            base.OnModelCreating(modelBuilder);
        }
    }

}