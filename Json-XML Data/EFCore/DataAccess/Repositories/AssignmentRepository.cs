using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class AssignmentRepository
    {
        private readonly AppDbContext _context;

        public AssignmentRepository(AppDbContext context)
        {
            _context = context;
        }

       
        public async Task<IEnumerable<Assignment>> GetAllAsync()
        {
            return await _context.Assignments
                .Include(a => a.Employee)
                .Include(a => a.Project)
                .ToListAsync();
        }

        
        public async Task<Assignment> GetByIdAsync(int id)
        {
            return await _context.Assignments
                .Include(a => a.Employee)
                .Include(a => a.Project)
                .FirstOrDefaultAsync(a => a.AssignmentId == id);
        }

       
        public async Task AddAsync(Assignment assignment)
        {
            await _context.Assignments.AddAsync(assignment);
            await _context.SaveChangesAsync();
        }

        
        public async Task UpdateAsync(Assignment assignment)
        {
            _context.Assignments.Update(assignment);
            await _context.SaveChangesAsync();
        }

       
        public async Task DeleteAsync(int id)
        {
            var assignment = await GetByIdAsync(id);
            if (assignment != null)
            {
                _context.Assignments.Remove(assignment);
                await _context.SaveChangesAsync();
            }
        }
    }
}