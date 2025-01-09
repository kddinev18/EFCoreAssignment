using JsonTRI.Domain.Entities;
using JsonTRI.Domain.Interfaces;
using JsonTRI.Infrastucture.Persistance.Repositories.Abstractions;
using JsonTRI.Infrastucture.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsonTRI.Infrastucture.Persistance.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Author>> GetByOrderIdAsync(int authorId)
        {
            return await _dbSet.Where(od => od.AuthorId == authorId).ToListAsync();
        }
    }
}