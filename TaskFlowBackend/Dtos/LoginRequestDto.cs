namespace TaskFlowBackend.Dtos
{
    public class LoginRequestDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponseDto
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string UserType { get; set; }  // 1: Admin, 2: Regular User

    }

}
