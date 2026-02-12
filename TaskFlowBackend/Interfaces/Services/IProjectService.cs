using TaskFlowBackend.Dtos;
using TaskFlowBackend.Models;

namespace TaskFlowBackend.Interfaces.Services
{
    public interface IProjectService
    {
        Task<List<Project?>> GetAllProjects();
        Task<Project?> GetProjectById(GetProjectByIdDto dto);
        Task<bool> AddProject(AddProjectDto dto);
        Task<bool> UpdateProject(UpdateProjectDto dto);
        Task<bool> DeleteProject(int id);
    }
}
