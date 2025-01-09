using JSON1.Domain.Entities;
using JSON1.Domain.Interfaces;
using JSON1.Infrastucture.Persistance.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSON1.Infrastucture.Persistance.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetByCategoryAsync(string category)
        {
            return await _dbSet.Where(product => product.Category == category).ToListAsync();
        }
    }
}
