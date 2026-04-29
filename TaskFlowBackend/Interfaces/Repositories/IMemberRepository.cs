using TaskFlowBackend.Dtos;
using TaskFlowBackend.Models;

namespace TaskFlowBackend.Interfaces.Repositories
{
    public interface IMemberRepository
    {
        public Task<List<User?>> GetAllUsersDetails();
        public Task<User?> GetUserById(GetUserById dto);
        Task<bool> AddUserAsync(AddUserDto dto);
        Task<bool> UpdateUserAsync(UpdateUserDto dto);
        Task<bool> DeleteUserAsync(int id);
        Task<bool> AssignRoleAsync(int userId, int roleId);

    }
}
