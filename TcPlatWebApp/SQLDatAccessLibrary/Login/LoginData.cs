using SQLDatAccessLibrary;

public class LoginData : ILoginData
{
    private readonly ISqlDataAccess _db;

    public LoginData(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<int> ValidateLoginAsync(string username, string password)
    {
        string sql = "SELECT COUNT(*) FROM [dbo].[User] WHERE Username = @Username AND Password = @Password";
        var result = await _db.LoadData<int, dynamic>(sql, new { Username = username, Password = password });
        return result.FirstOrDefault();
    }

    // Synchronous wrapper
    public int ValidateLogin(string username, string password)
    {
        return ValidateLoginAsync(username, password).GetAwaiter().GetResult();
    }
}
