using Dapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Data;

namespace SQLDatAccessLibrary
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly string ConnectionString;

        // Directly using the connection string without configuration files
        public SqlDataAccess()
        {
            ConnectionString = "Data Source=18.156.83.191;Initial Catalog=Tcplat;User ID=sa;Password=Lucia12!;TrustServerCertificate=True;";
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);
                return data.ToList();
            }
        }

        public async Task SaveData<T>(string sql, T parameters)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}
