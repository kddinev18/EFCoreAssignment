using JsonTRI.Domain.Interfaces;
using JsonTRI.Infrastucture.Persistance.Repositories.Abstractions;
using JsonTRI.Infrastucture.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonTRI.Domain.Entities;

namespace JsonTRI.Infrastucture.Persistance.Repositories
{
        public class BookRepository : Repository<Book>, IBookRepository
        {
            public BookRepository(ApplicationDbContext context) : base(context) { }

            public async Task<IEnumerable<Book>> GetByOrderIdAsync(int bookId)
            {
                return await _dbSet.Where(od => od.BookId == bookId).ToListAsync();
            }
        }
}
