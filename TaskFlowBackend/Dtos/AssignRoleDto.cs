using System.ComponentModel.DataAnnotations;

namespace TaskFlowBackend.Dtos
{
    public class AssignRoleDto
    {
        [Required]
        public int RoleId { get; set; }
    }
}
