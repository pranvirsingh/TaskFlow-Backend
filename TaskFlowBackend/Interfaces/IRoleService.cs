using TaskFlowBackend.Dtos.Role;

namespace TaskFlowBackend.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleResponseDto>> GetAllRolesAsync();
        Task<RoleResponseDto?> GetRoleByIdAsync(int id);
        Task<RoleResponseDto> CreateRoleAsync(CreateRoleDto createRoleDto);
        Task<RoleResponseDto?> UpdateRoleAsync(int id, UpdateRoleDto updateRoleDto);
        Task<bool> DeleteRoleAsync(int id);
        Task<bool> RoleExistsAsync(int id);
    }
}
