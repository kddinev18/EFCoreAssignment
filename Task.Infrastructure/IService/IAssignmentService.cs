using Task.Domain.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task.Infrastructure.IService
{
    public interface IAssignmentService
    {
        Task<List<AssignmentDTO>> GetAllAssignmentsAsync();
        Task<AssignmentDTO> GetAssignmentByIdAsync(int id);
        Task CreateAssignmentAsync(AssignmentDTO assignmentDto);
        Task UpdateAssignmentAsync(int id, AssignmentDTO assignmentDto);
        Task DeleteAssignmentAsync(int id);
    }
}