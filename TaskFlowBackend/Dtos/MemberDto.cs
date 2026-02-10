namespace TaskFlowBackend.Dtos
{
    public class GetUserById
    {
        public int Id { get; set; }
    }
    public class AddUserDto
    {
        //public string UserName { get; set; }
        //public string Password { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
    }
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public bool IsActive { get; set; }
    }
}
