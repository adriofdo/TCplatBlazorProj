using Dapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using Mysqlx.Connection;

namespace SQLDatAccessLibrary

{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;
        //public string ConnectionString { get; set; } = "Server=servertc-25c772c3-adriotcplat2024.a.aivencloud.com;Port=20877;Database=Tcplat;Uid=avnadmin;Pwd=AVNS_ohq66m2-xD5dt9ouwg8;SSL Mode=Required;CertificateFile=ca.pem";
        public string ConnectionString { get; set; } = "Data Source=18.156.83.191; Initial Catalog =  Tcplat; User ID = sa; Password=Lucia12!";
        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);
                return data.ToList();
            }
        }
    }
}
