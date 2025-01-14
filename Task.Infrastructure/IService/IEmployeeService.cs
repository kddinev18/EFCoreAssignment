using Task.Domain.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task.Infrastructure.IService
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDTO>> GetAllEmployeesAsync();
        Task<EmployeeDTO> GetEmployeeByIdAsync(int id);
        Task CreateEmployeeAsync(EmployeeDTO employeeDto);
        Task UpdateEmployeeAsync(int id, EmployeeDTO employeeDto);
        Task DeleteEmployeeAsync(int id);
    }
}