using SQLDatAccessLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TcPlatWebApp.Authentication
{
    public class UserAccountService
    {
        private readonly ISqlDataAccess _dataAccess;

        public UserAccountService(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<List<UserAccount>> GetByUserNameAsync(string userName)
        {
            string sql = "SELECT * FROM [dbo].[tblInfoAnagrafici] WHERE Username = @Username";
            return await _dataAccess.LoadData<UserAccount, dynamic>(sql, new { Username = userName });
        }
    }
}
