using Task.Infrastructure.Interfaces;
using Task.Domain.DTOs;
using Task.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.Infrastructure.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<List<DepartmentDTO>> GetAllDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetAllDepartmentsAsync();
            return departments.Select(d => new DepartmentDTO
            {
                DepartmentId = d.DepartmentId,
                Name = d.Name,
                Location = d.Location,
                Budget = d.Budget
            }).ToList();
        }

        public async Task<DepartmentDTO> GetDepartmentByIdAsync(int id)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id);
            if (department == null) return null;

            return new DepartmentDTO
            {
                DepartmentId = department.DepartmentId,
                Name = department.Name,
                Location = department.Location,
                Budget = department.Budget
            };
        }

        public async Task CreateDepartmentAsync(DepartmentDTO departmentDto)
        {
            var department = new Department
            {
                Name = departmentDto.Name,
                Location = departmentDto.Location,
                Budget = departmentDto.Budget
            };
            await _departmentRepository.CreateDepartmentAsync(department);
        }

        public async Task UpdateDepartmentAsync(int id, DepartmentDTO departmentDto)
        {
            var existingDepartment = await _departmentRepository.GetDepartmentByIdAsync(id);
            if (existingDepartment == null) return;

            existingDepartment.Name = departmentDto.Name;
            existingDepartment.Location = departmentDto.Location;
            existingDepartment.Budget = departmentDto.Budget;

            await _departmentRepository.UpdateDepartmentAsync(existingDepartment);
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            await _departmentRepository.DeleteDepartmentAsync(id);
        }
    }
}
