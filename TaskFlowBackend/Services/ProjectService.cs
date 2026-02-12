using TaskFlowBackend.Dtos;
using TaskFlowBackend.Interfaces.Repositories;
using TaskFlowBackend.Interfaces.Services;
using TaskFlowBackend.Models;

namespace TaskFlowBackend.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repo;
        private readonly IConfiguration _config;

        public ProjectService(IProjectRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        public async Task<List<Project?>> GetAllProjects()
        {
            return await _repo.GetAllProjects();
        }

        public async Task<Project?> GetProjectById(GetProjectByIdDto dto)
        {
            return await _repo.GetProjectById(dto);
        }

        public async Task<bool> AddProject(AddProjectDto dto)
        {
            return await _repo.AddProjectAsync(dto);
        }

        public async Task<bool> UpdateProject(UpdateProjectDto dto)
        {
            return await _repo.UpdateProjectAsync(dto);
        }

        public async Task<bool> DeleteProject(int id)
        {
            return await _repo.DeleteProjectAsync(id);
        }
    }
}
