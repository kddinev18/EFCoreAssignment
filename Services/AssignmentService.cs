using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace YourNamespace.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly ApplicationDbContext _context;

        public AssignmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Assignment>> GetAllAssignmentsAsync()
        {
            return await _context.Assignments.ToListAsync();
        }

        public async Task<Assignment> GetAssignmentByIdAsync(int id)
        {
            return await _context.Assignments.FindAsync(id);
        }

        public async Task AddAssignmentAsync(Assignment assignment)
        {
            await _context.Assignments.AddAsync(assignment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAssignmentAsync(Assignment assignment)
        {
            _context.Entry(assignment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAssignmentAsync(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment != null)
            {
                _context.Assignments.Remove(assignment);
                await _context.SaveChangesAsync();
            }
        }
    }
}