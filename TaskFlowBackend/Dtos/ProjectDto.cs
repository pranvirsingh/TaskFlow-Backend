using System.ComponentModel.DataAnnotations;

namespace TaskFlowBackend.Dtos
{
    public class GetProjectByIdDto
    {
        [Required]
        public int Id { get; set; }
    }

    public class AddProjectDto
    {
        [Required]
        [StringLength(150)]
        public string ProjectName { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public int CreatedBy { get; set; }
    }

    public class UpdateProjectDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string ProjectName { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public bool IsActive { get; set; }
    }
}
