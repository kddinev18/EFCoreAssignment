using Task.Infrastructure.Interfaces;
using Task.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task.Infrastructure.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            return employees.Select(e => new EmployeeDTO
            {
                EmployeeId = e.EmployeeId,
                Name = e.Name,
                Position = e.Position,
                HireDate = e.HireDate,
                Salary = e.Salary,
                DepartmentId = e.DepartmentId
            }).ToList();
        }

        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null) return null;
            return new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                Position = employee.Position,
                HireDate = employee.HireDate,
                Salary = employee.Salary,
                DepartmentId = employee.DepartmentId
            };
        }
    }
}