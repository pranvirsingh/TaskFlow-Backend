using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskFlowBackend.Common;
using TaskFlowBackend.Dtos;
using TaskFlowBackend.Interfaces.Services;
using TaskFlowBackend.Services;

namespace TaskFlowBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            var result = await _auth.LoginAsync(dto);

            if (result == null)
            {
                return Unauthorized("Invalid credentials");
            }
            //Thread.Sleep(5000);
            return Ok(new { result });

        }

        [Authorize]
        [HttpGet("myProfile")]
        public async Task<IActionResult> MyProfile()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                //return Unauthorized("Invalid credentials");
                return StatusCode(401, new ResponseResult<object>(
                    401,
                    "Invalid credentials",
                    null
                ));

            }
            var result = await _auth.GetUserDetailsById(Convert.ToInt32(userId));
            //return Ok(new { result });
            return Ok(new ResponseResult<object>(
                200,
                "Records fetched successfully",
                result
            ));

        }
    }
}
