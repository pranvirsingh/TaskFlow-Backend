using System.ComponentModel.DataAnnotations;

namespace TaskFlowBackend.Dtos.Role
{
    public class CreateRoleDto
    {
        [Required]
        public string RoleName { get; set; }

        public string? Description { get; set; }
    }
}
