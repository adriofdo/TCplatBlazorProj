using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SQLDatAccessLibrary
{
    public class LoginData : ILoginData
    {
        private readonly ISqlDataAccess _db;

        public LoginData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<int> ValidateLoginAsync(string username, string password)
        {
            // Hash the input password using SHA-256
            string hashedPassword = HashPassword(password);

            string sql = "SELECT COUNT(*) FROM [dbo].[tblInfoAnagrafici] WHERE Username = @Username AND Pwd = @Password";
            var result = await _db.LoadData<int, dynamic>(sql, new { Username = username, Password = hashedPassword });
            return result.FirstOrDefault();
        }

        public int ValidateLogin(string username, string password)
        {
            return ValidateLoginAsync(username, password).GetAwaiter().GetResult();
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
