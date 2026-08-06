using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

namespace FinanceTrackerLibrary.DataAccess
{
    public class SqlDataAccess
    {
        private readonly string _connectionString;


        public SqlDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<T>> LoadDataAsync<T>(string sql, object parameters = null)
        {
            using (IDbConnection connection = new MySqlConnection(_connectionString))
            {
                var result = await connection.QueryAsync<T>(sql, parameters);
                return result.ToList();
            }
        }
    
    public async Task SaveDataAsync<T>(string sql, T parameters)
        {
            using (IDbConnection connection = new MySqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}