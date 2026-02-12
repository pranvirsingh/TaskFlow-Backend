using TaskFlowBackend.Dtos;
using TaskFlowBackend.Models;

namespace TaskFlowBackend.Interfaces.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project?>> GetAllProjects();
        Task<Project?> GetProjectById(GetProjectByIdDto dto);
        Task<bool> AddProjectAsync(AddProjectDto dto);
        Task<bool> UpdateProjectAsync(UpdateProjectDto dto);
        Task<bool> DeleteProjectAsync(int id);
    }
}
