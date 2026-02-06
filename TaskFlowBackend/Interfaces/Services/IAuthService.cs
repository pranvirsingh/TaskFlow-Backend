using TaskFlowBackend.Models;
using TaskFlowBackend.Dtos;

namespace TaskFlowBackend.Interfaces.Services
{
    public interface IAuthService
    {
        public Task<LoginResponseDto?> LoginAsync(LoginRequestDto dto);
        public Task<User?> GetUserDetailsById(int userId);

    }
}
