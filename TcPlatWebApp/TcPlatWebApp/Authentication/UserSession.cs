namespace TcPlatWebApp.Authentication
{
    public class UserSession
    {
        public string Username { get; set; }
        public string Role { get; set; }
        public string Password { get; set; } // Only include this if absolutely necessary and it's securely handled
        public DateTime SessionStartTime { get; set; }
    }

}
