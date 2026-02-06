namespace TaskFlowBackend.Dtos
{
    public class LoginRequestDto
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class LoginResponseDto
    {
        public string token { get; set; }
        public string username { get; set; }
        public string fullname { get; set; }
        public int statusCode { get; set; }
        public string message { get; set; }
        public int usertype { get; set; }  // 1: Admin, 2: Regular User

    }

}
