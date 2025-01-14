using Task.Infrastructure.Interfaces;
using Task.Domain.DTOs;
using Task.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.Infrastructure.Service
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentService(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task<List<AssignmentDTO>> GetAllAssignmentsAsync()
        {
            var assignments = await _assignmentRepository.GetAllAssignmentsAsync();
            return assignments.Select(a => new AssignmentDTO
            {
                AssignmentId = a.AssignmentId,
                EmployeeId = a.EmployeeId,
                ProjectId = a.ProjectId,
                HoursWorked = a.HoursWorked,
                Role = a.Role
            }).ToList();
        }

        public async Task<AssignmentDTO> GetAssignmentByIdAsync(int id)
        {
            var assignment = await _assignmentRepository.GetAssignmentByIdAsync(id);
            if (assignment == null) return null;

            return new AssignmentDTO
            {
                AssignmentId = assignment.AssignmentId,
                EmployeeId = assignment.EmployeeId,
                ProjectId = assignment.ProjectId,
                HoursWorked = assignment.HoursWorked,
                Role = assignment.Role
            };
        }

        public async Task CreateAssignmentAsync(AssignmentDTO assignmentDto)
        {
            var assignment = new Assignment
            {
                EmployeeId = assignmentDto.EmployeeId,
                ProjectId = assignmentDto.ProjectId,
                HoursWorked = assignmentDto.HoursWorked,
                Role = assignmentDto.Role
            };
            await _assignmentRepository.CreateAssignmentAsync(assignment);
        }

        public async Task UpdateAssignmentAsync(int id, AssignmentDTO assignmentDto)
        {
            var existingAssignment = await _assignmentRepository.GetAssignmentByIdAsync(id);
            if (existingAssignment == null) return;

            existingAssignment.EmployeeId = assignmentDto.EmployeeId;
            existingAssignment.ProjectId = assignmentDto.ProjectId;
            existingAssignment.HoursWorked = assignmentDto.HoursWorked;
            existingAssignment.Role = assignmentDto.Role;

            await _assignmentRepository.UpdateAssignmentAsync(existingAssignment);
        }

        public async Task DeleteAssignmentAsync(int id)
        {
            aw
