using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment.DataAccess.Repositories
{
    public class ProductsRepository : IRepository<Products>
    {
        private readonly DbContext _context;
        private readonly DbSet<Products> _dbSet;

        public ProductsRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Products>();
        }

        public async Task<Products> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Products>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<Products>> FindAsync(Expression<Func<Products, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(Products entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(Products entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Remove(Products entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}