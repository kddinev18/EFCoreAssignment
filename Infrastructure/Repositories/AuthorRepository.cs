using Microsoft.EntityFrameworkCore;
using EFCoreAssignment.Domain.Models;
using EFCoreAssignment.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace EFCoreAssignment.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _dbContext;

        public AuthorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _dbContext.Authors.ToListAsync();
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await _dbContext.Authors.FindAsync(id);
        }

        public async Task AddAsync(Author author)
        {
            await _dbContext.Authors.AddAsync(author);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Author author)
        {
            _dbContext.Authors.Update(author);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var author = await _dbContext.Authors.FindAsync(id);
            if (author != null)
            {
                _dbContext.Authors.Remove(author);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}