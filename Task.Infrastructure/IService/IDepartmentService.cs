using Task.Domain.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task.Infrastructure.IService
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDTO>> GetAllDepartmentsAsync();
        Task<DepartmentDTO> GetDepartmentByIdAsync(int id);
        Task CreateDepartmentAsync(DepartmentDTO departmentDto);
        Task UpdateDepartmentAsync(int id, DepartmentDTO departmentDto);
        Task DeleteDepartmentAsync(int id);
    }
}