using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment.DataAccess.Repositories
{
    public class CustomersRepository : IRepository<Customers>
    {
        private readonly DbContext _context;
        private readonly DbSet<Customers> _dbSet;

        public CustomersRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Customers>();
        }

        public async Task<Customers> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<Customers>> FindAsync(Expression<Func<Customers, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(Customers entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(Customers entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Remove(Customers entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}