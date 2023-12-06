namespace Shoematic.API.Dto
{
    public class LoginRequestDto
    {
        public string UserEmail {  get; set; }
        public string Password { get; set; }
        public bool IsAdmin{ get; set; }
    }
}
