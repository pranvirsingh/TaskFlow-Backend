using System.ComponentModel.DataAnnotations;

namespace TaskFlowBackend.Dtos.Role
{
    public class UpdateRoleDto
    {
        [Required]
        public string RoleName { get; set; }

        public string? Description { get; set; }
    }
}
