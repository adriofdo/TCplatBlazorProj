using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using SQLDatAccessLibrary;

using System.Web;

using System.Text;
using System;
using System.Net;



namespace TcPlatWebApp.Authentication;

public class UserAccountService
{
    private readonly ISqlDataAccess _dataAccess;
    private readonly  SQLDatAccessLibrary.VG _vgAppuntamenti;
    string CurrentUserName;
    
    
    public UserAccountService(ISqlDataAccess dataAccess, VG vgAppuntamenti)
    {
        _dataAccess = dataAccess;
        _vgAppuntamenti = vgAppuntamenti;
    }

    public async Task<List<UserAccount>> GetbyUserNameAsync(string userName)
    {
        string sql = "SELECT * FROM [dbo].[tblInfoAnagrafici] WHERE Username = @Username";
        var parameters = new { Username = userName };

        return await _dataAccess.LoadData<UserAccount, dynamic>(sql, parameters);
    }

   
   
}
