namespace TaskFlowBackend.Dtos.Role
{
    public class RoleResponseDto
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
