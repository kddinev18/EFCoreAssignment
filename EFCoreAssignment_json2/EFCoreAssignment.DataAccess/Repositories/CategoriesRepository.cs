using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment.DataAccess.Repositories
{
    public class CategoriesRepository : IRepository<Categories>
    {
        private readonly DbContext _context;
        private readonly DbSet<Categories> _dbSet;

        public CategoriesRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Categories>();
        }

        public async Task<Categories> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Categories>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<Categories>> FindAsync(Expression<Func<Categories, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(Categories entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(Categories entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Remove(Categories entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}