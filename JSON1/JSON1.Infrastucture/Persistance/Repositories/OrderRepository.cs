using JSON1.Domain.Entities;
using JSON1.Domain.Interfaces;
using JSON1.Infrastucture.Persistance.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSON1.Infrastucture.Persistance.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Order>> GetByUserIdAsync(int userId)
        {
            return await _dbSet.Where(order => order.UserId == userId).ToListAsync();
        }
    }
}
