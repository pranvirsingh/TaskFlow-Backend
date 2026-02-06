using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskFlowBackend.Data;
using TaskFlowBackend.Interfaces.Repositories;
using TaskFlowBackend.Interfaces.Services;
using TaskFlowBackend.Models;
using TaskFlowBackend.Repositories;
using TaskFlowBackend.Dtos;

namespace TaskFlowBackend.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;

        public AuthService(IAuthRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        public async Task<LoginResponseDto?> LoginAsync(LoginRequestDto dto)
        {
            var user = await _repo.GetUserAsync(dto);

            if (user == null)
                return null;

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.UserName == "admin" ? "Admin" : "User")
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    Convert.ToDouble(_config["Jwt:ExpireMinutes"])),
                signingCredentials: creds
            );

            var userType = user.UserName == "admin" ? 1 : 2; 
            var result = new LoginResponseDto
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                usertype = userType,
                username = user.UserName,
                fullname = user.FullName,
                statusCode = 200,
            };
            return result;

        }
        
        public async Task<User?> GetUserDetailsById(int userId)
        {
            var userDetails = await _repo.GetUserDetailsByIdAsync(userId);

            if (userDetails == null)
                return null;
            return userDetails;

        }
    }
}
