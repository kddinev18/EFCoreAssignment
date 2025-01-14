using Task.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task.Infrastructure.Interface
{
    public interface IAssignmentRepository
    {
        Task<List<Assignment>> GetAllAssignmentsAsync();
        Task<Assignment> GetAssignmentByIdAsync(int id);
        Task CreateAssignmentAsync(Assignment assignment);
        Task UpdateAssignmentAsync(Assignment assignment);
        Task DeleteAssignmentAsync(int id);
    }
}