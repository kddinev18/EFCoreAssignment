using EFCoreAssignment.Domain.Models;
using EFCoreAssignment.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreAssignment.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _dbContext;

        public BookRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _dbContext.Books
                .Include(b => b.Author)
                .ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _dbContext.Books
                .Include(b => b.Author)
                .FirstOrDefaultAsync(b => b.BookId == id);
        }

        public async Task AddAsync(Book book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _dbContext.Books.Update(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if (book != null)
            {
                _dbContext.Books.Remove(book);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}