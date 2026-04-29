using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskFlowBackend.Common;
using TaskFlowBackend.Dtos;
using TaskFlowBackend.Interfaces.Services;

namespace TaskFlowBackend.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]

    public class MemberController : ControllerBase
    {
        private readonly IMemberService _auth;
        public MemberController(IMemberService auth)
        {
            _auth = auth;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //Thread.Sleep(5000);
            if (userId == null)
            {
                return StatusCode(401, new ResponseResult<object>(
                    401,
                    "Invalid credentials",
                    null
                ));
            }

            var result = await _auth.GetAllUsers();

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

        [HttpGet("GetById")]
        public async Task<IActionResult> GetUsersById([FromQuery] GetUserById _request)
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

            var result = await _auth.GetUserById(_request);

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

        [HttpPost("Add")]
        public async Task<IActionResult> AddUser([FromBody] AddUserDto dto)
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

            var result = await _auth.AddUser(dto);

            if (!result)
            {
                return Ok(new ResponseResult<object>(
                    400,
                    "Failed to add user",
                    null
                ));
            }

            return Ok(new ResponseResult<object>(
                200,
                "User added successfully",
                null
            ));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto dto)
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

            var result = await _auth.UpdateUser(dto);

            if (!result)
            {
                return Ok(new ResponseResult<object>(
                    400,
                    "Failed to Update User",
                    null
                ));
            }

            return Ok(new ResponseResult<object>(
                200,
                "User updated successfully",
                null
            ));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
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

            var result = await _auth.DeleteUser(id);

            if (!result)
            {
                return Ok(new ResponseResult<object>(
                    400,
                    "Failed to Delete User",
                    null
                ));
            }

            return Ok(new ResponseResult<object>(
                200,
                "User deleted successfully",
                null
            ));
        }

        [HttpPut("{userId}/role")]
        public async Task<IActionResult> AssignRole(int userId, [FromBody] AssignRoleDto dto)
        {
            var adminId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (adminId == null)
            {
                return StatusCode(401, new ResponseResult<object>(
                    401,
                    "Invalid credentials",
                    null
                ));
            }

            var result = await _auth.AssignRoleAsync(userId, dto.RoleId);

            if (!result)
            {
                return Ok(new ResponseResult<object>(
                    400,
                    "Failed to assign role. Ensure user and role exist.",
                    null
                ));
            }

            return Ok(new ResponseResult<object>(
                200,
                "Role assigned successfully",
                null
            ));
        }

    }
}
