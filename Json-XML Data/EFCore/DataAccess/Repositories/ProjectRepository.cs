using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

       
        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _context.Projects.Include(p => p.Assignments).ToListAsync();
        }

        
        public async Task<Project> GetByIdAsync(int id)
        {
            return await _context.Projects.Include(p => p.Assignments)
                .FirstOrDefaultAsync(p => p.ProjectId == id);
        }

        
        public async Task AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        
        public async Task UpdateAsync(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }

        
        public async Task DeleteAsync(int id)
        {
            var project = await GetByIdAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }
    }
}