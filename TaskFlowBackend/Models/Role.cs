using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskFlowBackend.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string RoleName { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
