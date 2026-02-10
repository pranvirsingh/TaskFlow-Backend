using TaskFlowBackend.Dtos;
using TaskFlowBackend.Models;

namespace TaskFlowBackend.Interfaces.Services
{
    public interface IMemberService
    {
        public Task<List<User?>> GetAllUsers();
        public Task<User?> GetUserById(GetUserById dto);
        Task<bool> AddUser(AddUserDto dto);
        Task<bool> UpdateUser(UpdateUserDto dto);
        Task<bool> DeleteUser(int id);

    }
}
