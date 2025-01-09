using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment.DataAccess.Repositories
{
    public class SalesRepository : IRepository<Sales>
    {
        private readonly DbContext _context;
        private readonly DbSet<Sales> _dbSet;

        public SalesRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Sales>();
        }

        public async Task<Sales> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Sales>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<Sales>> FindAsync(Expression<Func<Sales, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(Sales entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(Sales entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Remove(Sales entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}