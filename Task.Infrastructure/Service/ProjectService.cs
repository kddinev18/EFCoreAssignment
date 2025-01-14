using Task.Infrastructure.Interfaces;
using Task.Domain.DTOs;
using Task.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.Infrastructure.IService
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<ProjectDTO>> GetAllProjectsAsync()
        {
            var projects = await _projectRepository.GetAllProjectsAsync();
            return projects.Select(p => new ProjectDTO
            {
                ProjectId = p.ProjectId,
                Name = p.Name,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                Budget = p.Budget
            }).ToList();
        }

        public async Task<ProjectDTO> GetProjectByIdAsync(int id)
        {
            var project = await _projectRepository.GetProjectByIdAsync(id);
            if (project == null) return null;

            return new ProjectDTO
            {
                ProjectId = project.ProjectId,
                Name = project.Name,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                Budget = project.Budget
            };
        }

        public async Task CreateProjectAsync(ProjectDTO projectDto)
        {
            var project = new Project
            {
                Name = projectDto.Name,
                StartDate = projectDto.StartDate,
                EndDate = projectDto.EndDate,
                Budget = projectDto.Budget
            };
            await _projectRepository.CreateProjectAsync(project);
        }

        public async Task UpdateProjectAsync(int id, ProjectDTO projectDto)
        {
            var existingProject = await _projectRepository.GetProjectByIdAsync(id);
            if (existingProject == null) return;

            existingProject.Name = projectDto.Name;
            existingProject.StartDate = projectDto.StartDate;
            existingProject.EndDate = projectDto.EndDate;
            existingProject.Budget = projectDto.Budget;

            await _projectRepository.UpdateProjectAsync(existingProject);
        }

        public async Task DeleteProjectAsync(int id)
        {
            await _projectRepository.DeleteProjectAsync(id);
        }
    }
}
