using JSON1.Domain.Entities;
using JSON1.Domain.Interfaces;
using JSON1.Infrastucture.Persistance.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSON1.Infrastucture.Persistance.Repositories
{
    public class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<OrderDetails>> GetByOrderIdAsync(int orderId)
        {
            return await _dbSet.Where(od => od.OrderId == orderId).ToListAsync();
        }
    }
}
