
public interface ILoginData
{
    int ValidateLogin(string username, string password);
    Task<int> ValidateLoginAsync(string username, string password);
}