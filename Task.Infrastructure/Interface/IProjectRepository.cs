using Task.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task.Infrastructure.Interface
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task CreateProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(int id);
    }
}