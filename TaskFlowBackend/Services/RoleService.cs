using TaskFlowBackend.Dtos.Role;
using TaskFlowBackend.Interfaces;
using TaskFlowBackend.Models;

namespace TaskFlowBackend.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<RoleResponseDto>> GetAllRolesAsync()
        {
            var roles = await _roleRepository.GetAllRolesAsync();
            return roles.Select(r => new RoleResponseDto
            {
                Id = r.Id,
                RoleName = r.RoleName,
                Description = r.Description,
                CreatedAt = r.CreatedAt
            });
        }

        public async Task<RoleResponseDto?> GetRoleByIdAsync(int id)
        {
            var role = await _roleRepository.GetRoleByIdAsync(id);
            if (role == null) return null;

            return new RoleResponseDto
            {
                Id = role.Id,
                RoleName = role.RoleName,
                Description = role.Description,
                CreatedAt = role.CreatedAt
            };
        }

        public async Task<RoleResponseDto> CreateRoleAsync(CreateRoleDto createRoleDto)
        {
            // Optional: check if role exists
            var existingRole = await _roleRepository.GetRoleByNameAsync(createRoleDto.RoleName);
            if (existingRole != null)
            {
                throw new InvalidOperationException("Role already exists.");
            }

            var role = new Role
            {
                RoleName = createRoleDto.RoleName,
                Description = createRoleDto.Description,
                CreatedAt = DateTime.UtcNow
            };

            var createdRole = await _roleRepository.CreateRoleAsync(role);

            return new RoleResponseDto
            {
                Id = createdRole.Id,
                RoleName = createdRole.RoleName,
                Description = createdRole.Description,
                CreatedAt = createdRole.CreatedAt
            };
        }

        public async Task<RoleResponseDto?> UpdateRoleAsync(int id, UpdateRoleDto updateRoleDto)
        {
            var role = await _roleRepository.GetRoleByIdAsync(id);
            if (role == null) return null;

            // Optional: check if new name is already taken by another role
            var existingRoleDesc = await _roleRepository.GetRoleByNameAsync(updateRoleDto.RoleName);
            if (existingRoleDesc != null && existingRoleDesc.Id != id)
            {
                throw new InvalidOperationException("Role name already exists.");
            }

            role.RoleName = updateRoleDto.RoleName;
            role.Description = updateRoleDto.Description;

            var updatedRole = await _roleRepository.UpdateRoleAsync(role);

            return new RoleResponseDto
            {
                Id = updatedRole.Id,
                RoleName = updatedRole.RoleName,
                Description = updatedRole.Description,
                CreatedAt = updatedRole.CreatedAt
            };
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            return await _roleRepository.DeleteRoleAsync(id);
        }

        public async Task<bool> RoleExistsAsync(int id)
        {
            return await _roleRepository.RoleExistsAsync(id);
        }
    }
}
