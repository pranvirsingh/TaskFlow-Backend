using System.ComponentModel.DataAnnotations;

namespace TaskFlowBackend.Dtos
{
    public class GetUserById
    {
        [Required]
        public int Id { get; set; }
    }

    public class AddUserDto
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Mobile { get; set; }
    }

    public class UpdateUserDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Mobile { get; set; }

        public bool IsActive { get; set; }
    }
}
