using TaskFlowBackend.Models;
using TaskFlowBackend.Dtos;

namespace TaskFlowBackend.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        public Task<User?> GetUserAsync(LoginRequestDto query);
        public Task<User?> GetUserDetailsByIdAsync(int userId);
        public Task<bool> UpdateProfileAsync(int userId, UpdateProfileDto dto);
    }
}
