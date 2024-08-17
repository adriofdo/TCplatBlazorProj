namespace TcPlatWebApp.Authentication
{
    public class UserSession
    {
        public string Username { get; set; }
        public string Role { get; set; }
        public DateTime SessionStartTime { get; set; }
    }
}
