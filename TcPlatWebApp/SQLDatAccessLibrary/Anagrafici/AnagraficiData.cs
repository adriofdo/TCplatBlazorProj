using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDatAccessLibrary.Anagrafici
{
    public class AnagraficiData : IAnagraficiData
    {

        private readonly ISqlDataAccess _db;

        public AnagraficiData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<AnagraficiModel>> GetAnagrafici()
        {
            string sql = "SELECT * from dbo.tblInfoAnagrafici Where ActState=1 ";
            return _db.LoadData<AnagraficiModel, dynamic>(sql, new { });
        }


    }
}
