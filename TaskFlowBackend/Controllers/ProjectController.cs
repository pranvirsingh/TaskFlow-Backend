using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskFlowBackend.Common;
using TaskFlowBackend.Dtos;
using TaskFlowBackend.Interfaces.Services;

namespace TaskFlowBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _project;

        public ProjectController(IProjectService project)
        {
            _project = project;
        }

        [Authorize]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllProjects()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return StatusCode(401, new ResponseResult<object>(
                    401,
                    "Invalid credentials",
                    null
                ));
            }

            var result = await _project.GetAllProjects();

            if (result == null || result.Count == 0)
            {
                return Ok(new ResponseResult<object>(
                    200,
                    "No Records Found",
                    null
                ));
            }

            return Ok(new ResponseResult<object>(
                200,
                "Records fetched successfully",
                result
            ));
        }

        [Authorize]
        [HttpGet("GetById")]
        public async Task<IActionResult> GetProjectById([FromQuery] GetProjectByIdDto request)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return StatusCode(401, new ResponseResult<object>(
                    401,
                    "Invalid credentials",
                    null
                ));
            }

            var result = await _project.GetProjectById(request);

            if (result == null)
            {
                return Ok(new ResponseResult<object>(
                    200,
                    "No Records Found",
                    null
                ));
            }

            return Ok(new ResponseResult<object>(
                200,
                "Records fetched successfully",
                result
            ));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Add")]
        public async Task<IActionResult> AddProject([FromBody] AddProjectDto dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return StatusCode(401, new ResponseResult<object>(
                    401,
                    "Invalid credentials",
                    null
                ));
            }
            dto.CreatedBy = Convert.ToInt32(userId);
            var result = await _project.AddProject(dto);

            if (!result)
            {
                return Ok(new ResponseResult<object>(
                    400,
                    "Failed to add project",
                    null
                ));
            }

            return Ok(new ResponseResult<object>(
                200,
                "Project added successfully",
                null
            ));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProject([FromBody] UpdateProjectDto dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return StatusCode(401, new ResponseResult<object>(
                    401,
                    "Invalid credentials",
                    null
                ));
            }

            var result = await _project.UpdateProject(dto);

            if (!result)
            {
                return Ok(new ResponseResult<object>(
                    400,
                    "Failed to Update Project",
                    null
                ));
            }

            return Ok(new ResponseResult<object>(
                200,
                "Project updated successfully",
                null
            ));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return StatusCode(401, new ResponseResult<object>(
                    401,
                    "Invalid credentials",
                    null
                ));
            }

            var result = await _project.DeleteProject(id);

            if (!result)
            {
                return Ok(new ResponseResult<object>(
                    400,
                    "Failed to Delete Project",
                    null
                ));
            }

            return Ok(new ResponseResult<object>(
                200,
                "Project deleted successfully",
                null
            ));
        }
    }
}
