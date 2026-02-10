using TaskFlowBackend.Dtos;
using TaskFlowBackend.Interfaces.Repositories;
using TaskFlowBackend.Interfaces.Services;
using TaskFlowBackend.Models;

namespace TaskFlowBackend.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _repo;
        private readonly IConfiguration _config;

        public MemberService(IMemberRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        public async Task<List<User?>> GetAllUsers()
        {
            return await _repo.GetAllUsersDetails();
        }

        public async Task<User?> GetUserById(GetUserById dto)
        {
            return await _repo.GetUserById(dto);
        }
        public async Task<bool> AddUser(AddUserDto dto)
        {
            return await _repo.AddUserAsync(dto);
        }

        public async Task<bool> UpdateUser(UpdateUserDto dto)
        {
            return await _repo.UpdateUserAsync(dto);
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await _repo.DeleteUserAsync(id);
        }

    }
}
