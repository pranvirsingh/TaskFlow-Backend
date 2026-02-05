using Microsoft.AspNetCore.Mvc;
using TaskFlowBackend.Interfaces.Services;
using TaskFlowBackend.Services;
using TaskFlowBackend.Dtos;

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
                return Unauthorized("Invalid credentials");

            return Ok(new { result });
        }
    }
}
