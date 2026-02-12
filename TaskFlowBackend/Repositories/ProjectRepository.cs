using Microsoft.EntityFrameworkCore;
using TaskFlowBackend.Data;
using TaskFlowBackend.Dtos;
using TaskFlowBackend.Interfaces.Repositories;
using TaskFlowBackend.Models;

namespace TaskFlowBackend.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ProjectRepository> _logger;

        public ProjectRepository(AppDbContext context, ILogger<ProjectRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Project?>> GetAllProjects()
        {
            try
            {
                return await _context.Projects
                    .Where(x => !x.IsDeleted)
                    .OrderByDescending(x => x.Id)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Fetching Project Details");
                return new List<Project?>();
            }
        }

        public async Task<Project?> GetProjectById(GetProjectByIdDto dto)
        {
            try
            {
                return await _context.Projects
                    .Include(x => x.CreatedByUser)
                    .FirstOrDefaultAsync(x => x.Id == dto.Id && !x.IsDeleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Fetching Project Details");
                return null;
            }
        }

        public async Task<bool> AddProjectAsync(AddProjectDto dto)
        {
            try
            {
                var project = new Project
                {
                    ProjectName = dto.ProjectName,
                    Description = dto.Description,
                    CreatedBy = dto.CreatedBy,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedAt = DateTime.UtcNow
                };

                _context.Projects.Add(project);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Adding Project");
                return false;
            }
        }

        public async Task<bool> UpdateProjectAsync(UpdateProjectDto dto)
        {
            try
            {
                var project = await _context.Projects
                    .FirstOrDefaultAsync(x => x.Id == dto.Id && !x.IsDeleted);

                if (project == null)
                    return false;

                project.ProjectName = dto.ProjectName;
                project.Description = dto.Description;
                project.IsActive = dto.IsActive;
                project.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Updating Project");
                return false;
            }
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            try
            {
                var project = await _context.Projects
                    .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

                if (project == null)
                    return false;

                project.IsDeleted = true;
                project.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Deleting Project");
                return false;
            }
        }
    }
}
