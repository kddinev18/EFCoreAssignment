using JsonTRI.Domain.Entities;
using JsonTRI.Domain.Interfaces;
using JsonTRI.Infrastucture.Persistance.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonTRI.Infrastucture.Persistance.Repositories
{
    public class LibraryRepository : Repository<Library>, ILibraryRepository
    {
        public LibraryRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Library>> GetByOrderIdAsync(int libraryId)
        {
            return await _dbSet.Where(od => od.LibraryId == libraryId).ToListAsync();
        }
    }
}
