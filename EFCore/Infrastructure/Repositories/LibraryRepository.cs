// LibraryRepository.cs
using EFCoreAssignment.Domain.Interfaces;
using EFCoreAssignment.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreAssignment.Infrastructure.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly AppDbContext _dbContext;

        public LibraryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Library>> GetAllAsync()
        {
            return await _dbContext.Libraries.ToListAsync();
        }

        public async Task<Library> GetByIdAsync(int id)
        {
            return await _dbContext.Libraries.FindAsync(id);
        }

        public async Task AddAsync(Library library)
        {
            await _dbContext.Libraries.AddAsync(library);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Library library)
        {
            _dbContext.Libraries.Update(library);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var library = await _dbContext.Libraries.FindAsync(id);
            if (library != null)
            {
                _dbContext.Libraries.Remove(library);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}