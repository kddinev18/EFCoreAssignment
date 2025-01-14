using Task.Domain.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task.Infrastructure.IService
{
    public interface IProjectService
    {
        Task<List<ProjectDTO>> GetAllProjectsAsync();
        Task<ProjectDTO> GetProjectByIdAsync(int id);
        Task CreateProjectAsync(ProjectDTO projectDto);
        Task UpdateProjectAsync(int id, ProjectDTO projectDto);
        Task DeleteProjectAsync(int id);
    }
}