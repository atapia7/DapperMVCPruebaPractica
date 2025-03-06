using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;

namespace DapperMVC.Data.DataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public SqlDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlServerConnection") ?? throw new InvalidOperationException("La cadena de conexión no está configurada.");
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<IEnumerable<T>> GetData<T,P>(string spName, P parameters)
        {
            using IDbConnection cnx = new SqlConnection
                (_configuration.GetConnectionString(_connectionString));
           return await cnx.QueryAsync<T>(spName, parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(string spName, T parameters)
        {
            using IDbConnection cnx = new SqlConnection
                (_configuration.GetConnectionString(_connectionString));
            await cnx.ExecuteAsync(spName, parameters,
                commandType: CommandType.StoredProcedure);
        }


    }
}
